using System;
using Foundation;
using ObjCRuntime;

namespace Twilio.IPMessaging
{
	// @interface TwilioAccessManager : NSObject
	[BaseType(typeof(NSObject))]
	interface TwilioAccessManager
	{
		[Wrap("WeakDelegate")]
		TwilioAccessManagerDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<TwilioAccessManagerDelegate> delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// +(instancetype)accessManagerWithToken:(NSString *)token delegate:(id<TwilioAccessManagerDelegate>)delegate;
		[Static]
		[Export("accessManagerWithToken:delegate:")]
		TwilioAccessManager AccessManagerWithToken(string token, TwilioAccessManagerDelegate @delegate);

		// -(void)updateToken:(NSString *)token;
		[Export("updateToken:")]
		void UpdateToken(string token);

		// -(NSString *)token;
		[Export("token")]
		//mc++ [Verify(MethodToProperty)]
		string Token { get; }

		// -(NSString *)identity;
		[Export("identity")]
		//mc++ [Verify(MethodToProperty)]
		string Identity { get; }

		// -(BOOL)isExpired;
		[Export("isExpired")]
		//mc++ [Verify(MethodToProperty)]
		bool IsExpired { get; }

		// -(NSDate *)expirationDate;
		[Export("expirationDate")]
		//mc++ [Verify(MethodToProperty)]
		NSDate ExpirationDate { get; }
	}

	// @protocol TwilioAccessManagerDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface TwilioAccessManagerDelegate
	{
		// @required -(void)accessManagerTokenExpired:(TwilioAccessManager *)accessManager;
		[Abstract]
		[Export("accessManagerTokenExpired:")]
		void AccessManagerTokenExpired(TwilioAccessManager accessManager);

		// @required -(void)accessManager:(TwilioAccessManager *)accessManager error:(NSError *)error;
		[Abstract]
		[Export("accessManager:error:")]
		void AccessManager(TwilioAccessManager accessManager, NSError error);
	}

	// @interface TWMError : NSError
	[BaseType(typeof(NSError))]
	interface TWMError
	{
	}

	// @interface TWMResult : NSObject
	[BaseType(typeof(NSObject))]
	interface TWMResult
	{
		// @property (readonly, nonatomic, strong) TWMError * error;
		[Export("error", ArgumentSemantic.Strong)]
		TWMError Error { get; }

		// -(BOOL)isSuccessful;
		[Export("isSuccessful")]
		//mc++ [Verify(MethodToProperty)]
		bool IsSuccessful { get; }
	}

	// typedef void (^TWMCompletion)(TWMResult *);
	delegate void TWMCompletion(TWMResult arg0);

	// typedef void (^TWMChannelListCompletion)(TWMResult *, TWMChannels *);
	delegate void TWMChannelListCompletion(TWMResult arg0, TWMChannels arg1);

	// typedef void (^TWMChannelCompletion)(TWMResult *, TWMChannel *);
	delegate void TWMChannelCompletion(TWMResult arg0, TWMChannel arg1);

	// typedef void (^TWMMessagesCompletion)(TWMResult *, NSArray<TWMMessage *> *);
	delegate void TWMMessagesCompletion(TWMResult arg0, TWMMessage[] arg1);

	[Static]
	//mc++ [Verify(ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const TWMChannelOptionFriendlyName;
		[Field("TWMChannelOptionFriendlyName", "__Internal")]
		NSString TWMChannelOptionFriendlyName { get; }

		// extern NSString *const TWMChannelOptionUniqueName;
		[Field("TWMChannelOptionUniqueName", "__Internal")]
		NSString TWMChannelOptionUniqueName { get; }

		// extern NSString *const TWMChannelOptionType;
		[Field("TWMChannelOptionType", "__Internal")]
		NSString TWMChannelOptionType { get; }

		// extern NSString *const TWMChannelOptionAttributes;
		[Field("TWMChannelOptionAttributes", "__Internal")]
		NSString TWMChannelOptionAttributes { get; }

		// extern NSString *const TWMErrorDomain;
		[Field("TWMErrorDomain", "__Internal")]
		NSString TWMErrorDomain { get; }

		// extern const NSInteger TWMErrorGeneric;
		[Field("TWMErrorGeneric", "__Internal")]
		nint TWMErrorGeneric { get; }

		// extern NSString *const TWMErrorMsgKey;
		[Field("TWMErrorMsgKey", "__Internal")]
		NSString TWMErrorMsgKey { get; }
	}

	// @interface TWMChannels : NSObject
	[BaseType(typeof(NSObject))]
	interface TWMChannels
	{
		// -(NSArray<TWMChannel *> *)allObjects;
		[Export("allObjects")]
		//mc++ [Verify(MethodToProperty)]
		TWMChannel[] AllObjects(); //mc++ { get; }

		// -(void)createChannelWithOptions:(NSDictionary *)options completion:(TWMChannelCompletion)completion;
		[Export("createChannelWithOptions:completion:")]
		void CreateChannelWithOptions(NSDictionary options, TWMChannelCompletion completion);

		// -(TWMChannel *)channelWithId:(NSString *)channelId;
		[Export("channelWithId:")]
		TWMChannel ChannelWithId(string channelId);

		// -(TWMChannel *)channelWithUniqueName:(NSString *)uniqueName;
		[Export("channelWithUniqueName:")]
		TWMChannel ChannelWithUniqueName(string uniqueName);
	}

	// @interface TWMMessage : NSObject
	[BaseType(typeof(NSObject))]
	interface TWMMessage
	{
		// @property (readonly, copy, nonatomic) NSString * sid;
		[Export("sid")]
		string Sid { get; }

		// @property (readonly, copy, nonatomic) NSNumber * index;
		[Export("index", ArgumentSemantic.Copy)]
		NSNumber Index { get; }

		// @property (readonly, copy, nonatomic) NSString * author;
		[Export("author")]
		string Author { get; }

		// @property (readonly, copy, nonatomic) NSString * body;
		[Export("body")]
		string Body { get; }

		// @property (readonly, copy, nonatomic) NSString * timestamp;
		[Export("timestamp")]
		string Timestamp { get; }

		// @property (readonly, nonatomic, strong) NSDate * timestampAsDate;
		[Export("timestampAsDate", ArgumentSemantic.Strong)]
		NSDate TimestampAsDate { get; }

		// @property (readonly, copy, nonatomic) NSString * dateUpdated;
		[Export("dateUpdated")]
		string DateUpdated { get; }

		// @property (readonly, nonatomic, strong) NSDate * dateUpdatedAsDate;
		[Export("dateUpdatedAsDate", ArgumentSemantic.Strong)]
		NSDate DateUpdatedAsDate { get; }

		// @property (readonly, copy, nonatomic) NSString * lastUpdatedBy;
		[Export("lastUpdatedBy")]
		string LastUpdatedBy { get; }

		// -(void)updateBody:(NSString *)body completion:(TWMCompletion)completion;
		[Export("updateBody:completion:")]
		void UpdateBody(string body, TWMCompletion completion);

		// -(NSDictionary<NSString *,id> *)attributes;
		[Export("attributes")]
		//mc++ [Verify(MethodToProperty)]
		NSDictionary<NSString, NSObject> Attributes { get; }

		// -(void)setAttributes:(NSDictionary<NSString *,id> *)attributes completion:(TWMCompletion)completion;
		[Export("setAttributes:completion:")]
		void SetAttributes(NSDictionary<NSString, NSObject> attributes, TWMCompletion completion);
	}

	// @interface TWMMessages : NSObject
	[BaseType(typeof(NSObject))]
	interface TWMMessages
	{
		// @property (readonly, copy, nonatomic) NSNumber * lastConsumedMessageIndex;
		[Export("lastConsumedMessageIndex", ArgumentSemantic.Copy)]
		NSNumber LastConsumedMessageIndex { get; }

		// -(TWMMessage *)createMessageWithBody:(NSString *)body;
		[Export("createMessageWithBody:")]
		TWMMessage CreateMessageWithBody(string body);

		// -(void)sendMessage:(TWMMessage *)message completion:(TWMCompletion)completion;
		[Export("sendMessage:completion:")]
		void SendMessage(TWMMessage message, TWMCompletion completion);

		// -(void)removeMessage:(TWMMessage *)message completion:(TWMCompletion)completion;
		[Export("removeMessage:completion:")]
		void RemoveMessage(TWMMessage message, TWMCompletion completion);

		// -(NSArray<TWMMessage *> *)allObjects;
		[Export("allObjects")]
		//mc++ [Verify(MethodToProperty)]
		TWMMessage[] AllObjects(); //mc++ { get; }

		// -(void)getLastMessagesWithCount:(NSUInteger)count completion:(TWMMessagesCompletion)completion;
		[Export("getLastMessagesWithCount:completion:")]
		void GetLastMessagesWithCount(nuint count, TWMMessagesCompletion completion);

		// -(void)getMessagesBefore:(NSUInteger)index withCount:(NSUInteger)count completion:(TWMMessagesCompletion)completion;
		[Export("getMessagesBefore:withCount:completion:")]
		void GetMessagesBefore(nuint index, nuint count, TWMMessagesCompletion completion);

		// -(void)getMessagesAfter:(NSUInteger)index withCount:(NSUInteger)count completion:(TWMMessagesCompletion)completion;
		[Export("getMessagesAfter:withCount:completion:")]
		void GetMessagesAfter(nuint index, nuint count, TWMMessagesCompletion completion);

		// -(TWMMessage *)messageWithIndex:(NSNumber *)index;
		[Export("messageWithIndex:")]
		TWMMessage MessageWithIndex(NSNumber index);

		// -(TWMMessage *)messageForConsumptionIndex:(NSNumber *)index;
		[Export("messageForConsumptionIndex:")]
		TWMMessage MessageForConsumptionIndex(NSNumber index);

		// -(void)setLastConsumedMessageIndex:(NSNumber *)index;
		[Export("setLastConsumedMessageIndex:")]
		void SetLastConsumedMessageIndex(NSNumber index);

		// -(void)advanceLastConsumedMessageIndex:(NSNumber *)index;
		[Export("advanceLastConsumedMessageIndex:")]
		void AdvanceLastConsumedMessageIndex(NSNumber index);

		// -(void)setAllMessagesConsumed;
		[Export("setAllMessagesConsumed")]
		void SetAllMessagesConsumed();

		// -(void)setNoMessagesConsumed;
		[Export("setNoMessagesConsumed")]
		void SetNoMessagesConsumed();
	}

	// @interface TWMUserInfo : NSObject
	[BaseType(typeof(NSObject))]
	interface TWMUserInfo
	{
		// @property (readonly, copy, nonatomic) NSString * identity;
		[Export("identity")]
		string Identity { get; }

		// @property (readonly, copy, nonatomic) NSString * friendlyName;
		[Export("friendlyName")]
		string FriendlyName { get; }

		// -(NSDictionary<NSString *,id> *)attributes;
		[Export("attributes")]
		//mc++ [Verify(MethodToProperty)]
		NSDictionary<NSString, NSObject> Attributes { get; }

		// -(void)setAttributes:(NSDictionary<NSString *,id> *)attributes completion:(TWMCompletion)completion;
		[Export("setAttributes:completion:")]
		void SetAttributes(NSDictionary<NSString, NSObject> attributes, TWMCompletion completion);

		// -(void)setFriendlyName:(NSString *)friendlyName completion:(TWMCompletion)completion;
		[Export("setFriendlyName:completion:")]
		void SetFriendlyName(string friendlyName, TWMCompletion completion);

		// -(BOOL)isOnline;
		[Export("isOnline")]
		//mc++ [Verify(MethodToProperty)]
		bool IsOnline { get; }

		// -(BOOL)isNotifiable;
		[Export("isNotifiable")]
		//mc++ [Verify(MethodToProperty)]
		bool IsNotifiable { get; }
	}

	// @interface TWMMember : NSObject
	[BaseType(typeof(NSObject))]
	interface TWMMember
	{
		// @property (readonly, nonatomic, strong) TWMUserInfo * userInfo;
		[Export("userInfo", ArgumentSemantic.Strong)]
		TWMUserInfo UserInfo { get; }

		// @property (readonly, copy, nonatomic) NSNumber * lastConsumedMessageIndex;
		[Export("lastConsumedMessageIndex", ArgumentSemantic.Copy)]
		NSNumber LastConsumedMessageIndex { get; }

		// @property (readonly, copy, nonatomic) NSString * lastConsumptionTimestamp;
		[Export("lastConsumptionTimestamp")]
		string LastConsumptionTimestamp { get; }

		// @property (readonly, nonatomic, strong) NSDate * lastConsumptionTimestampAsDate;
		[Export("lastConsumptionTimestampAsDate", ArgumentSemantic.Strong)]
		NSDate LastConsumptionTimestampAsDate { get; }
	}

	// @interface TWMMembers : NSObject
	[BaseType(typeof(NSObject))]
	interface TWMMembers
	{
		// -(NSArray<TWMMember *> *)allObjects;
		[Export("allObjects")]
		//mc++ [Verify(MethodToProperty)]
		TWMMember[] AllObjects(); //mc++ { get; }

		// -(void)addByIdentity:(NSString *)identity completion:(TWMCompletion)completion;
		[Export("addByIdentity:completion:")]
		void AddByIdentity(string identity, TWMCompletion completion);

		// -(void)inviteByIdentity:(NSString *)identity completion:(TWMCompletion)completion;
		[Export("inviteByIdentity:completion:")]
		void InviteByIdentity(string identity, TWMCompletion completion);

		// -(void)removeMember:(TWMMember *)member completion:(TWMCompletion)completion;
		[Export("removeMember:completion:")]
		void RemoveMember(TWMMember member, TWMCompletion completion);
	}

	// @interface TWMChannel : NSObject
	[BaseType(typeof(NSObject))]
	interface TWMChannel
	{
		[Wrap("WeakDelegate")]
		TWMChannelDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<TWMChannelDelegate> delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, copy, nonatomic) NSString * sid;
		[Export("sid")]
		string Sid { get; }

		// @property (readonly, copy, nonatomic) NSString * friendlyName;
		[Export("friendlyName")]
		string FriendlyName { get; }

		// @property (readonly, copy, nonatomic) NSString * uniqueName;
		[Export("uniqueName")]
		string UniqueName { get; }

		// @property (readonly, nonatomic, strong) TWMMessages * messages;
		[Export("messages", ArgumentSemantic.Strong)]
		TWMMessages Messages { get; }

		// @property (readonly, nonatomic, strong) TWMMembers * members;
		[Export("members", ArgumentSemantic.Strong)]
		TWMMembers Members { get; }

		// @property (readonly, assign, nonatomic) TWMChannelSynchronizationStatus synchronizationStatus;
		[Export("synchronizationStatus", ArgumentSemantic.Assign)]
		TWMChannelSynchronizationStatus SynchronizationStatus { get; }

		// @property (readonly, assign, nonatomic) TWMChannelStatus status;
		[Export("status", ArgumentSemantic.Assign)]
		TWMChannelStatus Status { get; }

		// @property (readonly, assign, nonatomic) TWMChannelType type;
		[Export("type", ArgumentSemantic.Assign)]
		TWMChannelType Type { get; }

		// @property (readonly, nonatomic, strong) NSString * dateCreated;
		[Export("dateCreated", ArgumentSemantic.Strong)]
		string DateCreated { get; }

		// @property (readonly, nonatomic, strong) NSDate * dateCreatedAsDate;
		[Export("dateCreatedAsDate", ArgumentSemantic.Strong)]
		NSDate DateCreatedAsDate { get; }

		// @property (readonly, nonatomic, strong) NSString * dateUpdated;
		[Export("dateUpdated", ArgumentSemantic.Strong)]
		string DateUpdated { get; }

		// @property (readonly, nonatomic, strong) NSDate * dateUpdatedAsDate;
		[Export("dateUpdatedAsDate", ArgumentSemantic.Strong)]
		NSDate DateUpdatedAsDate { get; }

		// -(void)synchronizeWithCompletion:(TWMCompletion)completion;
		[Export("synchronizeWithCompletion:")]
		void SynchronizeWithCompletion(TWMCompletion completion);

		// -(NSDictionary<NSString *,id> *)attributes;
		[Export("attributes")]
		//mc++ [Verify(MethodToProperty)]
		NSDictionary<NSString, NSObject> Attributes { get; }

		// -(void)setAttributes:(NSDictionary<NSString *,id> *)attributes completion:(TWMCompletion)completion;
		[Export("setAttributes:completion:")]
		void SetAttributes(NSDictionary<NSString, NSObject> attributes, TWMCompletion completion);

		// -(void)setFriendlyName:(NSString *)friendlyName completion:(TWMCompletion)completion;
		[Export("setFriendlyName:completion:")]
		void SetFriendlyName(string friendlyName, TWMCompletion completion);

		// -(void)setUniqueName:(NSString *)uniqueName completion:(TWMCompletion)completion;
		[Export("setUniqueName:completion:")]
		void SetUniqueName(string uniqueName, TWMCompletion completion);

		// -(void)joinWithCompletion:(TWMCompletion)completion;
		[Export("joinWithCompletion:")]
		void JoinWithCompletion(TWMCompletion completion);

		// -(void)declineInvitationWithCompletion:(TWMCompletion)completion;
		[Export("declineInvitationWithCompletion:")]
		void DeclineInvitationWithCompletion(TWMCompletion completion);

		// -(void)leaveWithCompletion:(TWMCompletion)completion;
		[Export("leaveWithCompletion:")]
		void LeaveWithCompletion(TWMCompletion completion);

		// -(void)destroyWithCompletion:(TWMCompletion)completion;
		[Export("destroyWithCompletion:")]
		void DestroyWithCompletion(TWMCompletion completion);

		// -(void)typing;
		[Export("typing")]
		void Typing();

		// -(TWMMember *)memberWithIdentity:(NSString *)identity;
		[Export("memberWithIdentity:")]
		TWMMember MemberWithIdentity(string identity);
	}

	// @protocol TWMChannelDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface TWMChannelDelegate
	{
		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channelChanged:(TWMChannel *)channel;
		[Export("ipMessagingClient:channelChanged:")]
		void ChannelChanged(TwilioIPMessagingClient client, TWMChannel channel);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channelDeleted:(TWMChannel *)channel;
		[Export("ipMessagingClient:channelDeleted:")]
		void ChannelDeleted(TwilioIPMessagingClient client, TWMChannel channel);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channel:(TWMChannel *)channel synchronizationStatusChanged:(TWMChannelSynchronizationStatus)status;
		[Export("ipMessagingClient:channel:synchronizationStatusChanged:")]
		void Channel(TwilioIPMessagingClient client, TWMChannel channel, TWMChannelSynchronizationStatus status);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channel:(TWMChannel *)channel memberJoined:(TWMMember *)member;
		[Export("ipMessagingClient:channel:memberJoined:")]
		void Channel(TwilioIPMessagingClient client, TWMChannel channel, TWMMember member);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channel:(TWMChannel *)channel memberChanged:(TWMMember *)member;
		[Export("ipMessagingClient:channel:memberChanged:")]
		//mc++ void Channel(TwilioIPMessagingClient client, TWMChannel channel, TWMMember member);
		void ChannelMemberChanged(TwilioIPMessagingClient client, TWMChannel channel, TWMMember member);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channel:(TWMChannel *)channel member:(TWMMember *)member userInfo:(TWMUserInfo *)userInfo updated:(TWMUserInfoUpdate)updated;
		[Export("ipMessagingClient:channel:member:userInfo:updated:")]
		//mc++ void Channel(TwilioIPMessagingClient client, TWMChannel channel, TWMMember member, TWMUserInfo userInfo, TWMUserInfoUpdate updated);
		void ChannelUserInfoUpdated(TwilioIPMessagingClient client, TWMChannel channel, TWMMember member, TWMUserInfo userInfo, TWMUserInfoUpdate updated);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channel:(TWMChannel *)channel memberLeft:(TWMMember *)member;
		[Export("ipMessagingClient:channel:memberLeft:")]
		//mc++ void Channel(TwilioIPMessagingClient client, TWMChannel channel, TWMMember member);
		void ChannelMemberLeft(TwilioIPMessagingClient client, TWMChannel channel, TWMMember member);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channel:(TWMChannel *)channel messageAdded:(TWMMessage *)message;
		[Export("ipMessagingClient:channel:messageAdded:")]
		//mc++ void Channel(TwilioIPMessagingClient client, TWMChannel channel, TWMMessage message);
		void ChannelMessageAdded(TwilioIPMessagingClient client, TWMChannel channel, TWMMessage message);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channel:(TWMChannel *)channel messageChanged:(TWMMessage *)message;
		[Export("ipMessagingClient:channel:messageChanged:")]
		//mc++ void Channel(TwilioIPMessagingClient client, TWMChannel channel, TWMMessage message);
		void ChannelMessageChanged(TwilioIPMessagingClient client, TWMChannel channel, TWMMessage message);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channel:(TWMChannel *)channel messageDeleted:(TWMMessage *)message;
		[Export("ipMessagingClient:channel:messageDeleted:")]
		void Channel(TwilioIPMessagingClient client, TWMChannel channel, TWMMessage message);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client typingStartedOnChannel:(TWMChannel *)channel member:(TWMMember *)member;
		[Export("ipMessagingClient:typingStartedOnChannel:member:")]
		void TypingStartedOnChannel(TwilioIPMessagingClient client, TWMChannel channel, TWMMember member);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client typingEndedOnChannel:(TWMChannel *)channel member:(TWMMember *)member;
		[Export("ipMessagingClient:typingEndedOnChannel:member:")]
		void TypingEndedOnChannel(TwilioIPMessagingClient client, TWMChannel channel, TWMMember member);
	}

	// @interface TwilioIPMessagingClient : NSObject
	[BaseType(typeof(NSObject))]
	interface TwilioIPMessagingClient
	{
		// @property (nonatomic, strong) TwilioAccessManager * accessManager;
		[Export("accessManager", ArgumentSemantic.Strong)]
		TwilioAccessManager AccessManager { get; set; }

		[Wrap("WeakDelegate")]
		TwilioIPMessagingClientDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<TwilioIPMessagingClientDelegate> delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) TWMUserInfo * userInfo;
		[Export("userInfo", ArgumentSemantic.Strong)]
		TWMUserInfo UserInfo { get; }

		// @property (readonly, assign, nonatomic) TWMClientSynchronizationStatus synchronizationStatus;
		[Export("synchronizationStatus", ArgumentSemantic.Assign)]
		TWMClientSynchronizationStatus SynchronizationStatus { get; }

		// +(TWMLogLevel)logLevel;
		// +(void)setLogLevel:(TWMLogLevel)logLevel;
		[Static]
		[Export("logLevel")]
		//mc++ [Verify(MethodToProperty)]
		TWMLogLevel LogLevel { get; set; }

		// +(TwilioIPMessagingClient *)ipMessagingClientWithAccessManager:(TwilioAccessManager *)accessManager properties:(TwilioIPMessagingClientProperties *)properties delegate:(id<TwilioIPMessagingClientDelegate>)delegate;
		[Static]
		[Export("ipMessagingClientWithAccessManager:properties:delegate:")]
		TwilioIPMessagingClient IpMessagingClientWithAccessManager(TwilioAccessManager accessManager, TwilioIPMessagingClientProperties properties, TwilioIPMessagingClientDelegate @delegate);

		// -(NSString *)version;
		[Export("version")]
		//mc++ [Verify(MethodToProperty)]
		string Version { get; }

		// -(TWMChannels *)channelsList;
		[Export("channelsList")]
		//mc++ [Verify(MethodToProperty)]
		TWMChannels ChannelsList { get; }

		// -(void)registerWithToken:(NSData *)token;
		[Export("registerWithToken:")]
		void RegisterWithToken(NSData token);

		// -(void)deregisterWithToken:(NSData *)token;
		[Export("deregisterWithToken:")]
		void DeregisterWithToken(NSData token);

		// -(void)handleNotification:(NSDictionary *)notification;
		[Export("handleNotification:")]
		void HandleNotification(NSDictionary notification);

		// -(BOOL)isReachabilityEnabled;
		[Export("isReachabilityEnabled")]
		//mc++ [Verify(MethodToProperty)]
		bool IsReachabilityEnabled { get; }

		// -(void)shutdown;
		[Export("shutdown")]
		void Shutdown();
	}

	// @interface TwilioIPMessagingClientProperties : NSObject
	[BaseType(typeof(NSObject))]
	interface TwilioIPMessagingClientProperties
	{
		// @property (assign, nonatomic) TWMClientSynchronizationStrategy synchronizationStrategy;
		[Export("synchronizationStrategy", ArgumentSemantic.Assign)]
		TWMClientSynchronizationStrategy SynchronizationStrategy { get; set; }

		// @property (assign, nonatomic) uint initialMessageCount;
		[Export("initialMessageCount")]
		uint InitialMessageCount { get; set; }

		// @property (copy, nonatomic) NSString * region;
		[Export("region")]
		string Region { get; set; }
	}

	// @protocol TwilioIPMessagingClientDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface TwilioIPMessagingClientDelegate
	{
		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client synchronizationStatusChanged:(TWMClientSynchronizationStatus)status;
		[Export("ipMessagingClient:synchronizationStatusChanged:")]
		//mc++ void IpMessagingClient(TwilioIPMessagingClient client, TWMClientSynchronizationStatus status);
		void IpMessagingClientStatusChanged(TwilioIPMessagingClient client, TWMClientSynchronizationStatus status);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channelAdded:(TWMChannel *)channel;
		[Export("ipMessagingClient:channelAdded:")]
		//mc++ void IpMessagingClient(TwilioIPMessagingClient client, TWMChannel channel);
		void IpMessagingClientChannelAdded(TwilioIPMessagingClient client, TWMChannel channel);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channelChanged:(TWMChannel *)channel;
		[Export("ipMessagingClient:channelChanged:")]
		//mc++ void IpMessagingClient(TwilioIPMessagingClient client, TWMChannel channel);
		void IpMessagingClientChannelChanged(TwilioIPMessagingClient client, TWMChannel channel);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channelDeleted:(TWMChannel *)channel;
		[Export("ipMessagingClient:channelDeleted:")]
		//mc++ void IpMessagingClient(TwilioIPMessagingClient client, TWMChannel channel);
		void IpMessagingClientChannelDeleted(TwilioIPMessagingClient client, TWMChannel channel);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channel:(TWMChannel *)channel synchronizationStatusChanged:(TWMChannelSynchronizationStatus)status;
		[Export("ipMessagingClient:channel:synchronizationStatusChanged:")]
		//mc++ void IpMessagingClient(TwilioIPMessagingClient client, TWMChannel channel, TWMChannelSynchronizationStatus status);
		void IpMessagingClientStatusChanged(TwilioIPMessagingClient client, TWMChannel channel, TWMChannelSynchronizationStatus status);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channel:(TWMChannel *)channel memberJoined:(TWMMember *)member;
		[Export("ipMessagingClient:channel:memberJoined:")]
		//mc++ void IpMessagingClient(TwilioIPMessagingClient client, TWMChannel channel, TWMMember member);
		void IpMessagingClientMemberJoined(TwilioIPMessagingClient client, TWMChannel channel, TWMMember member);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channel:(TWMChannel *)channel memberChanged:(TWMMember *)member;
		[Export("ipMessagingClient:channel:memberChanged:")]
		//mc++ void IpMessagingClient(TwilioIPMessagingClient client, TWMChannel channel, TWMMember member);
		void IpMessagingClientMemberChanged(TwilioIPMessagingClient client, TWMChannel channel, TWMMember member);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channel:(TWMChannel *)channel memberLeft:(TWMMember *)member;
		[Export("ipMessagingClient:channel:memberLeft:")]
		//mc++ void IpMessagingClient(TwilioIPMessagingClient client, TWMChannel channel, TWMMember member);
		void IpMessagingClientMemberLeft(TwilioIPMessagingClient client, TWMChannel channel, TWMMember member);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channel:(TWMChannel *)channel messageAdded:(TWMMessage *)message;
		[Export("ipMessagingClient:channel:messageAdded:")]
		//mc++ void IpMessagingClient(TwilioIPMessagingClient client, TWMChannel channel, TWMMessage message);
		void IpMessagingClientMessageAdded(TwilioIPMessagingClient client, TWMChannel channel, TWMMessage message);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channel:(TWMChannel *)channel messageChanged:(TWMMessage *)message;
		[Export("ipMessagingClient:channel:messageChanged:")]
		//mc++ void IpMessagingClient(TwilioIPMessagingClient client, TWMChannel channel, TWMMessage message);
		void IpMessagingClientMessageChanged(TwilioIPMessagingClient client, TWMChannel channel, TWMMessage message);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channel:(TWMChannel *)channel messageDeleted:(TWMMessage *)message;
		[Export("ipMessagingClient:channel:messageDeleted:")]
		//mc++ void IpMessagingClient(TwilioIPMessagingClient client, TWMChannel channel, TWMMessage message);
		void IpMessagingClientMessageDeleted(TwilioIPMessagingClient client, TWMChannel channel, TWMMessage message);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client errorReceived:(TWMError *)error;
		[Export("ipMessagingClient:errorReceived:")]
		//mc++ void IpMessagingClient(TwilioIPMessagingClient client, TWMError error);
		void IpMessagingClientErrorReceived(TwilioIPMessagingClient client, TWMError error);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client typingStartedOnChannel:(TWMChannel *)channel member:(TWMMember *)member;
		[Export("ipMessagingClient:typingStartedOnChannel:member:")]
		//mc++ void IpMessagingClient(TwilioIPMessagingClient client, TWMChannel channel, TWMMember member);
		void IpMessagingClientTypingStarted(TwilioIPMessagingClient client, TWMChannel channel, TWMMember member);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client typingEndedOnChannel:(TWMChannel *)channel member:(TWMMember *)member;
		[Export("ipMessagingClient:typingEndedOnChannel:member:")]
		//mc++ void IpMessagingClient(TwilioIPMessagingClient client, TWMChannel channel, TWMMember member);
		void IpMessagingClientTypingEnded(TwilioIPMessagingClient client, TWMChannel channel, TWMMember member);

		// @optional -(void)ipMessagingClientToastSubscribed:(TwilioIPMessagingClient *)client;
		[Export("ipMessagingClientToastSubscribed:")]
		void IpMessagingClientToastSubscribed(TwilioIPMessagingClient client);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client toastReceivedOnChannel:(TWMChannel *)channel message:(TWMMessage *)message;
		[Export("ipMessagingClient:toastReceivedOnChannel:message:")]
		//mc++ void IpMessagingClient(TwilioIPMessagingClient client, TWMChannel channel, TWMMessage message);
		void IpMessagingClientToastReceived(TwilioIPMessagingClient client, TWMChannel channel, TWMMessage message);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client toastRegistrationFailedWithError:(TWMError *)error;
		[Export("ipMessagingClient:toastRegistrationFailedWithError:")]
		//mc++ void IpMessagingClient(TwilioIPMessagingClient client, TWMError error);
		void IpMessagingClient(TwilioIPMessagingClient client, TWMError error);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client userInfo:(TWMUserInfo *)userInfo updated:(TWMUserInfoUpdate)updated;
		[Export("ipMessagingClient:userInfo:updated:")]
		//mc++ void IpMessagingClient(TwilioIPMessagingClient client, TWMUserInfo userInfo, TWMUserInfoUpdate updated);
		void IpMessagingClient(TwilioIPMessagingClient client, TWMUserInfo userInfo, TWMUserInfoUpdate updated);
	}
}
