using System;
using ObjCRuntime;

namespace Twilio.Voice
{
	[Native]
	public enum /*mc++ TVO*/LogLevel : ulong //mc++ nuint
	{
		Off = 0,
		Error,
		Warn,
		Info,
		Debug,
		Verbose
	}

	[Native]
	public enum /*mc++ TVO*/LogModule : ulong //mc++ nuint
	{
		Pjsip = 0,
		Notify
	}

	[Native]
	public enum /*mc++ TVO*/IncomingCallState : ulong //mc++ nuint
	{
		Pending = 0,
		Connecting,
		Connected,
		Disconnected,
		Cancelled
	}

	[Native]
	public enum /*mc++ TVO*/OutgoingCallState : ulong //mc++ nuint
	{
		Connecting = 0,
		Connected,
		Disconnected
	}
}
