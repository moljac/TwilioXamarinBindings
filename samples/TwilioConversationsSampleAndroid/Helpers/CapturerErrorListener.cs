using System;
using Twilio.Common;

namespace TwilioConversationsSampleAndroid
{
	public class CapturerErrorListener : Java.Lang.Object, Twilio.Common.AccessManager.IListener
	{
		public CapturerErrorListener()
		{
		}

		public void OnError(AccessManager p0, string p1)
		{
			throw new NotImplementedException();
		}

		public void OnTokenExpired(AccessManager p0)
		{
			throw new NotImplementedException();
		}

		public void OnTokenUpdated(AccessManager p0)
		{
			throw new NotImplementedException();
		}
	}
}
