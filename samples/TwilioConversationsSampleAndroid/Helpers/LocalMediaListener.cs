using System;
namespace TwilioConversationsSampleAndroid
{
	internal partial class LocalMediaListener : Java.Lang.Object, Twilio.Conversations.LocalMedia.IListener
	{
		public void OnLocalVideoTrackAdded(Twilio.Conversations.LocalMedia p0, Twilio.Conversations.LocalVideoTrack p1)
		{
			throw new NotImplementedException();
		}

		public void OnLocalVideoTrackError(Twilio.Conversations.LocalMedia p0, Twilio.Conversations.LocalVideoTrack p1, Twilio.Conversations.TwilioConversationsException p2)
		{
			throw new NotImplementedException();
		}

		public void OnLocalVideoTrackRemoved(Twilio.Conversations.LocalMedia p0, Twilio.Conversations.LocalVideoTrack p1)
		{
			throw new NotImplementedException();
		}
	}
}
