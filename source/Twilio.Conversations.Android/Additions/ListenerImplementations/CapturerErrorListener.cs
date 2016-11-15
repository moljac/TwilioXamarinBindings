using System;

namespace Twilio.Conversations
{
	public class CapturerErrorListener : Java.Lang.Object, Twilio.Conversations.ICapturerErrorListener
	{
		public CapturerErrorListener()
		{
			/*
			*/
		}


		public Action<CapturerException> ErrorHandler { get; set; }
		public void OnError(CapturerException error)
		{
			ErrorHandler?.Invoke(error);
		}
	}
}
