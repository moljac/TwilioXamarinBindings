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
	[BaseType(typeof(NSError), Name = "TWMError")]
	//mc++ [BaseType(typeof(NSError))]
	interface /*mc++ TWM*/Error
	{
	}

	// @interface TWMResult : NSObject
	[BaseType(typeof(NSObject), Name = "TWMResult")]
	//mc++ [BaseType(typeof(NSObject))]
	interface /*mc++ TWM*/Result
	{
		// @property (readonly, nonatomic, strong) TWMError * error;
		[Export("error", ArgumentSemantic.Strong)]
		/*mc++ TWM*/Error Error { get; }

		// -(BOOL)isSuccessful;
		[Export("isSuccessful")]
		//mc++ [Verify(MethodToProperty)]
		bool IsSuccessful { get; }
	}

	// typedef void (^TWMCompletion)(TWMResult *);
	delegate void /*mc++ TWM*/Completion(/*mc++ TWM*/Result arg0);

	// typedef void (^TWMChannelListCompletion)(TWMResult *, TWMChannels *);
	delegate void /*mc++ TWM*/ChannelListCompletion(/*mc++ TWM*/Result arg0, /*mc++ TWM*/Channels arg1);

	// typedef void (^TWMChannelCompletion)(TWMResult *, TWMChannel *);
	delegate void /*mc++ TWM*/ChannelCompletion(/*mc++ TWM*/Result arg0, /*mc++ TWM*/Channel arg1);

	// typedef void (^TWMMessagesCompletion)(TWMResult *, NSArray<TWMMessage *> *);
	delegate void /*mc++ TWM*/MessagesCompletion(/*mc++ TWM*/Result arg0, /*mc++ TWM*/Message[] arg1);

	[Static]
	//mc++ [Verify(ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const TWMChannelOptionFriendlyName;
		[Field("TWMChannelOptionFriendlyName", "__Internal")]
		NSString /*mc++ TWM*/ChannelOptionFriendlyName { get; }

		// extern NSString *const TWMChannelOptionUniqueName;
		[Field("TWMChannelOptionUniqueName", "__Internal")]
		NSString /*mc++ TWM*/ChannelOptionUniqueName { get; }

		// extern NSString *const TWMChannelOptionType;
		[Field("TWMChannelOptionType", "__Internal")]
		NSString /*mc++ TWM*/ChannelOptionType { get; }

		// extern NSString *const TWMChannelOptionAttributes;
		[Field("TWMChannelOptionAttributes", "__Internal")]
		NSString /*mc++ TWM*/ChannelOptionAttributes { get; }

		// extern NSString *const TWMErrorDomain;
		[Field("TWMErrorDomain", "__Internal")]
		NSString /*mc++ TWM*/ErrorDomain { get; }

		// extern const NSInteger TWMErrorGeneric;
		[Field("TWMErrorGeneric", "__Internal")]
		nint /*mc++ TWM*/ErrorGeneric { get; }

		// extern NSString *const TWMErrorMsgKey;
		[Field("TWMErrorMsgKey", "__Internal")]
		NSString /*mc++ TWM*/ErrorMsgKey { get; }
	}

	// @interface TWMChannels : NSObject
	[BaseType(typeof(NSObject), Name = "TWMChannels")]
	//mc++ [BaseType(typeof(NSObject))]
	interface /*mc++ TWM*/Channels
	{
		// -(NSArray<TWMChannel *> *)allObjects;
		[Export("allObjects")]
		//mc++ [Verify(MethodToProperty)]
		/*mc++ TWM*/Channel[] AllObjects(); //mc++ { get; }

		// -(void)createChannelWithOptions:(NSDictionary *)options completion:(TWMChannelCompletion)completion;
		[Export("createChannelWithOptions:completion:")]
		void CreateChannelWithOptions(NSDictionary options, /*mc++ TWM*/ChannelCompletion completion);

		// -(TWMChannel *)channelWithId:(NSString *)channelId;
		[Export("channelWithId:")]
		/*mc++ TWM*/Channel ChannelWithId(string channelId);

		// -(TWMChannel *)channelWithUniqueName:(NSString *)uniqueName;
		[Export("channelWithUniqueName:")]
		/*mc++ TWM*/Channel ChannelWithUniqueName(string uniqueName);
	}

	// @interface TWMMessage : NSObject
	[BaseType(typeof(NSObject), Name = "TWMMessage")]
	//mc++ [BaseType(typeof(NSObject))]
	interface /*mc++ TWM*/Message
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
		void UpdateBody(string body, /*mc++ TWM*/Completion completion);

		// -(NSDictionary<NSString *,id> *)attributes;
		[Export("attributes")]
		//mc++ [Verify(MethodToProperty)]
		NSDictionary<NSString, NSObject> Attributes { get; }

		// -(void)setAttributes:(NSDictionary<NSString *,id> *)attributes completion:(TWMCompletion)completion;
		[Export("setAttributes:completion:")]
		void SetAttributes(NSDictionary<NSString, NSObject> attributes, /*mc++ TWM*/Completion completion);
	}

	// @interface TWMMessages : NSObject
	[BaseType(typeof(NSObject), Name = "TWMMessages")]
	//mc++ [BaseType(typeof(NSObject))]
	interface /*mc++ TWM*/Messages
	{
		// @property (readonly, copy, nonatomic) NSNumber * lastConsumedMessageIndex;
		[Export("lastConsumedMessageIndex", ArgumentSemantic.Copy)]
		NSNumber LastConsumedMessageIndex { get; }

		// -(TWMMessage *)createMessageWithBody:(NSString *)body;
		[Export("createMessageWithBody:")]
		/*mc++ TWM*/Message CreateMessageWithBody(string body);

		// -(void)sendMessage:(TWMMessage *)message completion:(TWMCompletion)completion;
		[Export("sendMessage:completion:")]
		void SendMessage(/*mc++ TWM*/Message message, /*mc++ TWM*/Completion completion);

		// -(void)removeMessage:(TWMMessage *)message completion:(TWMCompletion)completion;
		[Export("removeMessage:completion:")]
		void RemoveMessage(/*mc++ TWM*/Message message, /*mc++ TWM*/Completion completion);

		// -(NSArray<TWMMessage *> *)allObjects;
		[Export("allObjects")]
		//mc++ [Verify(MethodToProperty)]
		/*mc++ TWM*/Message[] AllObjects(); //mc++ { get; }

		// -(void)getLastMessagesWithCount:(NSUInteger)count completion:(TWMMessagesCompletion)completion;
		[Export("getLastMessagesWithCount:completion:")]
		void GetLastMessagesWithCount(nuint count, /*mc++ TWM*/MessagesCompletion completion);

		// -(void)getMessagesBefore:(NSUInteger)index withCount:(NSUInteger)count completion:(TWMMessagesCompletion)completion;
		[Export("getMessagesBefore:withCount:completion:")]
		void GetMessagesBefore(nuint index, nuint count, /*mc++ TWM*/MessagesCompletion completion);

		// -(void)getMessagesAfter:(NSUInteger)index withCount:(NSUInteger)count completion:(TWMMessagesCompletion)completion;
		[Export("getMessagesAfter:withCount:completion:")]
		void GetMessagesAfter(nuint index, nuint count, /*mc++ TWM*/MessagesCompletion completion);

		// -(TWMMessage *)messageWithIndex:(NSNumber *)index;
		[Export("messageWithIndex:")]
		/*mc++ TWM*/Message MessageWithIndex(NSNumber index);

		// -(TWMMessage *)messageForConsumptionIndex:(NSNumber *)index;
		[Export("messageForConsumptionIndex:")]
		/*mc++ TWM*/Message MessageForConsumptionIndex(NSNumber index);

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
	[BaseType(typeof(NSObject), Name = "TWMUserInfo")]
	//mc++ [BaseType(typeof(NSObject))]
	interface /*mc++ TWM*/UserInfo
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
		void SetAttributes(NSDictionary<NSString, NSObject> attributes, /*mc++ TWM*/Completion completion);

		// -(void)setFriendlyName:(NSString *)friendlyName completion:(TWMCompletion)completion;
		[Export("setFriendlyName:completion:")]
		void SetFriendlyName(string friendlyName, /*mc++ TWM*/Completion completion);

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
	[BaseType(typeof(NSObject), Name = "TWMMember")]
	//mc++ [BaseType(typeof(NSObject))]
	interface /*mc++ TWM*/Member
	{
		// @property (readonly, nonatomic, strong) TWMUserInfo * userInfo;
		[Export("userInfo", ArgumentSemantic.Strong)]
		/*mc++ TWM*/UserInfo UserInfo { get; }

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
	[BaseType(typeof(NSObject), Name = "TWMMembers")]
	//mc++ [BaseType(typeof(NSObject))]
	interface /*mc++ TWM*/Members
	{
		// -(NSArray<TWMMember *> *)allObjects;
		[Export("allObjects")]
		//mc++ [Verify(MethodToProperty)]
		/*mc++ TWM*/Member[] AllObjects(); //mc++ { get; }

		// -(void)addByIdentity:(NSString *)identity completion:(TWMCompletion)completion;
		[Export("addByIdentity:completion:")]
		void AddByIdentity(string identity, /*mc++ TWM*/Completion completion);

		// -(void)inviteByIdentity:(NSString *)identity completion:(TWMCompletion)completion;
		[Export("inviteByIdentity:completion:")]
		void InviteByIdentity(string identity, /*mc++ TWM*/Completion completion);

		// -(void)removeMember:(TWMMember *)member completion:(TWMCompletion)completion;
		[Export("removeMember:completion:")]
		void RemoveMember(/*mc++ TWM*/Member member, /*mc++ TWM*/Completion completion);
	}

	// @interface TWMChannel : NSObject
	[BaseType(typeof(NSObject), Name = "TWMChannel")]
	//mc++ [BaseType(typeof(NSObject))]
	interface /*mc++ TWM*/Channel
	{
		[Wrap("WeakDelegate")]
		/*mc++ TWM*/ChannelDelegate Delegate { get; set; }

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
		/*mc++ TWM*/Messages Messages { get; }

		// @property (readonly, nonatomic, strong) TWMMembers * members;
		[Export("members", ArgumentSemantic.Strong)]
		/*mc++ TWM*/Members Members { get; }

		// @property (readonly, assign, nonatomic) TWMChannelSynchronizationStatus synchronizationStatus;
		[Export("synchronizationStatus", ArgumentSemantic.Assign)]
		/*mc++ TWM*/ChannelSynchronizationStatus SynchronizationStatus { get; }

		// @property (readonly, assign, nonatomic) TWMChannelStatus status;
		[Export("status", ArgumentSemantic.Assign)]
		/*mc++ TWM*/ChannelStatus Status { get; }

		// @property (readonly, assign, nonatomic) TWMChannelType type;
		[Export("type", ArgumentSemantic.Assign)]
		/*mc++ TWM*/ChannelType Type { get; }

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
		void SynchronizeWithCompletion(/*mc++ TWM*/Completion completion);

		// -(NSDictionary<NSString *,id> *)attributes;
		[Export("attributes")]
		//mc++ [Verify(MethodToProperty)]
		NSDictionary<NSString, NSObject> Attributes { get; }

		// -(void)setAttributes:(NSDictionary<NSString *,id> *)attributes completion:(TWMCompletion)completion;
		[Export("setAttributes:completion:")]
		void SetAttributes(NSDictionary<NSString, NSObject> attributes, /*mc++ TWM*/Completion completion);

		// -(void)setFriendlyName:(NSString *)friendlyName completion:(TWMCompletion)completion;
		[Export("setFriendlyName:completion:")]
		void SetFriendlyName(string friendlyName, /*mc++ TWM*/Completion completion);

		// -(void)setUniqueName:(NSString *)uniqueName completion:(TWMCompletion)completion;
		[Export("setUniqueName:completion:")]
		void SetUniqueName(string uniqueName, /*mc++ TWM*/Completion completion);

		// -(void)joinWithCompletion:(TWMCompletion)completion;
		[Export("joinWithCompletion:")]
		void JoinWithCompletion(/*mc++ TWM*/Completion completion);

		// -(void)declineInvitationWithCompletion:(TWMCompletion)completion;
		[Export("declineInvitationWithCompletion:")]
		void DeclineInvitationWithCompletion(/*mc++ TWM*/Completion completion);

		// -(void)leaveWithCompletion:(TWMCompletion)completion;
		[Export("leaveWithCompletion:")]
		void LeaveWithCompletion(/*mc++ TWM*/Completion completion);

		// -(void)destroyWithCompletion:(TWMCompletion)completion;
		[Export("destroyWithCompletion:")]
		void DestroyWithCompletion(/*mc++ TWM*/Completion completion);

		// -(void)typing;
		[Export("typing")]
		void Typing();

		// -(TWMMember *)memberWithIdentity:(NSString *)identity;
		[Export("memberWithIdentity:")]
		/*mc++ TWM*/Member MemberWithIdentity(string identity);
	}

	// @protocol TWMChannelDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject), Name = "TWMChannelDelegate")]
	//mc++ [BaseType(typeof(NSObject))]
	interface /*mc++ TWM*/ChannelDelegate
	{
		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channelChanged:(TWMChannel *)channel;
		[Export("ipMessagingClient:channelChanged:")]
		void ChannelChanged(TwilioIPMessagingClient client, /*mc++ TWM*/Channel channel);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channelDeleted:(TWMChannel *)channel;
		[Export("ipMessagingClient:channelDeleted:")]
		void ChannelDeleted(TwilioIPMessagingClient client, /*mc++ TWM*/Channel channel);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channel:(TWMChannel *)channel synchronizationStatusChanged:(TWMChannelSynchronizationStatus)status;
		[Export("ipMessagingClient:channel:synchronizationStatusChanged:")]
		void Channel(TwilioIPMessagingClient client, /*mc++ TWM*/Channel channel, /*mc++ TWM*/ChannelSynchronizationStatus status);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channel:(TWMChannel *)channel memberJoined:(TWMMember *)member;
		[Export("ipMessagingClient:channel:memberJoined:")]
		void Channel(TwilioIPMessagingClient client, /*mc++ TWM*/Channel channel, /*mc++ TWM*/Member member);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channel:(TWMChannel *)channel memberChanged:(TWMMember *)member;
		[Export("ipMessagingClient:channel:memberChanged:")]
		//mc++ void Channel(TwilioIPMessagingClient client, TWMChannel channel, TWMMember member);
		void ChannelMemberChanged(TwilioIPMessagingClient client, /*mc++ TWM*/Channel channel, /*mc++ TWM*/Member member);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channel:(TWMChannel *)channel member:(TWMMember *)member userInfo:(TWMUserInfo *)userInfo updated:(TWMUserInfoUpdate)updated;
		[Export("ipMessagingClient:channel:member:userInfo:updated:")]
		//mc++ void Channel(TwilioIPMessagingClient client, TWMChannel channel, TWMMember member, TWMUserInfo userInfo, TWMUserInfoUpdate updated);
		void ChannelUserInfoUpdated(TwilioIPMessagingClient client, /*mc++ TWM*/Channel channel, /*mc++ TWM*/Member member, /*mc++ TWM*/UserInfo userInfo, /*mc++ TWM*/UserInfoUpdate updated);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channel:(TWMChannel *)channel memberLeft:(TWMMember *)member;
		[Export("ipMessagingClient:channel:memberLeft:")]
		//mc++ void Channel(TwilioIPMessagingClient client, TWMChannel channel, TWMMember member);
		void ChannelMemberLeft(TwilioIPMessagingClient client, /*mc++ TWM*/Channel channel, /*mc++ TWM*/Member member);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channel:(TWMChannel *)channel messageAdded:(TWMMessage *)message;
		[Export("ipMessagingClient:channel:messageAdded:")]
		//mc++ void Channel(TwilioIPMessagingClient client, TWMChannel channel, TWMMessage message);
		void ChannelMessageAdded(TwilioIPMessagingClient client, /*mc++ TWM*/Channel channel, /*mc++ TWM*/Message message);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channel:(TWMChannel *)channel messageChanged:(TWMMessage *)message;
		[Export("ipMessagingClient:channel:messageChanged:")]
		//mc++ void Channel(TwilioIPMessagingClient client, TWMChannel channel, TWMMessage message);
		void ChannelMessageChanged(TwilioIPMessagingClient client, /*mc++ TWM*/Channel channel, /*mc++ TWM*/Message message);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channel:(TWMChannel *)channel messageDeleted:(TWMMessage *)message;
		[Export("ipMessagingClient:channel:messageDeleted:")]
		void Channel(TwilioIPMessagingClient client, /*mc++ TWM*/Channel channel, /*mc++ TWM*/Message message);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client typingStartedOnChannel:(TWMChannel *)channel member:(TWMMember *)member;
		[Export("ipMessagingClient:typingStartedOnChannel:member:")]
		void TypingStartedOnChannel(TwilioIPMessagingClient client, /*mc++ TWM*/Channel channel, /*mc++ TWM*/Member member);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client typingEndedOnChannel:(TWMChannel *)channel member:(TWMMember *)member;
		[Export("ipMessagingClient:typingEndedOnChannel:member:")]
		void TypingEndedOnChannel(TwilioIPMessagingClient client, /*mc++ TWM*/Channel channel, /*mc++ TWM*/Member member);
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
		/*mc++ TWM*/UserInfo UserInfo { get; }

		// @property (readonly, assign, nonatomic) TWMClientSynchronizationStatus synchronizationStatus;
		[Export("synchronizationStatus", ArgumentSemantic.Assign)]
		/*mc++ TWM*/ClientSynchronizationStatus SynchronizationStatus { get; }

		// +(TWMLogLevel)logLevel;
		// +(void)setLogLevel:(TWMLogLevel)logLevel;
		[Static]
		[Export("logLevel")]
		//mc++ [Verify(MethodToProperty)]
		/*mc++ TWM*/LogLevel LogLevel { get; set; }

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
		/*mc++ TWM*/Channels ChannelsList { get; }

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
		/*mc++ TWM*/ClientSynchronizationStrategy SynchronizationStrategy { get; set; }

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
		void IpMessagingClientStatusChanged(TwilioIPMessagingClient client, /*mc++ TWM*/ClientSynchronizationStatus status);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channelAdded:(TWMChannel *)channel;
		[Export("ipMessagingClient:channelAdded:")]
		//mc++ void IpMessagingClient(TwilioIPMessagingClient client, TWMChannel channel);
		void IpMessagingClientChannelAdded(TwilioIPMessagingClient client, /*mc++ TWM*/Channel channel);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channelChanged:(TWMChannel *)channel;
		[Export("ipMessagingClient:channelChanged:")]
		//mc++ void IpMessagingClient(TwilioIPMessagingClient client, TWMChannel channel);
		void IpMessagingClientChannelChanged(TwilioIPMessagingClient client, /*mc++ TWM*/Channel channel);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channelDeleted:(TWMChannel *)channel;
		[Export("ipMessagingClient:channelDeleted:")]
		//mc++ void IpMessagingClient(TwilioIPMessagingClient client, TWMChannel channel);
		void IpMessagingClientChannelDeleted(TwilioIPMessagingClient client, /*mc++ TWM*/Channel channel);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channel:(TWMChannel *)channel synchronizationStatusChanged:(TWMChannelSynchronizationStatus)status;
		[Export("ipMessagingClient:channel:synchronizationStatusChanged:")]
		//mc++ void IpMessagingClient(TwilioIPMessagingClient client, TWMChannel channel, TWMChannelSynchronizationStatus status);
		void IpMessagingClientStatusChanged(TwilioIPMessagingClient client, /*mc++ TWM*/Channel channel, /*mc++ TWM*/ChannelSynchronizationStatus status);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channel:(TWMChannel *)channel memberJoined:(TWMMember *)member;
		[Export("ipMessagingClient:channel:memberJoined:")]
		//mc++ void IpMessagingClient(TwilioIPMessagingClient client, TWMChannel channel, TWMMember member);
		void IpMessagingClientMemberJoined(TwilioIPMessagingClient client, /*mc++ TWM*/Channel channel, /*mc++ TWM*/Member member);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channel:(TWMChannel *)channel memberChanged:(TWMMember *)member;
		[Export("ipMessagingClient:channel:memberChanged:")]
		//mc++ void IpMessagingClient(TwilioIPMessagingClient client, TWMChannel channel, TWMMember member);
		void IpMessagingClientMemberChanged(TwilioIPMessagingClient client, /*mc++ TWM*/Channel channel, /*mc++ TWM*/Member member);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channel:(TWMChannel *)channel memberLeft:(TWMMember *)member;
		[Export("ipMessagingClient:channel:memberLeft:")]
		//mc++ void IpMessagingClient(TwilioIPMessagingClient client, TWMChannel channel, TWMMember member);
		void IpMessagingClientMemberLeft(TwilioIPMessagingClient client, /*mc++ TWM*/Channel channel, /*mc++ TWM*/Member member);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channel:(TWMChannel *)channel messageAdded:(TWMMessage *)message;
		[Export("ipMessagingClient:channel:messageAdded:")]
		//mc++ void IpMessagingClient(TwilioIPMessagingClient client, TWMChannel channel, TWMMessage message);
		void IpMessagingClientMessageAdded(TwilioIPMessagingClient client, /*mc++ TWM*/Channel channel, /*mc++ TWM*/Message message);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channel:(TWMChannel *)channel messageChanged:(TWMMessage *)message;
		[Export("ipMessagingClient:channel:messageChanged:")]
		//mc++ void IpMessagingClient(TwilioIPMessagingClient client, TWMChannel channel, TWMMessage message);
		void IpMessagingClientMessageChanged(TwilioIPMessagingClient client, /*mc++ TWM*/Channel channel, /*mc++ TWM*/Message message);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channel:(TWMChannel *)channel messageDeleted:(TWMMessage *)message;
		[Export("ipMessagingClient:channel:messageDeleted:")]
		//mc++ void IpMessagingClient(TwilioIPMessagingClient client, TWMChannel channel, TWMMessage message);
		void IpMessagingClientMessageDeleted(TwilioIPMessagingClient client, /*mc++ TWM*/Channel channel, /*mc++ TWM*/Message message);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client errorReceived:(TWMError *)error;
		[Export("ipMessagingClient:errorReceived:")]
		//mc++ void IpMessagingClient(TwilioIPMessagingClient client, TWMError error);
		void IpMessagingClientErrorReceived(TwilioIPMessagingClient client, /*mc++ TWM*/Error error);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client typingStartedOnChannel:(TWMChannel *)channel member:(TWMMember *)member;
		[Export("ipMessagingClient:typingStartedOnChannel:member:")]
		//mc++ void IpMessagingClient(TwilioIPMessagingClient client, TWMChannel channel, TWMMember member);
		void IpMessagingClientTypingStarted(TwilioIPMessagingClient client, /*mc++ TWM*/Channel channel, /*mc++ TWM*/Member member);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client typingEndedOnChannel:(TWMChannel *)channel member:(TWMMember *)member;
		[Export("ipMessagingClient:typingEndedOnChannel:member:")]
		//mc++ void IpMessagingClient(TwilioIPMessagingClient client, TWMChannel channel, TWMMember member);
		void IpMessagingClientTypingEnded(TwilioIPMessagingClient client, /*mc++ TWM*/Channel channel, /*mc++ TWM*/Member member);

		// @optional -(void)ipMessagingClientToastSubscribed:(TwilioIPMessagingClient *)client;
		[Export("ipMessagingClientToastSubscribed:")]
		void IpMessagingClientToastSubscribed(TwilioIPMessagingClient client);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client toastReceivedOnChannel:(TWMChannel *)channel message:(TWMMessage *)message;
		[Export("ipMessagingClient:toastReceivedOnChannel:message:")]
		//mc++ void IpMessagingClient(TwilioIPMessagingClient client, TWMChannel channel, TWMMessage message);
		void IpMessagingClientToastReceived(TwilioIPMessagingClient client, /*mc++ TWM*/Channel channel, /*mc++ TWM*/Message message);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client toastRegistrationFailedWithError:(TWMError *)error;
		[Export("ipMessagingClient:toastRegistrationFailedWithError:")]
		//mc++ void IpMessagingClient(TwilioIPMessagingClient client, TWMError error);
		void IpMessagingClient(TwilioIPMessagingClient client, /*mc++ TWM*/Error error);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client userInfo:(TWMUserInfo *)userInfo updated:(TWMUserInfoUpdate)updated;
		[Export("ipMessagingClient:userInfo:updated:")]
		//mc++ void IpMessagingClient(TwilioIPMessagingClient client, TWMUserInfo userInfo, TWMUserInfoUpdate updated);
		void IpMessagingClient(TwilioIPMessagingClient client, /*mc++ TWM*/UserInfo userInfo, /*mc++ TWM*/UserInfoUpdate updated);
	}
}
