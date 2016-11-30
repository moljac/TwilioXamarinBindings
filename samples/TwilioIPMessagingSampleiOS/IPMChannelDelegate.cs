using System;
using Foundation;
using Twilio.IPMessaging;

namespace TwilioIPMessagingSampleiOS
{
	public class IPMChannelDelegate : ChannelDelegate
	{
		[Export("ipMessagingClient:channel:synchronizationStatusChanged:")]
		public override void ChannelSynchronizationStatusChanged(TwilioIPMessagingClient client, Channel channel, ChannelSynchronizationStatus status)
		{
		}
	}
}