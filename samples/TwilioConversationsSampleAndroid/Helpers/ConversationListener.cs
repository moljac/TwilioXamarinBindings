using System;
using Twilio.Conversations;

namespace TwilioConversationsSampleAndroid
{
	public class ConversationListener : Twilio.Conversations.Conversation.IListener
	{
		public ConversationListener()
		{
		}

		public IntPtr Handle
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public void OnConversationEnded(Conversation p0, TwilioConversationsException p1)
		{
			throw new NotImplementedException();
		}

		public void OnFailedToConnectParticipant(Conversation p0, Participant p1, TwilioConversationsException p2)
		{
			throw new NotImplementedException();
		}

		public void OnParticipantConnected(Conversation p0, Participant p1)
		{
			throw new NotImplementedException();
		}

		public void OnParticipantDisconnected(Conversation p0, Participant p1)
		{
			throw new NotImplementedException();
		}
	}
}
