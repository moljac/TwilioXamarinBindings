using System;

namespace TwilioConversationsSampleAndroid
{
	public class ParticipantListener : Java.Lang.Object, Twilio.Conversations.Participant.IListener
	{
		public ParticipantListener()
		{
		}

		public void OnAudioTrackAdded(Twilio.Conversations.Conversation p0, Twilio.Conversations.Participant p1, Twilio.Conversations.AudioTrack p2)
		{
			throw new NotImplementedException();
		}

		public void OnAudioTrackRemoved(Twilio.Conversations.Conversation p0, Twilio.Conversations.Participant p1, Twilio.Conversations.AudioTrack p2)
		{
			throw new NotImplementedException();
		}

		public void OnTrackDisabled(Twilio.Conversations.Conversation p0, Twilio.Conversations.Participant p1, Twilio.Conversations.IMediaTrack p2)
		{
			throw new NotImplementedException();
		}

		public void OnTrackEnabled(Twilio.Conversations.Conversation p0, Twilio.Conversations.Participant p1, Twilio.Conversations.IMediaTrack p2)
		{
			throw new NotImplementedException();
		}

		public void OnVideoTrackAdded(Twilio.Conversations.Conversation p0, Twilio.Conversations.Participant p1, Twilio.Conversations.VideoTrack p2)
		{
			throw new NotImplementedException();
		}

		public void OnVideoTrackRemoved(Twilio.Conversations.Conversation p0, Twilio.Conversations.Participant p1, Twilio.Conversations.VideoTrack p2)
		{
			throw new NotImplementedException();
		}
	}
}
