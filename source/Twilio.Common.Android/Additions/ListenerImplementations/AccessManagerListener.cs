using System;
using Twilio.Common.Impl;

namespace Twilio.Common
{
	public class AccessManagerListener : TwilioAccessManagerListener
	{
		public Action<TwilioAccessManagerImpl> TokenExpiredHandler { get; set; }
		public Action<TwilioAccessManagerImpl, string> ErrorHandler { get; set; }
		public Action<TwilioAccessManagerImpl> TokenUpdatedHandler { get; set; }

		public void OnTokenExpired(TwilioAccessManagerImpl accessManager)
		{
			TokenExpiredHandler?.Invoke(accessManager);
		}

		public void OnError(TwilioAccessManagerImpl accessManager, string msg)
		{
			ErrorHandler?.Invoke(accessManager, msg);
		}

		public void OnTokenUpdated(TwilioAccessManagerImpl accessManager)
		{
			TokenUpdatedHandler?.Invoke(accessManager);
		}
	}
}