using System;

namespace Twilio.Conversations
{
	public class VideoRendererObserver : Java.Lang.Object, Twilio.Conversations.IVideoRendererObserver
	{
		public Action FirstFrameHandler 
		{ 
			get; 
			set; 
		}
		public void OnFirstFrame()
		{
			FirstFrameHandler?.Invoke();
		}

		public Action<int, int, int> FrameDimensionsChangedHandler 
		{ 
			get; 
			set; 
		}
		public void OnFrameDimensionsChanged(int width, int height, int i)
		{
			FrameDimensionsChangedHandler?.Invoke(width, height, i);
		}
	}
}
