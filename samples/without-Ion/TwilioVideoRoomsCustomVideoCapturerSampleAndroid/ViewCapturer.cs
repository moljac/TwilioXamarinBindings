using System.Collections.Generic;

namespace TwilioVideoRoomsCustomVideoCapturerSampleAndroid
{

    using Bitmap = Android.Graphics.Bitmap;
    using Canvas = Android.Graphics.Canvas;
    using Handler = Android.OS.Handler;
    using Looper = Android.OS.Looper;
    using SystemClock = Android.OS.SystemClock;
    using View = Android.Views.View;


    using Twilio.Rooms;
    using Java.Util.Concurrent.Atomic;

    /// <summary>
    /// ViewCapturer demonstrates how to implement a custom <seealso cref="VideoCapturer"/>. This class
    /// captures the contents of a provided view and signals the <seealso cref="VideoCapturer.Listener"/> when
    /// the frame is available.
    /// </summary>
    public class ViewCapturer : VideoCapturer
	{
		private const int VIEW_CAPTURER_FRAMERATE_MS = 100;

		private readonly View view;
		private Handler handler = new Handler(Looper.MainLooper);
		private VideoCapturer.IListener videoCapturerListener;
		private AtomicBoolean started = new AtomicBoolean(false);
		private readonly Runnable viewCapturer = new RunnableAnonymousInnerClassHelper();

		private class RunnableAnonymousInnerClassHelper : Java.Lang.Runnable
		{
			public RunnableAnonymousInnerClassHelper()
			{
			}

			public virtual void Run()
			{
				bool dropFrame = outerInstance.view.Width == 0 || outerInstance.view.Height == 0;

				// Only capture the view if the dimensions have been established
				if (!dropFrame)
				{
					// Draw view into bitmap backed canvas
					int measuredWidth = View.MeasureSpec.MakeMeasureSpec(outerInstance.View.Width, View.MeasureSpec.EXACTLY);
					int measuredHeight = View.MeasureSpec.MakeMeasureSpec(outerInstance.View.Height, View.MeasureSpec.EXACTLY);
					outerInstance.View.Measure(measuredWidth, measuredHeight);
					outerInstance.View.Layout(0, 0, outerInstance.view.MeasuredWidth, outerInstance.view.MeasuredHeight);

					Bitmap viewBitmap = Bitmap.CreateBitmap(outerInstance.view.Width, outerInstance.view.Height, Bitmap.Config.ARGB_8888);
					Canvas viewCanvas = new Canvas(viewBitmap);
					outerInstance.view.draw(viewCanvas);

					// Extract the frame from the bitmap
					int bytes = viewBitmap.ByteCount;
					Java.Nio.ByteBuffer buffer = Java.Nio.ByteBuffer.Allocate(bytes);
					viewBitmap.CopyPixelsToBuffer(buffer);
					sbyte[] array = buffer.Array();
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final long captureTimeNs = java.util.concurrent.TimeUnit.MILLISECONDS.toNanos(Android.OS.SystemClock.elapsedRealtime());
					long captureTimeNs = Java.Util.Concurrent.TimeUnit.Milliseconds.ToNanos(SystemClock.ElapsedRealtime());

					// Create video frame
					VideoDimensions dimensions = new VideoDimensions(outerInstance.view.Width, outerInstance.view.Height);
					VideoFrame videoFrame = new VideoFrame(array, dimensions, 0, captureTimeNs);

					// Notify the listener
					if (outerInstance.started.get())
					{
						outerInstance.videoCapturerListener.onFrameCaptured(videoFrame);
					}
				}

				// Schedule the next capture
				if (outerInstance.started.get())
				{
					outerInstance.handler.postDelayed(this, VIEW_CAPTURER_FRAMERATE_MS);
				}
			}
		}

		public ViewCapturer(View view)
		{
			this.view = view;
		}

		/// <summary>
		/// Returns the list of supported formats for this view capturer. Currently, only supports
		/// capturing to RGBA_8888 bitmaps.
		/// </summary>
		/// <returns> list of supported formats. </returns>
		public override IList<VideoFormat> SupportedFormats
		{
			get
			{
				IList<VideoFormat> videoFormats = new List<VideoFormat>();
				VideoDimensions videoDimensions = new VideoDimensions(view.Width, view.Height);
				VideoFormat videoFormat = new VideoFormat(videoDimensions, 30, VideoPixelFormat.RGBA_8888);
    
				videoFormats.Add(videoFormat);
    
				return videoFormats;
			}
		}

		/// <summary>
		/// Returns true because we are capturing screen content.
		/// </summary>
		public override bool Screencast
		{
			get
			{
				return true;
			}
		}

		/// <summary>
		/// This will be invoked when it is time to start capturing frames.
		/// </summary>
		/// <param name="videoFormat"> the video format of the frames to be captured. </param>
		/// <param name="listener"> capturer listener. </param>
		public override void StartCapture(VideoFormat videoFormat, Listener listener)
		{
			// Store the capturer listener
			this.videoCapturerListener = listener;
			this.started.Set(true);

			// Notify capturer API that the capturer has started
			bool capturerStarted = handler.PostDelayed(viewCapturer, VIEW_CAPTURER_FRAMERATE_MS);
			this.videoCapturerListener.onCapturerStarted(capturerStarted);
		}

		/// <summary>
		/// Stop capturing frames. Note that the SDK cannot receive frames once this has been invoked.
		/// </summary>
		public override void StopCapture()
		{
			this.Started = false;
			handler.RemoveCallbacks(viewCapturer);
		}
	}

}