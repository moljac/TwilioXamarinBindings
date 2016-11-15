using System;


namespace Twilio.Conversations
{
	public class ConversationListener : 
				Java.Lang.Object
				//mc++ , Twilio.Conversations.Conversation.IListener // old SDK
	{
		public Action<Conversation, TwilioConversationsException> ConversationEndedHandler 
		{ 
			get; 
			set; 
		}
		public void OnConversationEnded(/*mc++ I*/Conversation conversation, TwilioConversationsException conversationException)
		{
			ConversationEndedHandler?.Invoke(conversation, conversationException);
		}

		public Action</*mc++ I*/Conversation, /*mc++ I*/Participant, TwilioConversationsException> FailedToConnectToParticipantHandler 
		{ 
			get; 
			set; 
		}
		public void OnFailedToConnectParticipant(/*mc++ I*/Conversation conversation, /*mc++ I*/Participant participant, TwilioConversationsException conversationException)
		{
			FailedToConnectToParticipantHandler?.Invoke(conversation, participant, conversationException);
		}

		public Action</*mc++ I*/Conversation, /*mc++ I*/Participant> ParticipantConnectedHandler { get; set; }
		public void OnParticipantConnected(/*mc++ I*/Conversation conversation, /*mc++ I*/Participant participant)
		{
			ParticipantConnectedHandler?.Invoke(conversation, participant);
		}

		public Action</*mc++ I*/Conversation, /*mc++ I*/Participant> ParticipantDisconnectedHandler { get; set; }
		public void OnParticipantDisconnected(/*mc++ I*/Conversation conversation, /*mc++ I*/Participant participant)
		{
			ParticipantDisconnectedHandler?.Invoke(conversation, participant);
		}
	
		public ConversationListener()
		{
			/*
			ParticipantConnectedHandler = (conversation, participant) =>
			{
				conversationStatusTextView.Text = "onParticipantConnected " + participant.Identity;
				participant.ParticipantListener = participantListener();
			};
			FailedToConnectToParticipantHandler = (conversation, participant, conversationException) =>
			{
				Android.Util.Log.Error(TAG, conversationException.Message);
				conversationStatusTextView.Text = "onFailedToConnectParticipant " + participant.Identity;
			};
			ParticipantDisconnectedHandler = (conversation, participant) =>
			{
				conversationStatusTextView.Text = "onParticipantDisconnected " + participant.Identity;
			};
			ConversationEndedHandler = (conversation, e) =>
			{
				conversationStatusTextView.Text = "onConversationEnded";
				reset();
			};
			*/
		}

		/*
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
		*/
	}
}
