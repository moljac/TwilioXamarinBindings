using System;

namespace Twilio.Conversations
{
	public class ConversationCallback 
			: 
			Java.Lang.Object
			, IConversationCallback
	{
		public Action<Conversation, TwilioConversationsException> ConversationHandler 
		{ 
			get; 
			set; 
		}
		public void OnConversation(Conversation conversation, TwilioConversationsException ex)
		{
			ConversationHandler?.Invoke(conversation, ex);
		}

	}
}
