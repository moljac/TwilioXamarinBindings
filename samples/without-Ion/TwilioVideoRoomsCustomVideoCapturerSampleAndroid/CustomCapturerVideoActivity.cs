namespace TwilioVideoRoomsCustomVideoCapturerSampleAndroid
{

	using Activity = Android.App.Activity;
	using Bundle = Android.OS.Bundle;
	using Chronometer = Android.Widget.Chronometer;
	using LinearLayout = Android.Widget.LinearLayout;


	/// <summary>
	/// This example demonstrates how to implement a custom capturer. Here we capture the contents
	/// of a LinearLayout using <seealso cref="ViewCapturer"/>. To validate we render the video frames in a
	/// <seealso cref="VideoView"/> below.
	/// </summary>
	public class CustomCapturerVideoActivity : Activity
	{
		private LocalMedia localMedia;
		private LinearLayout capturedView;
		private VideoView videoView;
		private Chronometer timerView;
		private LocalVideoTrack localVideoTrack;

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			ContentView = Resource.Layout.activity_custom_capturer;

			localMedia = LocalMedia.create(this);
			capturedView = (LinearLayout) FindViewById<>(Resource.Id.captured_view);
			videoView = (VideoView) FindViewById<>(Resource.Id.video_view);
			timerView = (Chronometer) FindViewById<>(Resource.Id.timer_view);
			timerView.start();

			// Once added we should see our linear layout rendered live below
			localVideoTrack = localMedia.addVideoTrack(true, new ViewCapturer(capturedView));
			localVideoTrack.addRenderer(videoView);
		}

		protected internal override void onDestroy()
		{
			localVideoTrack.removeRenderer(videoView);
			localMedia.removeVideoTrack(localVideoTrack);
			timerView.stop();
			localMedia.release();
			base.onDestroy();
		}
	}

}