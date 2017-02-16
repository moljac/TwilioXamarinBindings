namespace com.twilio.video.examples.customrenderer
{

	using Manifest = Android.Manifest;
	using Activity = Android.App.Activity;
	using PackageManager = Android.Content.PM.PackageManager;
	using Bundle = Android.OS.Bundle;
	using NonNull = Android.Support.Annotation.NonNull;
	using ActivityCompat = Android.Support.V4.App.ActivityCompat;
	using ContextCompat = Android.Support.V4.Content.ContextCompat;
	using View = Android.View.View;
	using ImageView = Android.Widget.ImageView;
	using TextView = Android.Widget.TextView;
	using Toast = Android.Widget.Toast;


	/// <summary>
	/// This example demonstrates how to implement a custom renderer. Here we render the contents
	/// of our <seealso cref="CameraCapturer"/> to a video view and to a snapshot renderer which allows user to
	/// grab the latest frame rendered. When the camera view is tapped the frame is updated.
	/// </summary>
	public class CustomRendererVideoActivity : Activity
	{
		private const int CAMERA_PERMISSION_REQUEST_CODE = 100;

		private LocalMedia localMedia;
		private VideoView localVideoView;
		private ImageView snapshotImageView;
		private TextView tapForSnapshotTextView;
		private SnapshotVideoRenderer snapshotVideoRenderer;
		private LocalVideoTrack localVideoTrack;

		public override void onCreate(Bundle savedInstanceState)
		{
			base.onCreate(savedInstanceState);
			ContentView = R.layout.activity_custom_renderer;

			localMedia = LocalMedia.create(this);
			localVideoView = (VideoView) findViewById(R.id.local_video);
			snapshotImageView = (ImageView) findViewById(R.id.image_view);
			tapForSnapshotTextView = (TextView) findViewById(R.id.tap_video_snapshot);

			/*
			 * Check camera permissions. Needed in Android M.
			 */
			if (!checkPermissionForCamera())
			{
				requestPermissionForCamera();
			}
			else
			{
				addVideo();
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override public void onRequestPermissionsResult(int requestCode, @NonNull String[] permissions, @NonNull int[] grantResults)
		public override void onRequestPermissionsResult(int requestCode, string[] permissions, int[] grantResults)
		{
			if (requestCode == CAMERA_PERMISSION_REQUEST_CODE)
			{
				bool cameraPermissionGranted = true;

				foreach (int grantResult in grantResults)
				{
					cameraPermissionGranted &= grantResult == PackageManager.PERMISSION_GRANTED;
				}

				if (cameraPermissionGranted)
				{
					addVideo();
				}
				else
				{
					Toast.makeText(this, R.@string.permissions_needed, Toast.LENGTH_LONG).show();
				}
			}
		}

		protected internal override void onDestroy()
		{
			localVideoTrack.removeRenderer(localVideoView);
			localVideoTrack.removeRenderer(snapshotVideoRenderer);
			localMedia.removeVideoTrack(localVideoTrack);
			localMedia.release();
			base.onDestroy();
		}

		private void addVideo()
		{
			localVideoTrack = localMedia.addVideoTrack(true, new CameraCapturer(this, CameraCapturer.CameraSource.FRONT_CAMERA, null));
			snapshotVideoRenderer = new SnapshotVideoRenderer(snapshotImageView);
			localVideoTrack.addRenderer(localVideoView);
			localVideoTrack.addRenderer(snapshotVideoRenderer);
			localVideoView.OnClickListener = new OnClickListenerAnonymousInnerClassHelper(this);
		}

		private class OnClickListenerAnonymousInnerClassHelper : View.OnClickListener
		{
			private readonly CustomRendererVideoActivity outerInstance;

			public OnClickListenerAnonymousInnerClassHelper(CustomRendererVideoActivity outerInstance)
			{
				this.outerInstance = outerInstance;
			}

			public override void onClick(View v)
			{
				outerInstance.tapForSnapshotTextView.Visibility = View.GONE;
				outerInstance.snapshotVideoRenderer.takeSnapshot();
			}
		}

		private bool checkPermissionForCamera()
		{
			int resultCamera = ContextCompat.checkSelfPermission(this, Manifest.permission.CAMERA);
			return resultCamera == PackageManager.PERMISSION_GRANTED;
		}

		private void requestPermissionForCamera()
		{
			ActivityCompat.requestPermissions(this, new string[]{Manifest.permission.CAMERA}, CAMERA_PERMISSION_REQUEST_CODE);
		}
	}

}