using System;

namespace TwilioIPMessagingSample
{
	public class CreateChannelListener : Twilio.IPMessaging.ConstantsCreateChannelListener
	{
		Twilio.IPMessaging.Channel generalChannel;

		public CreateChannelListener(Twilio.IPMessaging.Channel c)
		{
			generalChannel = c;

			OnCreatedHandler = channel =>
			{
				generalChannel = channel;
				channel.SetUniqueName("general", new ConstantsStatusListener
				{
					OnSuccess/*Handler*/ = () => { Console.WriteLine("set unique name successfully!"); }
				});
				this.JoinGeneralChannel();
			};

			OnErrorHandler = () => { };

		}

		public Action<Twilio.IPMessaging.Channel> OnCreatedHandler { get; set; }
		public Action OnErrorHandler { get; set; }

		public override void OnCreated(Twilio.IPMessaging.Channel p0)
		{
			OnCreatedHandler?.Invoke(p0);
		}

		public override void OnError(Twilio.IPMessaging.ErrorInfo errorInfo)
		{
			base.OnError(errorInfo);
		}


		void JoinGeneralChannel()
		{
			generalChannel.Join(new /*Constants.StatusListener*/ ConstantsStatusListener
			{
			});
		}

	}
}
