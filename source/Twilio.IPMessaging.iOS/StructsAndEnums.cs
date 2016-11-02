using System;
using ObjCRuntime;

namespace TwilioIPMessagingClient
{
	[Native]
	public enum /*mc++TWM*/ClientSynchronizationStrategy : ulong /*mc++ nint*/
	{
		All,
		ChannelsList
	}

	[Native]
	public enum /*mc++TWM*/ClientSynchronizationStatus : ulong /*mc++ nint*/
	{
		Started = 0,
		ChannelsListCompleted,
		Completed,
		Failed
	}

	[Native]
	public enum /*mc++TWM*/LogLevel : ulong /*mc++ nint*/
	{
		Fatal = 0,
		Critical,
		Warning,
		Info,
		Debug
	}

	[Native]
	public enum /*mc++TWM*/ChannelSynchronizationStatus : ulong /*mc++ nint*/
	{
		None = 0,
		Identifier,
		Metadata,
		All,
		Failed
	}

	[Native]
	public enum /*mc++TWM*/ChannelStatus : ulong /*mc++ nint*/
	{
		Invited = 0,
		Joined,
		NotParticipating
	}

	[Native]
	public enum /*mc++TWM*/ChannelType : ulong /*mc++ nint*/
	{
		ublic = 0,
		rivate
	}

	[Native]
	public enum /*mc++TWM*/UserInfoUpdate : ulong /*mc++ nint*/
	{
		FriendlyName = 0,
		Attributes,
		ReachabilityOnline,
		ReachabilityNotifiable
	}
}
