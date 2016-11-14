using System;
using Twilio.Common;

namespace TwilioIPMessagingSample
{
	public class AccessManagerListener : Java.Lang.Object, Twilio.Common.AccessManager.IListener
	{
		public AccessManagerListener()
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
