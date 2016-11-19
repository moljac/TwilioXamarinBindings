using System;
using ObjCRuntime;

namespace Twilio.Voice
{
	[Native]
	public enum TVOLogLevel : nuint
	{
		Off = 0,
		Error,
		Warn,
		Info,
		Debug,
		Verbose
	}

	[Native]
	public enum TVOLogModule : nuint
	{
		Pjsip = 0,
		Notify
	}

	[Native]
	public enum TVOIncomingCallState : nuint
	{
		Pending = 0,
		Connecting,
		Connected,
		Disconnected,
		Cancelled
	}

	[Native]
	public enum TVOOutgoingCallState : nuint
	{
		Connecting = 0,
		Connected,
		Disconnected
	}
}
