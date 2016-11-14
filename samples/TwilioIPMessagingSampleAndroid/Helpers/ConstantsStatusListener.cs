using System;
namespace TwilioIPMessagingSample
{
	public class ConstantsStatusListener : Twilio.IPMessaging.ConstantsStatusListener
	{
		public ConstantsStatusListener()
		{
			/*
			OnSuccessHandler = () =>
			{
				RunOnUiThread(() =>
				{
					textMessage.Text = string.Empty;
				});
			};
			*/
		}

		public override void OnSuccess()
		{
			/*
			RunOnUiThread
				(
					() =>
				);
			*/

			Android.App.Application.SynchronizationContext.Post
				(
					_ => 
					{
						/* invoked on UI thread */
						Android.Widget.Toast.MakeText
							(
								   Android.App.Application.Context,
								   "Joined general channel!",
								   Android.Widget.ToastLength.Short
							).Show();
					},
		           null
				);
		}
	}
}
