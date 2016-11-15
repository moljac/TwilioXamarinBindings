using System;

namespace Twilio.IPMessaging
{
	public partial class InitListener : 
			//Java.Lang.Object, 
			// IConstantsInitListener,
			Twilio.IPMessaging..InitListener
	{
		public Action<Java.Lang.Exception> ErrorHandler { get; set; }
		public Action InitializedHandler { get; set; }

		public void OnError(Java.Lang.Exception error)
		{
			ErrorHandler?.Invoke(error);
		}

		public void OnInitialized()
		{
			InitializedHandler?.Invoke();
		}
	}

}
