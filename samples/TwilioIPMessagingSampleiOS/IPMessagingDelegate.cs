using System;
using Foundation;
using Twilio.IPMessaging;
            
namespace TwilioIPMessagingSampleiOS
{
	public class IPMessagingDelegate : TwilioIPMessagingClientDelegate
	{
		public event Action<Message> OnMessageAdded;
		public event Action<Channel> OnChannelExist;
		public event Action<Channels> OnChannelDoesNotExist;
		
		[Export("ipMessagingClient:channel:messageAdded:")]
		public void ChannelMessageAdded(TwilioIPMessagingClient client, Channel channel, Message message)
		{
			Console.WriteLine("IPMessagingDelegate.ChannelMessageAdded()");
			OnMessageAdded?.Invoke(message);
		}

		[Export("ipMessagingClient:synchronizationStatusChanged:")]
		public override void SyncronizationStatusChanged(TwilioIPMessagingClient client, ClientSynchronizationStatus status)
		{
			Console.WriteLine("IPMessagingDelegate.SynchronizationStatusChanged()");
			if (status == ClientSynchronizationStatus.Completed)
			{
				// Retrieving channels lets you perform actions on them as a user (e.g join, display, etc.) 
				// You'll only be able to view public channels and any private channels your user can access.
				var generalChannel = client.ChannelsList?.ChannelWithUniqueName("general");
				if (generalChannel != null && generalChannel.Status == ChannelStatus.NotParticipating)
				{
					// Channel does exist.
					// Join it.
					OnChannelExist.Invoke(generalChannel);
				}
				else
				{
					// Channel Doesn't exist.
					// Create it.
					OnChannelDoesNotExist?.Invoke(client.ChannelsList);
				}
			}
		}

		[Export("ipMessagingClient:errorReceived:")]
		public override void ErrorReceived(TwilioIPMessagingClient client, Error error)
		{
			Console.WriteLine("IPMessagingDelegate.ErrorReceived(): " + error.Description);
		}
	}
}