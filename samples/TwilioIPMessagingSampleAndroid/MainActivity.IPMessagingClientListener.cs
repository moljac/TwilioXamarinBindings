using Android.App;
using Android.Widget;
using Android.OS;
using Android.Runtime;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Android.Content;

using Twilio.Common;
using Twilio.IPMessaging;

namespace TwilioIPMessagingSample
{
	public partial class MainActivity : IPMessagingClientListener
	{
		public void OnChannelAdd(Channel channel)
		{

		}

		public void OnChannelChange(Channel channel)
		{
			//Android.Util.Log.Debug (TAG, "Channel Changed");
			//adapter.UpdateMessages (channel.Messages.GetMessages ());
		}
		public void OnChannelDelete(Channel channel)
		{
		}
		public void OnChannelHistoryLoaded(Channel channel)
		{
			Android.Util.Log.Debug(TAG, "Channel History Loaded");
			adapter.UpdateMessages(channel.Messages.GetMessages());
			listView.SmoothScrollToPosition(adapter.Count - 1);
		}
	}
}
