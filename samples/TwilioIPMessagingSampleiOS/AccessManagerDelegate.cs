using System;
using Foundation;
using Twilio.Common;

namespace TwilioIPMessagingSampleiOS
{
	public class AccessManagerDelegate : TwilioAccessManagerDelegate
	{
		[Export("accessManagerTokenExpired:")]
		public override void AccessManagerTokenExpired(TwilioAccessManager accessManager)
		{
			Console.WriteLine("AccessManagerDelegate.AcessManagerTokenExpired()");
		}

		[Export("accessManager:error:")]
		public override void AccessManager(TwilioAccessManager accessManager, NSError error)
		{
			Console.WriteLine("AccessManagerDelegate.AccessManager()");
		}
	}
}