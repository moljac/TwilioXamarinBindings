using System;
using Foundation;
using ObjCRuntime;
//mc++ using TwilioVoiceClient;

namespace Twilio.Voice
{
	[Static]
	//mc++ [Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern double TwilioVoiceClientVersionNumber;
		[Field ("TwilioVoiceClientVersionNumber", "__Internal")]
		double TwilioVoiceClientVersionNumber { get; }

		// extern const unsigned char [] TwilioVoiceClientVersionString;
		[Field ("TwilioVoiceClientVersionString", "__Internal")]
		/*mc++ byte[]*/ IntPtr TwilioVoiceClientVersionString { get; }
	}

	// @protocol TVONotificationDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject), Name="TVONotificationDelegate")]
	interface /*mc++ TVO*/NotificationDelegate
	{
		// @required -(void)incomingCallReceived:(TVOIncomingCall * _Nonnull)incomingCall;
		[Abstract]
		[Export ("incomingCallReceived:")]
		void IncomingCallReceived (/*mc++ TVO*/IncomingCall incomingCall);

		// @required -(void)incomingCallCancelled:(TVOIncomingCall * _Nullable)incomingCall;
		[Abstract]
		[Export ("incomingCallCancelled:")]
		void IncomingCallCancelled ([NullAllowed] /*mc++ TVO*/IncomingCall incomingCall);

		// @required -(void)notificationError:(NSError * _Nonnull)error;
		[Abstract]
		[Export ("notificationError:")]
		void NotificationError (NSError error);
	}

	// @interface VoiceClient : NSObject
	[BaseType (typeof(NSObject), Name="VoiceClient")]
	interface VoiceClient
	{
		// @property (assign, nonatomic) TVOLogLevel logLevel;
		[Export ("logLevel", ArgumentSemantic.Assign)]
		/*mc++ TVO*/LogLevel LogLevel { get; set; }

		// @property (getter = isPublishMetricsEnabled, assign, nonatomic) BOOL publishMetricsEnabled;
		[Export ("publishMetricsEnabled")]
		bool PublishMetricsEnabled { [Bind ("isPublishMetricsEnabled")] get; set; }

		// +(VoiceClient * _Nonnull)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		//mc++ [Verify (MethodToProperty)]
		VoiceClient SharedInstance { get; }

		// -(NSString * _Nonnull)version;
		[Export ("version")]
		//mc++ [Verify (MethodToProperty)]
		string Version { get; }

		// -(void)setModule:(TVOLogModule)module logLevel:(TVOLogLevel)level;
		[Export ("setModule:logLevel:")]
		void SetModule (/*mc++ TVO*/LogModule module, /*mc++ TVO*/LogLevel level);

		// -(void)registerWithAccessToken:(NSString * _Nonnull)accessToken deviceToken:(NSString * _Nonnull)deviceToken completion:(void (^ _Nullable)(NSError * _Nullable))completion;
		[Export ("registerWithAccessToken:deviceToken:completion:")]
		void RegisterWithAccessToken (string accessToken, string deviceToken, [NullAllowed] Action<NSError> completion);

		// -(void)unregisterWithAccessToken:(NSString * _Nonnull)accessToken deviceToken:(NSString * _Nonnull)deviceToken completion:(void (^ _Nullable)(NSError * _Nullable))completion;
		[Export ("unregisterWithAccessToken:deviceToken:completion:")]
		void UnregisterWithAccessToken (string accessToken, string deviceToken, [NullAllowed] Action<NSError> completion);

		// -(void)handleNotification:(NSDictionary * _Nonnull)payload delegate:(id<TVONotificationDelegate> _Nullable)delegate;
		[Export ("handleNotification:delegate:")]
		void HandleNotification (NSDictionary payload, [NullAllowed] /*mc++ TVO*/NotificationDelegate @delegate);

		// -(TVOOutgoingCall * _Nullable)call:(NSString * _Nonnull)accessToken params:(NSDictionary<NSString *,NSString *> * _Nullable)twiMLParams delegate:(id<TVOOutgoingCallDelegate> _Nullable)delegate;
		[Export ("call:params:delegate:")]
		[return: NullAllowed]
		/*mc++ TVO*/OutgoingCall Call (string accessToken, [NullAllowed] NSDictionary<NSString, NSString> twiMLParams, [NullAllowed] /*mc++ TVO*/OutgoingCallDelegate @delegate);
	}

	// @interface CallKitIntegration (VoiceClient)
	[Category]
	[BaseType (typeof(VoiceClient), Name = "VoiceClient_CallKitIntegration")]
	interface VoiceClient_CallKitIntegration
	{
		// -(void)configureAudioSession;
		[Export ("configureAudioSession")]
		void ConfigureAudioSession ();

		// -(void)startAudioDevice;
		[Export ("startAudioDevice")]
		void StartAudioDevice ();

		// -(void)stopAudioDevice;
		[Export ("stopAudioDevice")]
		void StopAudioDevice ();
	}

	// @protocol TVOIncomingCallDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject), Name = "TVOIncomingCallDelegate")]
	interface /*mc++ TVO*/IncomingCallDelegate
	{
		// @required -(void)incomingCallDidConnect:(TVOIncomingCall * _Nonnull)incomingCall;
		[Abstract]
		[Export ("incomingCallDidConnect:")]
		void IncomingCallDidConnect (/*mc++ TVO*/IncomingCall incomingCall);

		// @required -(void)incomingCallDidDisconnect:(TVOIncomingCall * _Nonnull)incomingCall;
		[Abstract]
		[Export ("incomingCallDidDisconnect:")]
		void IncomingCallDidDisconnect (/*mc++ TVO*/IncomingCall incomingCall);

		// @required -(void)incomingCall:(TVOIncomingCall * _Nonnull)incomingCall didFailWithError:(NSError * _Nonnull)error;
		[Abstract]
		[Export ("incomingCall:didFailWithError:")]
		void IncomingCall (/*mc++ TVO*/IncomingCall incomingCall, NSError error);
	}

	// @interface TVOIncomingCall : NSObject
	[BaseType (typeof(NSObject), Name = "TVOIncomingCall")]
	[DisableDefaultCtor]
	interface /*mc++ TVO*/IncomingCall
	{
		[Wrap ("WeakDelegate")]
		[NullAllowed]
		/*mc++ TVO*/IncomingCallDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<TVOIncomingCallDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull from;
		[Export ("from", ArgumentSemantic.Strong)]
		string From { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull to;
		[Export ("to", ArgumentSemantic.Strong)]
		string To { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull callSid;
		[Export ("callSid", ArgumentSemantic.Strong)]
		string CallSid { get; }

		// @property (getter = isMuted, assign, nonatomic) BOOL muted;
		[Export ("muted")]
		bool Muted { [Bind ("isMuted")] get; set; }

		// @property (readonly, assign, nonatomic) TVOIncomingCallState state;
		[Export ("state", ArgumentSemantic.Assign)]
		/*mc++ TVO*/IncomingCallState State { get; }

		// -(void)disconnect;
		[Export ("disconnect")]
		void Disconnect ();

		// -(void)sendDigits:(NSString * _Nonnull)digits;
		[Export ("sendDigits:")]
		void SendDigits (string digits);

		// -(void)acceptWithDelegate:(id<TVOIncomingCallDelegate> _Nonnull)delegate;
		[Export ("acceptWithDelegate:")]
		void AcceptWithDelegate (/*mc++ TVO*/IncomingCallDelegate @delegate);

		// -(void)reject;
		[Export ("reject")]
		void Reject ();

		// -(void)ignore;
		[Export ("ignore")]
		void Ignore ();
	}

	// @interface CallKitIntegration (TVOIncomingCall)
	[Category]
	[BaseType (typeof(/*mc++ TVO*/IncomingCall), Name = "TVOIncomingCall_CallKitIntegration")]
	interface /*mc++ TVO*/IncomingCall_CallKitIntegration
	{
		[Static] //mc++
		// @property (readonly, nonatomic, strong) NSUUID * _Nonnull uuid;
		[Export ("uuid", ArgumentSemantic.Strong)]
		NSUuid Uuid { get; }
	}

	// @protocol TVOOutgoingCallDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject), Name = "TVOOutgoingCallDelegate")]
	interface /*mc++ TVO*/OutgoingCallDelegate
	{
		// @required -(void)outgoingCallDidConnect:(TVOOutgoingCall * _Nonnull)outgoingCall;
		[Abstract]
		[Export ("outgoingCallDidConnect:")]
		void OutgoingCallDidConnect (/*mc++ TVO*/OutgoingCall outgoingCall);

		// @required -(void)outgoingCallDidDisconnect:(TVOOutgoingCall * _Nonnull)outgoingCall;
		[Abstract]
		[Export ("outgoingCallDidDisconnect:")]
		void OutgoingCallDidDisconnect (/*mc++ TVO*/OutgoingCall outgoingCall);

		// @required -(void)outgoingCall:(TVOOutgoingCall * _Nonnull)outgoingCall didFailWithError:(NSError * _Nonnull)error;
		[Abstract]
		[Export ("outgoingCall:didFailWithError:")]
		void OutgoingCall (/*mc++ TVO*/OutgoingCall outgoingCall, NSError error);
	}

	// @interface TVOOutgoingCall : NSObject
	[BaseType (typeof(NSObject), Name = "TVOOutgoingCall")]
	[DisableDefaultCtor]
	interface /*mc++ TVO*/OutgoingCall
	{
		[Wrap ("WeakDelegate")]
		[NullAllowed]
		/*mc++ TVO*/OutgoingCallDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<TVOOutgoingCallDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull callSid;
		[Export ("callSid", ArgumentSemantic.Strong)]
		string CallSid { get; }

		// @property (getter = isMuted, assign, nonatomic) BOOL muted;
		[Export ("muted")]
		bool Muted { [Bind ("isMuted")] get; set; }

		// @property (readonly, assign, nonatomic) TVOOutgoingCallState state;
		[Export ("state", ArgumentSemantic.Assign)]
		/*mc++ TVO*/OutgoingCallState State { get; }

		// -(void)disconnect;
		[Export ("disconnect")]
		void Disconnect ();

		// -(void)sendDigits:(NSString * _Nonnull)digits;
		[Export ("sendDigits:")]
		void SendDigits (string digits);
	}

	// @interface CallKitIntegration (TVOOutgoingCall)
	[Category]
	[BaseType (typeof(/*mc++ TVO*/OutgoingCall), Name = "TVOOutgoingCall_CallKitIntegration")]
	interface /*mc++ TVO*/OutgoingCall_CallKitIntegration
	{
		[Static] //mc++
		// @property (nonatomic, strong) NSUUID * _Nonnull uuid;
		[Export ("uuid", ArgumentSemantic.Strong)]
		NSUuid Uuid { get; set; }
	}
}
