namespace com.twilio.video.examples.screencapturer
{

	using Context = Android.Content.Context;
	using Intent = Android.Content.Intent;
	using MediaProjectionManager = Android.media.projection.MediaProjectionManager;
	using Bundle = Android.OS.Bundle;
	using AppCompatActivity = Android.Support.v7.app.AppCompatActivity;
	using Log = Android.util.Log;
	using Menu = Android.Views.Menu;
	using MenuInflater = Android.Views.MenuInflater;
	using MenuItem = Android.Views.MenuItem;
	using View = Android.Views.View;
	using Toast = Android.Widget.Toast;


	/// <summary>
	/// This example demonstrates how to use the screen capturer
	/// </summary>
	public class ScreenCapturerActivity : AppCompatActivity
	{
		private const string TAG = "ScreenCapturer";
		private const int REQUEST_MEDIA_PROJECTION = 100;

		private LocalMedia localMedia;
		private VideoView localVideoView;
		private LocalVideoTrack screenVideoTrack;
		private ScreenCapturer screenCapturer;
		private MenuItem screenCaptureMenuItem;
		private readonly ScreenCapturer.Listener screenCapturerListener = new ListenerAnonymousInnerClassHelper();

		private class ListenerAnonymousInnerClassHelper : ScreenCapturer.Listener
		{
			public ListenerAnonymousInnerClassHelper()
			{
			}

			public override void onScreenCaptureError(string errorDescription)
			{
				Log.e(TAG, "Screen capturer error: " + errorDescription);
				outerInstance.stopScreenCapture();
				Toast.makeText(outerInstance, Resources.String..screen_capture_error, Toast.LENGTH_LONG).show();
			}

			public override void onFirstFrameAvailable()
			{
				Log.d(TAG, "First frame from screen capturer available");
			}
		}

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			ContentView = Resource.Layout.activity_screen_capturer;
			localVideoView = (VideoView) FindViewById<>(Resource.Id.local_video);

			localMedia = LocalMedia.create(this);
		}

		public override bool onCreateOptionsMenu(Menu menu)
		{
			MenuInflater inflater = MenuInflater;
			inflater.inflate(R.menu.screen_menu, menu);
			return true;
		}

		public override bool onPrepareOptionsMenu(Menu menu)
		{
			// Grab menu items for updating later
			screenCaptureMenuItem = menu.findItem(Resource.Id.share_screen_menu_item);
			return true;
		}

		public override bool onOptionsItemSelected(MenuItem item)
		{
			switch (item.ItemId)
			{
				case Resource.Id.share_screen_menu_item:
					string shareScreen = getString(Resources.String..share_screen);

					if (item.Title.Equals(shareScreen))
					{
						if (screenCapturer == null)
						{
							requestScreenCapturePermission();
						}
						else
						{
							startScreenCapture();
						}
					}
					else
					{
						stopScreenCapture();
					}

					return true;
				default:
					return base.onOptionsItemSelected(item);
			}
		}

		private void requestScreenCapturePermission()
		{
			Log.d(TAG, "Requesting permission to capture screen");
			MediaProjectionManager mediaProjectionManager = (MediaProjectionManager) getSystemService(Context.MEDIA_PROJECTION_SERVICE);

			// This initiates a prompt dialog for the user to confirm screen projection.
			startActivityForResult(mediaProjectionManager.createScreenCaptureIntent(), REQUEST_MEDIA_PROJECTION);
		}

		public override void onActivityResult(int requestCode, int resultCode, Intent data)
		{
			if (requestCode == REQUEST_MEDIA_PROJECTION)
			{
				if (resultCode != AppCompatActivity.RESULT_OK)
				{
					Toast.makeText(this, Resources.String..screen_capture_permission_not_granted, Toast.LENGTH_LONG).show();
					return;
				}
				screenCapturer = new ScreenCapturer(this, resultCode, data, screenCapturerListener);
				startScreenCapture();
			}
		}

		private void startScreenCapture()
		{
			screenVideoTrack = localMedia.addVideoTrack(true, screenCapturer);
			screenCaptureMenuItem.Icon = R.drawable.ic_stop_screen_share_white_24dp;
			screenCaptureMenuItem.Title = Resources.String..stop_screen_share;

			localVideoView.Visibility = View.VISIBLE;
			screenVideoTrack.addRenderer(localVideoView);
		}

		private void stopScreenCapture()
		{
			localVideoView.Visibility = View.INVISIBLE;
			localMedia.removeVideoTrack(screenVideoTrack);

			screenCaptureMenuItem.Icon = R.drawable.ic_screen_share_white_24dp;
			screenCaptureMenuItem.Title = Resources.String..share_screen;
			screenVideoTrack.removeRenderer(localVideoView);
		}

		protected internal override void onDestroy()
		{
			if (localMedia != null)
			{
				if (screenVideoTrack != null)
				{
					localMedia.removeVideoTrack(screenVideoTrack);
				}
				localMedia.release();
				localMedia = null;
			}
			base.onDestroy();
		}

	}

}