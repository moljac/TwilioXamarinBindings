using System;
using System.Runtime.InteropServices;
using CoreGraphics;
using ObjCRuntime;

namespace Twilio.Conversations
{
	[Native]
	public enum /*TWC*/MediaTrackState : ulong //mc++ nuint
	{
		Idle = 0,
		Starting,
		Started,
		Ending,
		Ended
	}

	[Native]
	public enum /*TWC*/VideoCaptureSource : ulong //mc++ nuint
	{
		FrontCamera = 0,
		BackCamera
	}

	[Native]
	public enum /*TWC*/InviteStatus : ulong //mc++ nuint
	{
		Pending = 0,
		Accepting,
		Accepted,
		Rejected,
		Cancelled,
		Failed
	}

	[Native]
	public enum /*TWC*/IceTransportPolicy : ulong //mc++ nuint
	{
		All = 0,
		Relay = 1
	}

	[Native]
	public enum /*TWC*/VideoOrientation : ulong //mc++ nuint
	{
		Up = 0,
		Left,
		Down,
		Right
	}

	static class CFunctions
	{
		// CGAffineTransform TWCVideoOrientationMakeTransform (TWCVideoOrientation orientation);
		[DllImport ("__Internal")]
		//mc++ [Verify (PlatformInvoke)]
		static extern CGAffineTransform TWCVideoOrientationMakeTransform (/*TWC*/VideoOrientation orientation);

		// BOOL TWCVideoOrientationIsRotated (TWCVideoOrientation orientation);
		[DllImport ("__Internal")]
		//mc++ [Verify (PlatformInvoke)]
		static extern bool /*TWC*/VideoOrientationIsRotated (/*TWC*/VideoOrientation orientation);

		// TWCAspectRatio TWCAspectRatioMake (NSUInteger numerator, NSUInteger denominator);
		[DllImport ("__Internal")]
		//mc++ [Verify (PlatformInvoke)]
		static extern /*TWC*/AspectRatio /*TWC*/AspectRatioMake (nuint numerator, nuint denominator);
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct /*TWC*/AspectRatio
	{
		public nuint numerator;

		public nuint denominator;
	}

	[Native]
	public enum /*TWC*/VideoRenderingType : ulong //mc++ nuint
	{
		Metal = 0,
		OpenGLES
	}

	[Native]
	public enum /*TWC*/ErrorCode : long //mc++ nuint
	{
		Unknown = -1,
		InvalidAuthData = 100,
		InvalidSIPAccount = 102,
		ClientRegistration = 103,
		InvalidConversation = 105,
		ConversationParticipantNotAvailable = 106,
		ConversationRejected = 107,
		ConversationIgnored = 108,
		ConversationFailed = 109,
		ConversationTerminated = 110,
		PeerConnectFailed = 111,
		InvalidParticipantAddresses = 112,
		ClientDisconnected = 200,
		ClientFailedToReconnect = 201,
		TooManyActiveConversations = 202,
		TooManyTracks = 300,
		InvalidVideoCapturer = 301,
		InvalidVideoTrack = 302,
		VideoFailed = 303,
		TrackOperationInProgress = 304,
		TrackAddFailed = 305
	}

	[Native]
	public enum /*TWC*/LogLevel : ulong //mc++ nuint
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
	public enum /*TWC*/LogModule : ulong //mc++ nuint
	{
		Core = 0,
		Platform,
		Signaling,
		WebRTC
	}

	[Native]
	public enum /*TWC*/AudioOutput : ulong //mc++ nuint
	{
		Default = 0,
		Speaker = 1,
		Receiver = 2,
		Application = 3
	}
}
