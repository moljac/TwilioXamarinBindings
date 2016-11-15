using System;

namespace Twilio.Conversations
{
	public class ParticipantListener : Java.Lang.Object, Twilio.Conversations.Participant.IListener
	{
		public ParticipantListener()
		{
			/*
			VideoTrackAddedHandler = (conversation, participant, videoTrack) =>
			{
				Android.Util.Log.Info(TAG, "onVideoTrackAdded " + participant.Identity);
				conversationStatusTextView.Text = "onVideoTrackAdded " + participant.Identity;

				// Remote participant
				participantVideoRenderer = new VideoViewRenderer(this, participantContainer);
				participantVideoRenderer.SetObserver(new VideoRendererObserver
				{
					FirstFrameHandler = () =>
					{
						Android.Util.Log.Info(TAG, "Participant onFirstFrame");
					},
					FrameDimensionsChangedHandler = (width, height, i) =>
					{
						Android.Util.Log.Info(TAG, "Participant onFrameDimensionsChanged " + width + " " + height);
					}
				});
				videoTrack.AddRenderer(participantVideoRenderer);
			};
			*/
		}

		public Action</*mc++ I*/Conversation, /*mc++ I*/Participant, /*mc++ I*/AudioTrack> AudioTrackAddedHandler 
		{ 
			get; 
			set; 
		}
		public void OnAudioTrackAdded(/*mc++ I*/Conversation conversation, /*mc++ I*/Participant participant, /*mc++ I*/AudioTrack audioTrack)
		{
			AudioTrackAddedHandler?.Invoke(conversation, participant, audioTrack);
		}

		public Action</*mc++ I*/Conversation, /*mc++ I*/Participant, /*mc++ I*/AudioTrack> AudioTrackRemovedHandler 
		{ 
			get; 
			set; 
		}
		public void OnAudioTrackRemoved(/*mc++ I*/Conversation conversation, /*mc++ I*/Participant participant, /*mc++ I*/AudioTrack audioTrack)
		{
			AudioTrackRemovedHandler?.Invoke(conversation, participant, audioTrack);
		}

		public Action</*mc++ I*/Conversation, /*mc++ I*/Participant, IMediaTrack> TrackDisabledHandler 
		{ 
			get; 
			set; 
		}
		public void OnTrackDisabled(/*mc++ I*/Conversation conversation, /*mc++ I*/Participant participant, IMediaTrack mediaTrack)
		{
			TrackDisabledHandler?.Invoke(conversation, participant, mediaTrack);
		}

		public Action</*mc++ I*/Conversation, /*mc++ I*/Participant, IMediaTrack> TrackEnabledHandler 
		{ 
			get; 
			set; 
		}
		public void OnTrackEnabled(/*mc++ I*/Conversation conversation, /*mc++ I*/Participant participant, IMediaTrack mediaTrack)
		{
			TrackEnabledHandler?.Invoke(conversation, participant, mediaTrack);
		}

		public Action</*mc++ I*/Conversation, /*mc++ I*/Participant, /*mc++ I*/VideoTrack> VideoTrackAddedHandler 
		{ 
			get; 
			set;
		}
		public void OnVideoTrackAdded(/*mc++ I*/Conversation conversation, /*mc++ I*/Participant participant, /*mc++ I*/VideoTrack videoTrack)
		{
			VideoTrackAddedHandler?.Invoke(conversation, participant, videoTrack);
		}

		public Action</*mc++ I*/Conversation, /*mc++ I*/Participant, /*mc++ I*/VideoTrack> VideoTrackRemovedHandler 
		{ 
			get; 
			set; 
		}
		public void OnVideoTrackRemoved(/*mc++ I*/Conversation conversation, /*mc++ I*/Participant participant, /*mc++ I*/VideoTrack videoTrack)
		{
			VideoTrackRemovedHandler?.Invoke(conversation, participant, videoTrack);
		}
	}
}
