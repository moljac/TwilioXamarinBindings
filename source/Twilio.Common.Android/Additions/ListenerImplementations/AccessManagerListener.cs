using System;

namespace Twilio.Common
{
	public partial class AccessManagerListener 
		: 
			//mc++ Java.Lang.Object	//
			//mc++ , ITwilioAccessManagerListener
			Twilio.Common.AccessManager
			, Twilio.Common.AccessManager.IListener
	{
		public Action</*mc++ ITwilio*/AccessManager> TokenExpiredHandler { get; set; }
		public void OnTokenExpired(/*mc++ ITwilio*/AccessManager accessManager)
		{
			TokenExpiredHandler?.Invoke(accessManager);
		}

		public Action</*mc++ ITwilio*/AccessManager, string> ErrorHandler { get; set; }
		public void OnError(/*mc++ ITwilio*/AccessManager accessManager, string msg)
		{
			ErrorHandler?.Invoke(accessManager, msg);
		}

		public Action</*mc++ ITwilio*/AccessManager> TokenUpdatedHandler { get; set; }
		public void OnTokenUpdated(/*mc++ ITwilio*/AccessManager accessManager)
		{
			TokenUpdatedHandler?.Invoke(accessManager);
		}

		public AccessManagerListener(Android.Content.Context context, string token)
			: base(context, token, null)
		{
		}

		/*
		public void OnError(Twilio.Common.AccessManager p0, string p1)
		{
			throw new NotImplementedException();
		}

		public void OnTokenExpired(Twilio.Common.AccessManager p0)
		{
			throw new NotImplementedException();
		}

		public void OnTokenUpdated(Twilio.Common.AccessManager p0)
		{
			throw new NotImplementedException();
		}
		*/
	}
}
