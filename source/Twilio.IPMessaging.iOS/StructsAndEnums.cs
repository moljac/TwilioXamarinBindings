using System;
using ObjCRuntime;

namespace Twilio.IPMessaging
{
	[Native]
	public enum TWMClientSynchronizationStrategy : ulong //mc++ nint
	{
		All,
		ChannelsList
	}

	[Native]
	public enum TWMClientSynchronizationStatus : ulong //mc++ nint
	{
		Started = 0,
		ChannelsListCompleted,
		Completed,
		Failed
	}

	[Native]
	public enum TWMLogLevel : ulong //mc++ nint
	{
		Fatal = 0,
		Critical,
		Warning,
		Info,
		Debug
	}

	[Native]
	public enum TWMChannelSynchronizationStatus : ulong //mc++ nint
	{
		None = 0,
		Identifier,
		Metadata,
		All,
		Failed
	}

	[Native]
	public enum TWMChannelStatus : ulong //mc++ nint
	{
		Invited = 0,
		Joined,
		NotParticipating
	}

	[Native]
	public enum TWMChannelType : ulong //mc++ nint
	{
		ublic = 0,
		rivate
	}

	[Native]
	public enum TWMUserInfoUpdate : ulong //mc++ nint
	{
		FriendlyName = 0,
		Attributes,
		ReachabilityOnline,
		ReachabilityNotifiable
	}
}
