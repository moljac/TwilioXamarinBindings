using System;
using Foundation;
using UIKit;
using Twilio.Video;

namespace TwilioRoomsSampleiOS
{
	public partial class ViewController : UIViewController
	{
		// Token coming from sample PHP token generator.
#if DEBUG
		private const string TokenUrl = @"http://ddbcf9c8.ngrok.io/token.php";
#else
        private const string TokenUrl = @"http://localhost:8000/token.php";
#endif
		// Configure access token manually for testing in `ViewDidLoad` if desired! 
		// You can create one manually in the Twilio Console.
		private VideoToken accessToken;

		// Video SDK components
		VideoClient client;
		Room room;
		CameraCapturer camera;
		LocalMedia localMedia;
		LocalVideoTrack localVideoTrack;
		LocalAudioTrack localAudioTrack;
		Participant participant;
		VideoRoomDelegate roomDelegate;

		// Utilities
		public bool IsSimulator => ObjCRuntime.Runtime.Arch == ObjCRuntime.Arch.SIMULATOR;

		public ViewController(IntPtr handle) 
			: base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// LocalMedia represents the collection of tracks that we are sending to other Participants from our VideoClient.
			localMedia = new LocalMedia();

			if (IsSimulator)
			{
				previewView.RemoveFromSuperview();
			}
			else
			{
				// Preview our local camera track in the local video preview view.
				StartPreview();
			}

			// Disconnect and mic button will be displayed when client is connected to a room.
			disconnectButton.Hidden = true;
			micButton.Hidden = true;
			// Should dispose of this.
			roomTextField.ShouldReturn += (textField) => { ConnectButtonPressed(textField); return true; };
		}

		#region Outlets
		async partial void ConnectButtonPressed(NSObject sender)
		{
			ShowRoomUI(true);
			DissmissKeyboard();

			if (accessToken == null)
			{
				LogMessage("Fetching an access token.");

				try
				{
					var token = await Utils.GetTokenAsync(TokenUrl);
					if (token != null)
					{
						accessToken = token;
						DoConnect();
					}
					else
					{
						LogMessage("Error retrieving the access token.");
						ShowRoomUI(false);
					}
				}
				catch (Exception e)
				{
					LogMessage($"Exception thrown when fetching access token: {e}");
				}
			}
			else
			{
				DoConnect();
			}
		}

		partial void DisconnectButtonPressed(NSObject sender)
		{
			room?.Disconnect();
			ShowRoomUI(true);
		}

		partial void MicButtonPressed(NSObject sender)
		{
			// We will toggle the mic to mute/unmute and change the title according to the user action.
			if (localAudioTrack != null)
			{
				localAudioTrack.Enabled = !localAudioTrack.Enabled;

				// Toggle the button title
				if (localAudioTrack.Enabled)
				{
					micButton.SetTitle("Mute", UIControlState.Normal);
				}
				else
				{
					micButton.SetTitle("Unmute", UIControlState.Normal);
				}
			}
		}
		#endregion

		#region Media Methods
		private void StartPreview()
		{
			if (IsSimulator) return;

			camera = new CameraCapturer();
			localVideoTrack = localMedia.AddVideoTrack(true, camera);

			if (localVideoTrack != null)
			{
				// Attach view to video track for local preview
				localVideoTrack.Attach(previewView);
				LogMessage("Video track added to localMedia.");

				// Should dispose of this.
				var tap = new UITapGestureRecognizer(FlipCamera);
				previewView.AddGestureRecognizer(tap);
			}
			else
			{
				LogMessage("Failed to add video track.");
			}
		}

		private void FlipCamera()
		{
			if (camera.Source == VideoCaptureSource.FrontCamera)
			{
				camera.SelectSource(VideoCaptureSource.BackCameraWide);
			}
			else
			{
				camera.SelectSource(VideoCaptureSource.FrontCamera);
			}
		}

		private void PrepareLocalMedia()
		{
			// We will offer local audio and video when we connect to room.

			// Adding local audio track to localMedia
			if (localAudioTrack == null)
			{
				localAudioTrack = localMedia.AddAudioTrack(true);
			}

			// Adding local video track to localMedia and starting local preview if it is not already started.
			if (localMedia.VideoTracks.Length == 0)
			{
				StartPreview();
			}
		}
		#endregion

		private void DoConnect()
		{
			if (accessToken.token == "TWILIO_ACCESS_TOKEN")
			{
				LogMessage("Please provide a valid token to connect to a room");
				return;
			}

			// Create a Client with the access token that we fetched (or hardcoded).
			if (client == null)
			{
				client = VideoClient.ClientWithToken(accessToken.token);
				if (client == null)
				{
					LogMessage("Failed to create video client");
					return;
				}
			}

			// Prepare local media which we will share with Room Participants.
			PrepareLocalMedia();
			ConnectOptions connectOptions = ConnectOptions.OptionsWithBlock(builder =>
			{
				// Use the local media that we prepared earlier.
				builder.LocalMedia = localMedia;
				// The name of the Room where the Client will attempt to connect to. Please note that if you pass an empty
				// Room `name`, the Client will create one for you. You can get the name or sid from any connected Room.
				builder.Name = roomTextField.Text;
			});

			// Connect to the Room using the options we provided.
			roomDelegate = new VideoRoomDelegate();
			room = client.ConnectWithOptions(connectOptions, roomDelegate);

			LogMessage($"Attempting to connect to room {roomTextField.Text}");
		}

		// Set the client UI status
		private void ShowRoomUI(bool inRoom)
		{
			roomTextField.Hidden = inRoom;
			connectButton.Hidden = inRoom;
			roomLine.Hidden = inRoom;
			roomLabel.Hidden = inRoom;
			micButton.Hidden = !inRoom;
			disconnectButton.Hidden = !inRoom;
			UIApplication.SharedApplication.IdleTimerDisabled = inRoom;
		}

		private void DissmissKeyboard()
		{
			if (roomTextField.IsFirstResponder)
			{
				roomTextField.ResignFirstResponder();
			}
		}

		private void CleanupRemoteParticipant()
		{
			if (participant != null)
			{
				if (participant.Media.VideoTracks.Length > 0)
				{
					participant.Media.VideoTracks[0].Detach(remoteView);
				}
				participant = null;
			}
		}

		private void LogMessage(string message)
		{
			messageLabel.Text = message;
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}