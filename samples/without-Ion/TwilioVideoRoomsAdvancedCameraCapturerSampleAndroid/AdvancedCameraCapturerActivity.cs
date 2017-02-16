namespace com.twilio.video.examples.advancedcameracapturer
{

	using Manifest = Android.Manifest;
	using Activity = Android.App.Activity;
	using AlertDialog = Android.App.AlertDialog;
	using DialogInterface = Android.Content.DialogInterface;
	using PackageManager = Android.Content.PM.PackageManager;
	using Bitmap = Android.Graphics.Bitmap;
	using BitmapFactory = Android.Graphics.BitmapFactory;
	using Camera = Android.Hardware.Camera;
	using Bundle = Android.OS.Bundle;
	using ActivityCompat = Android.Support.V4.App.ActivityCompat;
	using ContextCompat = Android.Support.V4.Content.ContextCompat;
	using View = Android.Views.View;
	using Button = Android.Widget.Button;
	using ImageView = Android.Widget.ImageView;
	using Toast = Android.Widget.Toast;


    using global::Twilio.Rooms;

    /// <summary>
    /// This example demonstrates advanced use cases of <seealso cref="com.twilio.video.CameraCapturer"/>. Current
    /// use cases shown are as follows:
    /// 
    /// <ol>
    ///     <li>Setting Custom <seealso cref="android.hardware.Camera.Parameters"/></li>
    ///     <li>Taking a picture while capturing</li>
    /// </ol>
    /// </summary>
    public class AdvancedCameraCapturerActivity : Activity
	{
		private const int CAMERA_PERMISSION_REQUEST_CODE = 100;

		private LocalMedia localMedia;
		private VideoView videoView;
		private Button toggleFlashButton;
		private Button takePictureButton;
		private ImageView pictureImageView;
		private AlertDialog pictureDialog;
		private CameraCapturer cameraCapturer;
		private LocalVideoTrack localVideoTrack;
		private bool flashOn = false;
		private readonly View.IOnClickListener toggleFlashButtonClickListener = new OnClickListenerAnonymousInnerClassHelper();

		private class OnClickListenerAnonymousInnerClassHelper : Java.Lang.Object, View.IOnClickListener
		{
			public OnClickListenerAnonymousInnerClassHelper()
			{
			}

			public override void OnClick(View v)
			{
				outerInstance.toggleFlash();
			}
		}
		private readonly View.OnClickListener takePictureButtonClickListener = new OnClickListenerAnonymousInnerClassHelper2();

		private class OnClickListenerAnonymousInnerClassHelper2 : Java.Lang.Object, View.IOnClickListener
		{
			public OnClickListenerAnonymousInnerClassHelper2()
			{
			}

			public override void OnClick(View v)
			{
				outerInstance.takePicture();
			}
		}

		/// <summary>
		/// An example of a <seealso cref="CameraParameterUpdater"/> that shows how to toggle the flash of a
		/// camera if supported by the device.
		/// </summary>
		private readonly CameraParameterUpdater flashToggler = new CameraParameterUpdaterAnonymousInnerClassHelper();

		private class CameraParameterUpdaterAnonymousInnerClassHelper : ICameraParameterUpdater
		{
			public CameraParameterUpdaterAnonymousInnerClassHelper()
			{
			}

			public override void Apply(Camera.Parameters parameters)
			{
				if (parameters.FlashMode != null)
				{
					string flashMode = outerInstance.flashOn ? Camera.Parameters.FlashModeOff : Camera.Parameters.FlashModeTorch;
					parameters.FlashMode = flashMode;
					outerInstance.flashOn = !outerInstance.flashOn;
				}
				else
				{
					Toast.MakeText(outerInstance, Resources.String.flash_not_supported, Android.Widget.ToastLength.Long)
                         .Show();
				}
			}
		}

		/// <summary>
		/// An example of a <seealso cref="com.twilio.video.CameraCapturer.PictureListener"/> that decodes the
		/// image to a <seealso cref="Bitmap"/> and shows the result in an alert dialog.
		/// </summary>
		private readonly CameraCapturer.PictureListener photographer = new PictureListenerAnonymousInnerClassHelper();

		private class PictureListenerAnonymousInnerClassHelper : CameraCapturer.PictureListener
		{
			public PictureListenerAnonymousInnerClassHelper()
			{
			}

			public override void OnShutter()
			{

			}

			public override void OnPictureTaken(sbyte[] bytes)
			{
				Bitmap bitmap = BitmapFactory.DecodeByteArray(bytes, 0, bytes.Length);

				if (bitmap != null)
				{
					outerInstance.showPicture(bitmap);
				}
				else
				{
					Toast.MakeText(outerInstance, Resources.String.take_picture_failed, Android.Widget.ToastLength.Long)
                         .Show();
				}
			}
		}

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_advanced_camera_capturer);

			localMedia = LocalMedia.create(this);
			videoView = FindViewById<VideoView>(Resource.Id.video_view);
			toggleFlashButton = FindViewById<Button>(Resource.Id.toggle_flash_button);
			takePictureButton = FindViewById<Button>(Resource.Id.take_picture_button);
			pictureImageView = LayoutInflater.inflate(Resource.Layout.picture_image_view, null);
			pictureDialog = (new AlertDialog.Builder(this)).SetView(pictureImageView)
                                                           .SetTitle(null)
                                                           .SetPositiveButton(Resources.String.close, 
                                                                              new OnClickListenerAnonymousInnerClassHelper(this)
                                                                             )
                                                           .create();

			if (!checkPermissionForCamera())
			{
				requestPermissionForCamera();
			}
			else
			{
				addCameraVideo();
			}
		}

		private class OnClickListenerAnonymousInnerClassHelper1 : DialogInterface.IOnClickListener
		{
			private readonly AdvancedCameraCapturerActivity outerInstance;

			public OnClickListenerAnonymousInnerClassHelper1(AdvancedCameraCapturerActivity outerInstance)
			{
				this.outerInstance = outerInstance;
			}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not available in .NET:
//ORIGINAL LINE: @Override public void onClick(final Android.Content.DialogInterface dialog, int which)
			public override void OnClick(DialogInterface dialog, int which)
			{
				dialog.Dismiss();
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override public void onRequestPermissionsResult(int requestCode, @NonNull String[] permissions, @NonNull int[] grantResults)
		public override void OnRequestPermissionsResult(int requestCode, string[] permissions, int[] grantResults)
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
					addCameraVideo();
				}
				else
				{
					Toast.makeText(this, Resources.String.permissions_needed, ToastLength.Long).Show();
					Finish();
				}
			}
		}

		protected override void OnDestroy()
		{
			localVideoTrack.RemoveRenderer(videoView);
			localMedia.RemoveVideoTrack(localVideoTrack);
			localMedia.Release();
			base.OnDestroy();
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

		private void addCameraVideo()
		{
			cameraCapturer = new CameraCapturer(this, CameraCapturer.CameraSource.BACK_CAMERA);
			localVideoTrack = localMedia.addVideoTrack(true, cameraCapturer);
			localVideoTrack.addRenderer(videoView);
			toggleFlashButton.OnClickListener = toggleFlashButtonClickListener;
			takePictureButton.OnClickListener = takePictureButtonClickListener;
		}

		private void toggleFlash()
		{
			// Request an update to camera parameters with flash toggler
			cameraCapturer.updateCameraParameters(flashToggler);
		}

		private void takePicture()
		{
			cameraCapturer.takePicture(photographer);
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not available in .NET:
//ORIGINAL LINE: private void showPicture(final Android.Graphics.Bitmap bitmap)
		private void showPicture(Bitmap bitmap)
		{
			pictureImageView.ImageBitmap = bitmap;
			pictureDialog.show();
		}
	}

}