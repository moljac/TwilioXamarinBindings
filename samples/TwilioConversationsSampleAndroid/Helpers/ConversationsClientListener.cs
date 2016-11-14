using System;

namespace TwilioConversationsSampleAndroid
{
	public class ConversationsClientListener : Java.Lang.Object, Twilio.Conversations.Conversation.IListener
	{
		public ConversationsClientListener()
		{
		}

		public void OnConversationEnded(Twilio.Conversations.Conversation p0, Twilio.Conversations.TwilioConversationsException p1)
		{
			throw new NotImplementedException();
		}

		public void OnFailedToConnectParticipant(Twilio.Conversations.Conversation p0, Twilio.Conversations.Participant p1, Twilio.Conversations.TwilioConversationsException p2)
		{
			throw new NotImplementedException();
		}

		public void OnParticipantConnected(Twilio.Conversations.Conversation p0, Twilio.Conversations.Participant p1)
		{
			throw new NotImplementedException();
		}

		public void OnParticipantDisconnected(Twilio.Conversations.Conversation p0, Twilio.Conversations.Participant p1)
		{
			throw new NotImplementedException();
		}
	}
}
