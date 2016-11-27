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
		private const string TokenUrl = @"http://localhost:8000/token.php";
#else
        private const string TokenUrl = @"http://localhost:8000/token.php";
#endif
		// Configure access token manually for testing in `ViewDidLoad` if desired! 
		// You can create one manually in the Twilio Console.
		private VideoToken accessToken;

		// Video SDK components
		

		public ViewController(IntPtr handle) 
			: base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
		}

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
			
		}

		partial void MicButtonPressed(NSObject sender)
		{

		}

		private void DoConnect()
		{
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