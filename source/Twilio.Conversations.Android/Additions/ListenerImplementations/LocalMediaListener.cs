using System;

namespace Twilio.Conversations
{
	public partial class LocalMediaListener : Java.Lang.Object, Twilio.Conversations.LocalMedia.IListener
	{
		public Action<LocalMedia, LocalVideoTrack> LocalVideoTrackAddedHandler 
		{ 
			get; 
			set; 
		}
		public void OnLocalVideoTrackAdded(LocalMedia media, LocalVideoTrack videoTrack)
		{
			LocalVideoTrackAddedHandler?.Invoke(media, videoTrack);
		}

		public Action<LocalMedia, LocalVideoTrack, TwilioConversationsException> LocalVideoTrackErrorHandler
		{
			get; 
			set;
		}
		public void OnLocalVideoTrackError(LocalMedia media, LocalVideoTrack videoTrack, TwilioConversationsException error)
		{
			LocalVideoTrackErrorHandler?.Invoke(media, videoTrack, error);
		}

		public Action<LocalMedia, LocalVideoTrack> LocalVideoTrackRemovedHandler 
		{ 
			get; 
			set; 
		}
		public void OnLocalVideoTrackRemoved(LocalMedia media, LocalVideoTrack videoTrack)
		{
			LocalVideoTrackRemovedHandler?.Invoke(media, videoTrack);
		}

		public string StatusText
		{
			get;
			set;
		}

		public Twilio.Conversations.VideoViewRenderer LocalVideoRenderer;
		public Android.Views.ViewGroup LocalContainer;
		public Android.Content.Context Context;
		public Android.Widget.TextView ConversationStatusTextView;

		public LocalMediaListener()
		{
			LocalVideoTrackAddedHandler = (conversation, localVideoTrack) =>
			{
				ConversationStatusTextView.Text = "onLocalVideoTrackAdded";
				LocalVideoRenderer = new Twilio.Conversations.VideoViewRenderer(Context, LocalContainer);
				localVideoTrack.AddRenderer(LocalVideoRenderer);
			};

			LocalVideoTrackRemovedHandler = (conversation, localVideoTrack) =>
			{
				ConversationStatusTextView.Text = "onLocalVideoTrackRemoved";
				LocalContainer.RemoveAllViews();
			};
		}

		/*
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
		*/
	}
}
