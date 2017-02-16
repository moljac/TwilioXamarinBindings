using System;
using System.Runtime.InteropServices;
using CoreGraphics;
using CoreVideo;
using ObjCRuntime;

namespace Twilio.Rooms
{
	[Native]
	public enum /*mc++TVI*/VideoOrientation : long //mc++ nuint
	{
		Up = 0,
		Left,
		Down,
		Right
	}

	static class CFunctions
	{
		// CGAffineTransform TVIVideoOrientationMakeTransform (TVIVideoOrientation orientation);
		[DllImport ("__Internal")]
		//mc++ [Verify (PlatformInvoke)]
		static extern CGAffineTransform /*mc++TVI*/VideoOrientationMakeTransform (/*mc++TVI*/VideoOrientation orientation);

		// BOOL TVIVideoOrientationIsRotated (TVIVideoOrientation orientation);
		[DllImport ("__Internal")]
		//mc++ [Verify (PlatformInvoke)]
		static extern bool /*mc++TVI*/VideoOrientationIsRotated (/*mc++TVI*/VideoOrientation orientation);

		// TVIAspectRatio TVIAspectRatioMake (NSUInteger numerator, NSUInteger denominator);
		[DllImport ("__Internal")]
		//mc++ [Verify (PlatformInvoke)]
		static extern /*mc++TVI*/AspectRatio /*mc++TVI*/AspectRatioMake (nuint numerator, nuint denominator);
	}

	[Native]
	public enum /*mc++TVI*/AudioOutput : long //mc++ nuint
	{
		ideoChatDefault = 0,
		ideoChatSpeaker,
		oiceChatDefault,
		oiceChatSpeaker
	}

	[Native]
	public enum /*mc++TVI*/TrackState : long //mc++ nuint
	{
		Ended = 0,
		Live
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct /*mc++TVI*/VideoFrame
	{
		public long timestamp;

		public unsafe /*mc++ CVImageBufferRef* */ IntPtr imageBuffer;

		public /*mc++TVI*/VideoOrientation orientation;
	}

	public enum /*mc++TVI*/PixelFormat : uint
	{
		TVIPixelFormat32ARGB = CVPixelFormatType.CV32ARGB, // kCVPixelFormatType_32ARGB
		TVIPixelFormat32BGRA = CVPixelFormatType.CV32BGRA, // kCVPixelFormatType_32BGRA,
		YUV420BiPlanarVideoRange = CVPixelFormatType.CV420YpCbCr8BiPlanarVideoRange, //kCVPixelFormatType_420YpCbCr8BiPlanarVideoRange,
		YUV420BiPlanarFullRange = CVPixelFormatType.CV420YpCbCr8BiPlanarFullRange, // kCVPixelFormatType_420YpCbCr8BiPlanarFullRange,
		YUV420PlanarVideoRange = CVPixelFormatType.CV420YpCbCr8Planar, // kCVPixelFormatType_420YpCbCr8Planar,
		YUV420PlanarFullRange = CVPixelFormatType.CV420YpCbCr8PlanarFullRange //kCVPixelFormatType_420YpCbCr8PlanarFullRange
	}

	[Native]
	public enum /*mc++TVI*/VideoCaptureSource : long //mc++ nuint
	{
		FrontCamera = 0,
		BackCameraWide,
		BackCameraTelephoto
	}

	[Native]
	public enum /*mc++TVI*/Error : long //mc++ nuint
	{
		Unknown = 0,
		Signaling,
		InvalidAccessToken
	}

	[Native]
	public enum /*mc++TVI*/IceTransportPolicy : long //mc++ nuint
	{
		All = 0,
		Relay = 1
	}

	[Native]
	public enum /*mc++TVI*/RoomState : long //mc++ nuint
	{
		Connecting = 0,
		Connected,
		Disconnected
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct /*mc++TVI*/AspectRatio
	{
		public nuint numerator;

		public nuint denominator;
	}

	[Native]
	public enum /*mc++TVI*/VideoRenderingType : long //mc++ nuint
	{
		Metal = 0,
		OpenGLES
	}

	[Native]
	public enum /*mc++TVI*/LogLevel : long //mc++ nuint
	{
		Off = 0,
		Fatal,
		Error,
		Warning,
		Info,
		Debug,
		Trace,
		All
	}

	[Native]
	public enum /*mc++TVI*/LogModule : long //mc++ nuint
	{
		Core = 0,
		Platform,
		Signaling,
		WebRTC
	}
}
