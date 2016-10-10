using System;
using CoreFoundation;
using CoreMedia;
using Foundation;
using ObjCRuntime;
using Twilio.Common;
using UIKit;

namespace Twilio.Conversations
{
	// @interface TWCMediaTrack : NSObject
	// mc++ [BaseType(typeof(NSObject))]
	[BaseType(typeof(NSObject), Name="TWCMediaTrack")]
	interface MediaTrack
	{
		// @property (readonly, getter = isEnabled, assign, nonatomic) BOOL enabled;
		[Export("enabled")]
		bool Enabled { [Bind("isEnabled")] get; }

		// @property (readonly, assign, nonatomic) TWCMediaTrackState state;
		[Export("state", ArgumentSemantic.Assign)]
		/*TWC*/MediaTrackState State { get; }

		// @property (readonly, copy, nonatomic) NSString * trackId;
		[Export("trackId")]
		string TrackId { get; }
	}

	// @interface TWCAudioTrack : TWCMediaTrack
	//mc++ [BaseType(typeof(TWCMediaTrack))]
	[BaseType(typeof(MediaTrack), Name = "TWCAudioTrack")]
	interface AudioTrack
	{
	}

	// @protocol TWCVideoCapturer <NSObject>
	[Protocol, Model]
	//mc++ [BaseType(typeof(NSObject))]
	[BaseType(typeof(NSObject), Name="TWCVideoCapturer")]
	interface VideoCapturer
	{
		// @required @property (readonly, getter = isCapturing, assign, atomic) BOOL capturing;
		[Abstract]
		[Export("capturing")]
		bool Capturing { [Bind("isCapturing")] get; }

		// @required @property (nonatomic, weak) TWCLocalVideoTrack * _Nullable videoTrack;
		[Abstract]
		[NullAllowed, Export("videoTrack", ArgumentSemantic.Weak)]
		LocalVideoTrack VideoTrack { get; set; }
	}

	//mc++ [Static]
	//mc++ [Verify(ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern const CMVideoDimensions TWCVideoConstraintsSize352x288;
		[Field("TWCVideoConstraintsSize352x288", "__Internal")]
		//mc++ CMVideoDimensions TWCVideoConstraintsSize352x288 { get; }
		IntPtr VideoConstraintsSize352x288 { get; }

		// extern const CMVideoDimensions TWCVideoConstraintsSize480x360;
		[Field("TWCVideoConstraintsSize480x360", "__Internal")]
		//mc++ CMVideoDimensions TWCVideoConstraintsSize480x360 { get; }
		IntPtr VideoConstraintsSize480x360 { get; }

		// extern const CMVideoDimensions TWCVideoConstraintsSize640x480;
		[Field("TWCVideoConstraintsSize640x480", "__Internal")]
		//mc++ CMVideoDimensions TWCVideoConstraintsSize640x480 { get; }
		IntPtr VideoConstraintsSize640x480 { get; }

		// extern const CMVideoDimensions TWCVideoConstraintsSize960x540;
		[Field("TWCVideoConstraintsSize960x540", "__Internal")]
		//mc++ CMVideoDimensions TWCVideoConstraintsSize960x540 { get; }
		IntPtr VideoConstraintsSize960x540 { get; }

		// extern const CMVideoDimensions TWCVideoConstraintsSize1280x720;
		[Field("TWCVideoConstraintsSize1280x720", "__Internal")]
		//mc++ CMVideoDimensions TWCVideoConstraintsSize1280x720 { get; }
		IntPtr VideoConstraintsSize1280x720 { get; }

		// extern const CMVideoDimensions TWCVideoConstraintsSize1280x960;
		[Field("TWCVideoConstraintsSize1280x960", "__Internal")]
		//mc++ CMVideoDimensions TWCVideoConstraintsSize1280x960 { get; }
		IntPtr TWCVideoConstraintsSize1280x960 { get; }

		// extern const NSUInteger TWCVideoConstraintsFrameRate30;
		[Field("TWCVideoConstraintsFrameRate30", "__Internal")]
		nuint TWCVideoConstraintsFrameRate30 { get; }

		// extern const NSUInteger TWCVideoConstraintsFrameRate24;
		[Field("TWCVideoConstraintsFrameRate24", "__Internal")]
		nuint TWCVideoConstraintsFrameRate24 { get; }

		// extern const NSUInteger TWCVideoConstraintsFrameRate20;
		[Field("TWCVideoConstraintsFrameRate20", "__Internal")]
		nuint TWCVideoConstraintsFrameRate20 { get; }

		// extern const NSUInteger TWCVideoConstraintsFrameRate15;
		[Field("TWCVideoConstraintsFrameRate15", "__Internal")]
		nuint TWCVideoConstraintsFrameRate15 { get; }

		// extern const NSUInteger TWCVideoConstraintsFrameRate10;
		[Field("TWCVideoConstraintsFrameRate10", "__Internal")]
		nuint TWCVideoConstraintsFrameRate10 { get; }
	}

	// @protocol TWCCameraCapturerDelegate <NSObject>
	[Protocol, Model]
	//mc++ [BaseType(typeof(NSObject))]
	[BaseType(typeof(NSObject), Name = "TWCCameraCapturerDelegate")]
	interface CameraCapturerDelegate
	{
		// @optional -(void)cameraCapturerPreviewDidStart:(TWCCameraCapturer * _Nonnull)capturer;
		[Export("cameraCapturerPreviewDidStart:")]
		void CameraCapturerPreviewDidStart(CameraCapturer capturer);

		// @optional -(void)cameraCapturer:(TWCCameraCapturer * _Nonnull)capturer didStartWithSource:(TWCVideoCaptureSource)source;
		[Export("cameraCapturer:didStartWithSource:")]
		void CameraCapturer(CameraCapturer capturer, VideoCaptureSource source);

		// @optional -(void)cameraCapturerWasInterrupted:(TWCCameraCapturer * _Nonnull)capturer;
		[Export("cameraCapturerWasInterrupted:")]
		void CameraCapturerWasInterrupted(CameraCapturer capturer);

		// @optional -(void)cameraCapturer:(TWCCameraCapturer * _Nonnull)capturer didStopRunningWithError:(NSError * _Nonnull)error;
		[Export("cameraCapturer:didStopRunningWithError:")]
		void CameraCapturer(CameraCapturer capturer, NSError error);
	}

	// @interface TWCCameraCapturer : NSObject <TWCVideoCapturer>
	//mc++ [BaseType(typeof(NSObject))]
	[BaseType(typeof(NSObject), Name = "TWCCameraCapturer")]
	interface CameraCapturer : VideoCapturer
	{
		// @property (assign, nonatomic) TWCVideoCaptureSource camera;
		[Export("camera", ArgumentSemantic.Assign)]
		VideoCaptureSource Camera { get; set; }

		// @property (readonly, getter = isCapturing, assign, atomic) BOOL capturing;
		[Export("capturing")]
		bool Capturing { [Bind("isCapturing")] get; }

		[Wrap("WeakDelegate")]
		[NullAllowed]
		CameraCapturerDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<TWCCameraCapturerDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, assign, nonatomic) CMVideoDimensions previewDimensions;
		[Export("previewDimensions", ArgumentSemantic.Assign)]
		//mc++ CMVideoDimensions PreviewDimensions { get; }
		IntPtr PreviewDimensions { get; }

		// @property (readonly, nonatomic, strong) TWCCameraPreviewView * _Nullable previewView;
		[NullAllowed, Export("previewView", ArgumentSemantic.Strong)]
		CameraPreviewView PreviewView { get; }

		// @property (nonatomic, weak) TWCLocalVideoTrack * _Nullable videoTrack;
		[NullAllowed, Export("videoTrack", ArgumentSemantic.Weak)]
		LocalVideoTrack VideoTrack { get; set; }

		// @property (readonly, getter = isInterrupted, assign, nonatomic) BOOL interrupted;
		[Export("interrupted")]
		bool Interrupted { [Bind("isInterrupted")] get; }

		// -(instancetype _Nonnull)initWithSource:(TWCVideoCaptureSource)source;
		[Export("initWithSource:")]
		IntPtr Constructor(VideoCaptureSource source);

		// -(instancetype _Nonnull)initWithDelegate:(id<TWCCameraCapturerDelegate> _Nullable)delegate source:(TWCVideoCaptureSource)source;
		[Export("initWithDelegate:source:")]
		IntPtr Constructor([NullAllowed] /*TWC*/CameraCapturerDelegate @delegate, /*TWC*/VideoCaptureSource source);

		// -(BOOL)startPreview;
		[Export("startPreview")]
		//mc++ [Verify(MethodToProperty)]
		bool StartPreview(); //mc++ { get; }

		// -(BOOL)stopPreview;
		[Export("stopPreview")]
		//mc++ [Verify(MethodToProperty)]
		bool StopPreview(); //mc++ { get; }

		// -(void)flipCamera;
		[Export("flipCamera")]
		void FlipCamera();
	}

	// @interface TWCCameraPreviewView : UIView
	//mc++ [BaseType(typeof(UIView))]
	[BaseType(typeof(UIView), Name = "TWCCameraPreviewView")]
	interface CameraPreviewView
	{
		// @property (readonly, assign, nonatomic) UIInterfaceOrientation orientation;
		[Export("orientation", ArgumentSemantic.Assign)]
		UIInterfaceOrientation Orientation { get; }
	}

	// @interface TWCClientOptions : NSObject
	//mc++ [BaseType(typeof(NSObject))]
	[BaseType(typeof(NSObject), Name = "TWCClientOptions")]
	interface ClientOptions
	{
		// @property (readonly, nonatomic, strong) TWCIceOptions * _Nonnull iceOptions;
		[Export("iceOptions", ArgumentSemantic.Strong)]
		/*TWC*/IceOptions IceOptions { get; }

		// @property (readonly, assign, nonatomic) BOOL preferH264;
		[Export("preferH264")]
		bool PreferH264 { get; }

		// -(instancetype _Null_unspecified)initWithIceOptions:(TWCIceOptions * _Nonnull)options;
		[Export("initWithIceOptions:")]
		IntPtr Constructor(/*TWC*/IceOptions options);

		// -(instancetype _Null_unspecified)initWithIceOptions:(TWCIceOptions * _Nonnull)options preferH264:(BOOL)preferH264;
		[Export("initWithIceOptions:preferH264:")]
		IntPtr Constructor(/*TWC*/IceOptions options, bool preferH264);
	}

	// typedef void (^TWCInviteAcceptanceBlock)(TWCConversation * _Nullable, NSError * _Nullable);
	delegate void /*TWC*/InviteAcceptanceBlock([NullAllowed] /*TWC*/Conversation arg0, [NullAllowed] NSError arg1);

	// @interface TWCOutgoingInvite : NSObject
	//mc++ [BaseType(typeof(NSObject))]
	[BaseType(typeof(NSObject), Name = "TWCOutgoingInvite")]
	interface /*TWC*/OutgoingInvite
	{
		// @property (readonly, assign, nonatomic) TWCInviteStatus status;
		[Export("status", ArgumentSemantic.Assign)]
		/*TWC*/InviteStatus Status { get; }

		// @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nonnull to;
		[Export("to", ArgumentSemantic.Copy)]
		string[] To { get; }

		// -(void)cancel;
		[Export("cancel")]
		void Cancel();
	}

	// @interface TWCMedia : NSObject
	//mc++ [BaseType(typeof(NSObject))]
	[BaseType(typeof(NSObject), Name = "TWCMedia")]
	interface /*TWC*/Media
	{
		// @property (readonly, nonatomic, strong) NSArray<TWCAudioTrack *> * _Nonnull audioTracks;
		[Export("audioTracks", ArgumentSemantic.Strong)]
		/*TWC*/AudioTrack[] AudioTracks { get; }

		// @property (readonly, nonatomic, strong) NSArray<TWCVideoTrack *> * _Nonnull videoTracks;
		[Export("videoTracks", ArgumentSemantic.Strong)]
		/*TWC*/VideoTrack[] VideoTracks { get; }

		// -(TWCMediaTrack * _Nullable)getTrack:(NSString * _Nonnull)trackId;
		[Export("getTrack:")]
		[return: NullAllowed]
		/*TWC*/MediaTrack GetTrack(string trackId);
	}

	// @protocol TWCLocalMediaDelegate <NSObject>
	[Protocol, Model]
	//mc++ [BaseType(typeof(NSObject))]
	[BaseType(typeof(NSObject), Name = "TWCLocalMediaDelegate")]
	interface LocalMediaDelegate
	{
		// @optional -(void)localMedia:(TWCLocalMedia * _Nonnull)media didAddVideoTrack:(TWCVideoTrack * _Nonnull)videoTrack;
		[Export("localMedia:didAddVideoTrack:")]
		void DidAddVideoTrack(/*TWC*/LocalMedia media, /*TWC*/VideoTrack videoTrack);

		// @optional -(void)localMedia:(TWCLocalMedia * _Nonnull)media didFailToAddVideoTrack:(TWCVideoTrack * _Nonnull)videoTrack error:(NSError * _Nonnull)error;
		[Export("localMedia:didFailToAddVideoTrack:error:")]
		void DidFailToAddVideoTrack(/*TWC*/LocalMedia media, /*TWC*/VideoTrack videoTrack, NSError error);

		// @optional -(void)localMedia:(TWCLocalMedia * _Nonnull)media didRemoveVideoTrack:(TWCVideoTrack * _Nonnull)videoTrack;
		[Export("localMedia:didRemoveVideoTrack:")]
		void DidRemoveVideoTrack(/*TWC*/LocalMedia media, /*TWC*/VideoTrack videoTrack);
	}

	// @interface TWCLocalMedia : TWCMedia
	//mc++ [BaseType(typeof(TWCMedia))]
	[BaseType(typeof(/*TWC*/Media), Name = "TWCLocalMedia")]
	interface /*TWC*/LocalMedia
	{
		// @property (getter = isMicrophoneMuted, assign, nonatomic) BOOL microphoneMuted;
		[Export("microphoneMuted")]
		bool MicrophoneMuted { [Bind("isMicrophoneMuted")] get; set; }

		// @property (readonly, getter = isMicrophoneAdded, assign, nonatomic) BOOL microphoneAdded;
		[Export("microphoneAdded")]
		bool MicrophoneAdded { [Bind("isMicrophoneAdded")] get; }

		[Wrap("WeakDelegate")]
		[NullAllowed]
		/*TWC*/LocalMediaDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<TWCLocalMediaDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// -(instancetype _Nullable)initWithDelegate:(id<TWCLocalMediaDelegate> _Nullable)delegate;
		[Export("initWithDelegate:")]
		IntPtr Constructor([NullAllowed] /*TWC*/LocalMediaDelegate @delegate);

		// -(BOOL)addTrack:(TWCVideoTrack * _Nonnull)track;
		[Export("addTrack:")]
		bool AddTrack(/*TWC*/VideoTrack track);

		// -(BOOL)addTrack:(TWCVideoTrack * _Nonnull)track error:(NSError * _Nullable * _Nullable)error;
		[Export("addTrack:error:")]
		bool AddTrack(/*TWC*/VideoTrack track, [NullAllowed] out NSError error);

		// -(BOOL)removeTrack:(TWCVideoTrack * _Nonnull)track;
		[Export("removeTrack:")]
		bool RemoveTrack(/*TWC*/VideoTrack track);

		// -(BOOL)removeTrack:(TWCVideoTrack * _Nonnull)track error:(NSError * _Nullable * _Nullable)error;
		[Export("removeTrack:error:")]
		bool RemoveTrack(/*TWC*/VideoTrack track, [NullAllowed] out NSError error);

		// -(TWCCameraCapturer * _Nullable)addCameraTrack;
		[NullAllowed, Export("addCameraTrack")]
		//mc++ [Verify(MethodToProperty)]
		/*TWC*/CameraCapturer AddCameraTrack(); //mc++ { get; }

		// -(TWCCameraCapturer * _Nullable)addCameraTrack:(NSError * _Nullable * _Nullable)error;
		[Export("addCameraTrack:")]
		[return: NullAllowed]
		/*TWC*/CameraCapturer AddCameraTrack([NullAllowed] out NSError error);

		// -(BOOL)addMicrophone;
		[Export("addMicrophone")]
		//mc++ [Verify(MethodToProperty)]
		bool AddMicrophone(); //mc++ { get; }

		// -(BOOL)removeMicrophone;
		[Export("removeMicrophone")]
		//mc++ [Verify(MethodToProperty)]
		bool RemoveMicrophone(); //mc++ { get; }
	}

	// @protocol TWCParticipantDelegate <NSObject>
	[Protocol, Model]
	//mc++ [BaseType(typeof(NSObject))]
	[BaseType(typeof(NSObject), Name = "TWCParticipantDelegate")]
	interface ParticipantDelegate
	{
		// @optional -(void)participant:(TWCParticipant * _Nonnull)participant addedVideoTrack:(TWCVideoTrack * _Nonnull)videoTrack;
		[Export("participant:addedVideoTrack:")]
		void AddedVideoTrack(/*TWC*/Participant participant, /*TWC*/VideoTrack videoTrack);

		// @optional -(void)participant:(TWCParticipant * _Nonnull)participant removedVideoTrack:(TWCVideoTrack * _Nonnull)videoTrack;
		[Export("participant:removedVideoTrack:")]
		void RemovedVideoTrack(/*TWC*/Participant participant, /*TWC*/VideoTrack videoTrack);

		// @optional -(void)participant:(TWCParticipant * _Nonnull)participant addedAudioTrack:(TWCAudioTrack * _Nonnull)audioTrack;
		[Export("participant:addedAudioTrack:")]
		void AddedAudioTrack(/*TWC*/Participant participant, /*TWC*/AudioTrack audioTrack);

		// @optional -(void)participant:(TWCParticipant * _Nonnull)participant removedAudioTrack:(TWCAudioTrack * _Nonnull)audioTrack;
		[Export("participant:removedAudioTrack:")]
		void RemovedAudioTrack(/*TWC*/Participant participant, /*TWC*/AudioTrack audioTrack);

		// @optional -(void)participant:(TWCParticipant * _Nonnull)participant disabledTrack:(TWCMediaTrack * _Nonnull)track;
		[Export("participant:disabledTrack:")]
		void DisabledTrack(/*TWC*/Participant participant, /*TWC*/MediaTrack track);

		// @optional -(void)participant:(TWCParticipant * _Nonnull)participant enabledTrack:(TWCMediaTrack * _Nonnull)track;
		[Export("participant:enabledTrack:")]
		void EnabledTrack(/*TWC*/Participant participant, /*TWC*/MediaTrack track);
	}

	// @interface TWCParticipant : NSObject
	//mc++ [BaseType(typeof(NSObject))]
	[BaseType(typeof(NSObject), Name = "TWCParticipant")]
	interface /*TWC*/Participant
	{
		// @property (readonly, nonatomic, strong) NSString * _Nonnull identity;
		[Export("identity", ArgumentSemantic.Strong)]
		string Identity { get; }

		// @property (readonly, nonatomic, weak) TWCConversation * _Null_unspecified conversation;
		[Export("conversation", ArgumentSemantic.Weak)]
		/*TWC*/Conversation Conversation { get; }

		[Wrap("WeakDelegate")]
		[NullAllowed]
		ParticipantDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<TWCParticipantDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) TWCMedia * _Nonnull media;
		[Export("media", ArgumentSemantic.Strong)]
		Media Media { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nullable sid;
		[NullAllowed, Export("sid", ArgumentSemantic.Strong)]
		string Sid { get; }
	}

	// @interface TWCConversation : NSObject
	//mc++ [BaseType(typeof(NSObject))]
	[BaseType(typeof(NSObject), Name = "TWCConversation")]
	interface Conversation
	{
		// @property (readonly, nonatomic, strong) NSArray<TWCParticipant *> * _Nonnull participants;
		[Export("participants", ArgumentSemantic.Strong)]
		/*TWC*/Participant[] Participants { get; }

		// @property (readonly, nonatomic, strong) TWCLocalMedia * _Nullable localMedia;
		[NullAllowed, Export("localMedia", ArgumentSemantic.Strong)]
		/*TWC*/LocalMedia LocalMedia { get; }

		[Wrap("WeakDelegate")]
		[NullAllowed]
		/*TWC*/ConversationDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<TWCConversationDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		[Wrap("WeakStatisticsDelegate")]
		[NullAllowed]
		TWCMediaTrackStatisticsDelegate StatisticsDelegate { get; set; }

		// @property (nonatomic, weak) id<TWCMediaTrackStatisticsDelegate> _Nullable statisticsDelegate;
		[NullAllowed, Export("statisticsDelegate", ArgumentSemantic.Weak)]
		NSObject WeakStatisticsDelegate { get; set; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable sid;
		[NullAllowed, Export("sid")]
		string Sid { get; }

		// -(BOOL)disconnect;
		[Export("disconnect")]
		//mc++ [Verify(MethodToProperty)]
		bool Disconnect(); //mc++ { get; }

		// -(BOOL)disconnect:(NSError * _Nullable * _Nullable)error;
		[Export("disconnect:")]
		bool DisconnectWithError([NullAllowed] out NSError error);

		// -(BOOL)invite:(NSString * _Nonnull)clientIdentity error:(NSError * _Nullable * _Nullable)error;
		[Export("invite:error:")]
		bool Invite(string clientIdentity, [NullAllowed] out NSError error);

		// -(BOOL)inviteMany:(NSArray<NSString *> * _Nonnull)clientIdentities error:(NSError * _Nullable * _Nullable)error;
		[Export("inviteMany:error:")]
		bool InviteMany(string[] clientIdentities, [NullAllowed] out NSError error);

		// -(TWCParticipant * _Nullable)getParticipant:(NSString * _Nonnull)participantSID;
		[Export("getParticipant:")]
		[return: NullAllowed]
		/*TWC*/Participant GetParticipant(string participantSID);
	}

	// @protocol TWCConversationDelegate <NSObject>
	[Protocol, Model]
	//mc++ [BaseType(typeof(NSObject))]
	[BaseType(typeof(NSObject), Name = "TWCConversationDelegate")]
	interface ConversationDelegate
	{
		// @optional -(void)conversation:(TWCConversation * _Nonnull)conversation didConnectParticipant:(TWCParticipant * _Nonnull)participant;
		[Export("conversation:didConnectParticipant:")]
		void ConversationDidConnectParticipant(/*TWC*/Conversation conversation, /*TWC*/Participant participant);

		// @optional -(void)conversation:(TWCConversation * _Nonnull)conversation didFailToConnectParticipant:(TWCParticipant * _Nonnull)participant error:(NSError * _Nonnull)error;
		[Export("conversation:didFailToConnectParticipant:error:")]
		void Conversation(/*TWC*/Conversation conversation, /*TWC*/Participant participant, NSError error);

		// @optional -(void)conversation:(TWCConversation * _Nonnull)conversation didDisconnectParticipant:(TWCParticipant * _Nonnull)participant;
		[Export("conversation:didDisconnectParticipant:")]
		void ConversationDidDisconnectParticipant(/*TWC*/Conversation conversation, /*TWC*/Participant participant);

		// @optional -(void)conversationEnded:(TWCConversation * _Nonnull)conversation;
		[Export("conversationEnded:")]
		void ConversationEnded(/*TWC*/Conversation conversation);

		// @optional -(void)conversationEnded:(TWCConversation * _Nonnull)conversation error:(NSError * _Nonnull)error;
		[Export("conversationEnded:error:")]
		void ConversationEnded(/*TWC*/Conversation conversation, NSError error);
	}

	// @protocol TWCMediaTrackStatisticsDelegate <NSObject>
	[Protocol, Model]
	//mc++ [BaseType(typeof(NSObject))]
	[BaseType(typeof(NSObject), Name = "")]
	interface TWCMediaTrackStatisticsDelegate
	{
		// @required -(void)conversation:(TWCConversation * _Nonnull)conversation didReceiveTrackStatistics:(TWCMediaTrackStatsRecord * _Nonnull)trackStatistics;
		[Abstract]
		[Export("conversation:didReceiveTrackStatistics:")]
		void DidReceiveTrackStatistics(/*TWC*/Conversation conversation, /*TWC*/MediaTrackStatsRecord trackStatistics);
	}

	// @interface TWCIncomingInvite : NSObject
	//mc++ [BaseType(typeof(NSObject))]
	[BaseType(typeof(NSObject), Name = "TWCMediaTrackStatisticsDelegate")]
	interface IncomingInvite
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable conversationSid;
		[NullAllowed, Export("conversationSid")]
		string ConversationSid { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull from;
		[Export("from")]
		string From { get; }

		// @property (readonly, copy, nonatomic) NSArray * _Nonnull participants;
		[Export("participants", ArgumentSemantic.Copy)]
		//mc++ [Verify(StronglyTypedNSArray)]
		NSObject[] Participants { get; }

		// @property (readonly, assign, nonatomic) TWCInviteStatus status;
		[Export("status", ArgumentSemantic.Assign)]
		/*TWC*/InviteStatus Status { get; }

		// -(void)acceptWithCompletion:(TWCInviteAcceptanceBlock _Nonnull)acceptHandler;
		[Export("acceptWithCompletion:")]
		void AcceptWithCompletion(/*TWC*/InviteAcceptanceBlock acceptHandler);

		// -(void)acceptWithLocalMedia:(TWCLocalMedia * _Nonnull)localMedia completion:(TWCInviteAcceptanceBlock _Nonnull)acceptHandler;
		[Export("acceptWithLocalMedia:completion:")]
		void AcceptWithLocalMedia(/*TWC*/LocalMedia localMedia, /*TWC*/InviteAcceptanceBlock acceptHandler);

		// -(void)acceptWithLocalMedia:(TWCLocalMedia * _Nonnull)localMedia iceOptions:(TWCIceOptions * _Nonnull)iceOptions completion:(TWCInviteAcceptanceBlock _Nonnull)acceptHandler;
		[Export("acceptWithLocalMedia:iceOptions:completion:")]
		void AcceptWithLocalMedia(/*TWC*/LocalMedia localMedia, /*TWC*/IceOptions iceOptions, /*TWC*/InviteAcceptanceBlock acceptHandler);

		// -(void)reject;
		[Export("reject")]
		void Reject();
	}

	// @interface TWCIceServer : NSObject
	//mc++ [BaseType(typeof(NSObject))]
	[BaseType(typeof(NSObject), Name = "TWCIceServer")]
	interface IceServer
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull url;
		[Export("url")]
		string Url { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable username;
		[NullAllowed, Export("username")]
		string Username { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable password;
		[NullAllowed, Export("password")]
		string Password { get; }

		// -(instancetype _Null_unspecified)initWithURL:(NSString * _Nonnull)serverUrl;
		[Export("initWithURL:")]
		IntPtr Constructor(string serverUrl);

		// -(instancetype _Null_unspecified)initWithURL:(NSString * _Nonnull)serverUrl username:(NSString * _Nullable)username password:(NSString * _Nullable)password;
		[Export("initWithURL:username:password:")]
		IntPtr Constructor(string serverUrl, [NullAllowed] string username, [NullAllowed] string password);
	}

	// @interface TWCIceOptions : NSObject
	//mc++ [BaseType(typeof(NSObject))]
	[BaseType(typeof(NSObject), Name = "TWCIceOptions")]
	interface IceOptions
	{
		// @property (readonly, copy, nonatomic) NSArray<TWCIceServer *> * _Nonnull iceServers;
		[Export("iceServers", ArgumentSemantic.Copy)]
		/*TWC*/IceServer[] IceServers { get; }

		// @property (readonly, assign, nonatomic) TWCIceTransportPolicy iceTransportPolicy;
		[Export("iceTransportPolicy", ArgumentSemantic.Assign)]
		/*TWC*/IceTransportPolicy IceTransportPolicy { get; }

		// -(instancetype _Null_unspecified)initWithTransportPolicy:(TWCIceTransportPolicy)transportPolicy;
		[Export("initWithTransportPolicy:")]
		IntPtr Constructor(/*TWC*/IceTransportPolicy transportPolicy);

		// -(instancetype _Null_unspecified)initWithTransportPolicy:(TWCIceTransportPolicy)transportPolicy servers:(NSArray<TWCIceServer *> * _Nonnull)servers;
		[Export("initWithTransportPolicy:servers:")]
		IntPtr Constructor(/*TWC*/IceTransportPolicy transportPolicy, /*TWC*/IceServer[] servers);
	}

	// @interface TWCI420Frame : NSObject
	//mc++ [BaseType(typeof(NSObject))]
	[BaseType(typeof(NSObject), Name = "TWCI420Frame")]
	interface /*TWC*/I420Frame
	{
		// @property (readonly, nonatomic) NSUInteger width;
		[Export("width")]
		nuint Width { get; }

		// @property (readonly, nonatomic) NSUInteger height;
		[Export("height")]
		nuint Height { get; }

		// @property (readonly, nonatomic) NSUInteger chromaWidth;
		[Export("chromaWidth")]
		nuint ChromaWidth { get; }

		// @property (readonly, nonatomic) NSUInteger chromaHeight;
		[Export("chromaHeight")]
		nuint ChromaHeight { get; }

		// @property (readonly, nonatomic) NSUInteger chromaSize;
		[Export("chromaSize")]
		nuint ChromaSize { get; }

		// @property (readonly, nonatomic) TWCVideoOrientation orientation;
		[Export("orientation")]
		/*TWC*/VideoOrientation Orientation { get; }

		// @property (readonly, nonatomic) const uint8_t * yPlane;
		[Export("yPlane")]
		//mc++ unsafe byte* YPlane { get; }
		unsafe IntPtr YPlane { get; }

		// @property (readonly, nonatomic) const uint8_t * uPlane;
		[Export("uPlane")]
		//mc++ unsafe byte* UPlane { get; }
		unsafe IntPtr UPlane { get; }

		// @property (readonly, nonatomic) const uint8_t * vPlane;
		[Export("vPlane")]
		//mc++ unsafe byte* VPlane { get; }
		unsafe IntPtr VPlane { get; }

		// @property (readonly, nonatomic) NSInteger yPitch;
		[Export("yPitch")]
		nint YPitch { get; }

		// @property (readonly, nonatomic) NSInteger uPitch;
		[Export("uPitch")]
		nint UPitch { get; }

		// @property (readonly, nonatomic) NSInteger vPitch;
		[Export("vPitch")]
		nint VPitch { get; }
	}

	//mc++ [Static]
	//mc++ [Verify(ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern const NSUInteger TWCVideoConstraintsMaximumFPS;
		[Field("TWCVideoConstraintsMaximumFPS", "__Internal")]
		nuint TWCVideoConstraintsMaximumFPS { get; }

		// extern const NSUInteger TWCVideoConstraintsMinimumFPS;
		[Field("TWCVideoConstraintsMinimumFPS", "__Internal")]
		nuint TWCVideoConstraintsMinimumFPS { get; }

		// extern const CMVideoDimensions TWCVideoSizeConstraintsNone;
		[Field("TWCVideoSizeConstraintsNone", "__Internal")]
		//mc++ CMVideoDimensions TWCVideoSizeConstraintsNone { get; }
		IntPtr TWCVideoSizeConstraintsNone { get; }

		// extern const NSUInteger TWCVideoFrameRateConstraintsNone;
		[Field("TWCVideoFrameRateConstraintsNone", "__Internal")]
		nuint TWCVideoFrameRateConstraintsNone { get; }

		// extern const TWCAspectRatio TWCVideoAspectRatioConstraintsNone;
		[Field("TWCVideoAspectRatioConstraintsNone", "__Internal")]
		//mc++ TWCAspectRatio TWCVideoAspectRatioConstraintsNone { get; }
		IntPtr TWCVideoAspectRatioConstraintsNone { get; }

		// extern const TWCAspectRatio TWCAspectRatio11x9;
		[Field("TWCAspectRatio11x9", "__Internal")]
		//mc++ TWCAspectRatio TWCAspectRatio11x9 { get; }
		IntPtr TWCAspectRatio11x9 { get; }

		// extern const TWCAspectRatio TWCAspectRatio4x3;
		[Field("TWCAspectRatio4x3", "__Internal")]
		//mc++ TWCAspectRatio TWCAspectRatio4x3 { get; }
		IntPtr TWCAspectRatio4x3 { get; }

		// extern const TWCAspectRatio TWCAspectRatio16x9;
		[Field("TWCAspectRatio16x9", "__Internal")]
		//TWCAspectRatio TWCAspectRatio16x9 { get; }
		IntPtr TWCAspectRatio16x9 { get; }
	}

	// @interface TWCVideoConstraintsBuilder : NSObject
	//mc++ [BaseType(typeof(NSObject))]
	[BaseType(typeof(NSObject), Name = "TWCVideoConstraintsBuilder")]
	interface VideoConstraintsBuilder
	{
		// @property (assign, nonatomic) CMVideoDimensions maxSize;
		[Export("maxSize", ArgumentSemantic.Assign)]
		//mc++ CMVideoDimensions MaxSize { get; set; }
		IntPtr MaxSize { get; set; }

		// @property (assign, nonatomic) CMVideoDimensions minSize;
		[Export("minSize", ArgumentSemantic.Assign)]
		//mc++ CMVideoDimensions MinSize { get; set; }
		IntPtr MinSize { get; set; }

		// @property (assign, nonatomic) NSUInteger maxFrameRate;
		[Export("maxFrameRate")]
		nuint MaxFrameRate { get; set; }

		// @property (assign, nonatomic) NSUInteger minFrameRate;
		[Export("minFrameRate")]
		nuint MinFrameRate { get; set; }

		// @property (assign, nonatomic) TWCAspectRatio aspectRatio;
		[Export("aspectRatio", ArgumentSemantic.Assign)]
		TWCAspectRatio AspectRatio { get; set; }
	}

	// typedef void (^TWCVideoConstraintsBuilderBlock)(TWCVideoConstraintsBuilder * _Nonnull);
	delegate void /*TWC*/VideoConstraintsBuilderBlock(/*TWC*/VideoConstraintsBuilder arg0);

	// @interface TWCVideoConstraints : NSObject
	//mc++ [BaseType(typeof(NSObject))]
	[BaseType(typeof(NSObject), Name = "TWCVideoConstraints")]
	interface VideoConstraints
	{
		// +(instancetype _Null_unspecified)constraints;
		[Static]
		[Export("constraints")]
		/*TWC*/VideoConstraints Constraints();

		// +(instancetype _Null_unspecified)constraintsWithBlock:(TWCVideoConstraintsBuilderBlock _Nonnull)builderBlock;
		[Static]
		[Export("constraintsWithBlock:")]
		/*TWC*/VideoConstraints ConstraintsWithBlock(/*TWC*/VideoConstraintsBuilderBlock builderBlock);

		// @property (readonly, assign, nonatomic) CMVideoDimensions maxSize;
		[Export("maxSize", ArgumentSemantic.Assign)]
		//mc++ CMVideoDimensions MaxSize { get; }
		IntPtr MaxSize { get; }

		// @property (readonly, assign, nonatomic) CMVideoDimensions minSize;
		[Export("minSize", ArgumentSemantic.Assign)]
		//mc++ CMVideoDimensions MinSize { get; }
		IntPtr MinSize { get; }

		// @property (readonly, assign, nonatomic) NSUInteger maxFrameRate;
		[Export("maxFrameRate")]
		nuint MaxFrameRate { get; }

		// @property (readonly, assign, nonatomic) NSUInteger minFrameRate;
		[Export("minFrameRate")]
		nuint MinFrameRate { get; }

		// @property (readonly, assign, nonatomic) TWCAspectRatio aspectRatio;
		[Export("aspectRatio", ArgumentSemantic.Assign)]
		TWCAspectRatio AspectRatio { get; }
	}

	// @protocol TWCVideoRenderer <NSObject>
	[Protocol, Model]
	//mc++ [BaseType(typeof(NSObject))]
	[BaseType(typeof(NSObject), Name = "TWCVideoRenderer")]
	interface VideoRenderer
	{
		// @required -(void)renderFrame:(TWCI420Frame * _Nonnull)frame;
		[Abstract]
		[Export("renderFrame:")]
		void RenderFrame(/*TWC*/I420Frame frame);

		// @required -(void)updateVideoSize:(CMVideoDimensions)videoSize orientation:(TWCVideoOrientation)orientation;
		[Abstract]
		[Export("updateVideoSize:orientation:")]
		void UpdateVideoSize(CMVideoDimensions videoSize, /*TWC*/VideoOrientation orientation);

		// @optional -(BOOL)supportsVideoFrameOrientation;
		[Export("supportsVideoFrameOrientation")]
		//mc++ [Verify(MethodToProperty)]
		bool SupportsVideoFrameOrientation { get; }
	}

	// @protocol TWCVideoTrackDelegate <NSObject>
	[Protocol, Model]
	//mc++ [BaseType(typeof(NSObject))]
	[BaseType(typeof(NSObject), Name = "TWCVideoTrackDelegate")]
	interface VideoTrackDelegate
	{
		// @optional -(void)videoTrack:(TWCVideoTrack * _Nonnull)track dimensionsDidChange:(CMVideoDimensions)dimensions;
		[Export("videoTrack:dimensionsDidChange:")]
		void DimensionsDidChange(/*TWC*/VideoTrack track, CMVideoDimensions dimensions);
	}

	// @interface TWCVideoTrack : TWCMediaTrack
	//mc++ [BaseType(typeof(TWCMediaTrack))]
	[BaseType(typeof(/*TWC*/MediaTrack), Name = "TWCVideoTrack")]
	interface /*TWC*/VideoTrack
	{
		[Wrap("WeakDelegate")]
		[NullAllowed]
		/*TWC*/VideoTrackDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<TWCVideoTrackDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) NSArray<UIView *> * _Nonnull attachedViews;
		[Export("attachedViews", ArgumentSemantic.Strong)]
		UIView[] AttachedViews { get; }

		// @property (readonly, nonatomic, strong) NSArray<id<TWCVideoRenderer>> * _Nonnull renderers;
		[Export("renderers", ArgumentSemantic.Strong)]
		/*TWC*/VideoRenderer[] Renderers { get; }

		// @property (readonly, assign, nonatomic) CMVideoDimensions videoDimensions;
		[Export("videoDimensions", ArgumentSemantic.Assign)]
		//mc++ CMVideoDimensions VideoDimensions { get; }
		IntPtr VideoDimensions { get; }

		// -(void)attach:(UIView * _Nonnull)view;
		[Export("attach:")]
		void Attach(UIView view);

		// -(void)detach:(UIView * _Nonnull)view;
		[Export("detach:")]
		void Detach(UIView view);

		// -(void)addRenderer:(id<TWCVideoRenderer> _Nonnull)renderer;
		[Export("addRenderer:")]
		void AddRenderer(/*TWC*/VideoRenderer renderer);

		// -(void)removeRenderer:(id<TWCVideoRenderer> _Nonnull)renderer;
		[Export("removeRenderer:")]
		void RemoveRenderer(/*TWC*/VideoRenderer renderer);
	}

	// @interface TWCLocalVideoTrack : TWCVideoTrack
	//mc++ [BaseType(typeof(TWCVideoTrack))]
	[BaseType(typeof(/*TWC*/VideoTrack), Name = "TWCLocalVideoTrack")]
	interface /*TWC*/LocalVideoTrack
	{
		// -(instancetype _Nonnull)initWithCapturer:(id<TWCVideoCapturer> _Nonnull)capturer;
		[Export("initWithCapturer:")]
		IntPtr Constructor(/*TWC*/VideoCapturer capturer);

		// -(instancetype _Nonnull)initWithCapturer:(id<TWCVideoCapturer> _Nonnull)capturer constraints:(TWCVideoConstraints * _Nonnull)constraints;
		[Export("initWithCapturer:constraints:")]
		IntPtr Constructor(/*TWC*/VideoCapturer capturer, /*TWC*/VideoConstraints constraints);

		// @property (getter = isEnabled, assign, nonatomic) BOOL enabled;
		[Export("enabled")]
		bool Enabled { [Bind("isEnabled")] get; set; }

		// @property (readonly, nonatomic, strong) id<TWCVideoCapturer> _Nonnull capturer;
		[Export("capturer", ArgumentSemantic.Strong)]
		/*TWC*/VideoCapturer Capturer { get; }

		// @property (readonly, nonatomic, strong) TWCVideoConstraints * _Nonnull constraints;
		[Export("constraints", ArgumentSemantic.Strong)]
		/*TWC*/VideoConstraints Constraints { get; }
	}

	// @protocol TWCVideoViewRendererDelegate <NSObject>
	[Protocol, Model]
	//mc++ [BaseType(typeof(NSObject))]
	[BaseType(typeof(NSObject), Name = "TWCVideoViewRendererDelegate")]
	interface /*TWC*/VideoViewRendererDelegate
	{
		// @optional -(void)rendererDidReceiveVideoData:(TWCVideoViewRenderer * _Nonnull)renderer;
		[Export("rendererDidReceiveVideoData:")]
		void RendererDidReceiveVideoData(/*TWC*/VideoViewRenderer renderer);

		// @optional -(void)renderer:(TWCVideoViewRenderer * _Nonnull)renderer dimensionsDidChange:(CMVideoDimensions)dimensions;
		[Export("renderer:dimensionsDidChange:")]
		void Renderer(/*TWC*/VideoViewRenderer renderer, CMVideoDimensions dimensions);

		// @optional -(void)renderer:(TWCVideoViewRenderer * _Nonnull)renderer orientationDidChange:(TWCVideoOrientation)orientation;
		[Export("renderer:orientationDidChange:")]
		void Renderer(/*TWC*/VideoViewRenderer renderer, /*TWC*/VideoOrientation orientation);

		// @optional -(BOOL)rendererShouldRotateContent:(TWCVideoViewRenderer * _Nonnull)renderer;
		[Export("rendererShouldRotateContent:")]
		bool RendererShouldRotateContent(/*TWC*/VideoViewRenderer renderer);
	}

	// @interface TWCVideoViewRenderer : NSObject <TWCVideoRenderer>
	//mc++ [BaseType(typeof(NSObject))]
	[BaseType(typeof(NSObject), Name = "TWCVideoViewRenderer")]
	interface VideoViewRenderer : VideoRenderer
	{
		// -(instancetype _Nonnull)initWithDelegate:(id<TWCVideoViewRendererDelegate> _Nullable)delegate;
		[Export("initWithDelegate:")]
		IntPtr Constructor([NullAllowed] VideoViewRendererDelegate @delegate);

		// +(TWCVideoViewRenderer * _Nonnull)rendererWithDelegate:(id<TWCVideoViewRendererDelegate> _Nullable)delegate;
		[Static]
		[Export("rendererWithDelegate:")]
		VideoViewRenderer RendererWithDelegate([NullAllowed] VideoViewRendererDelegate @delegate);

		// +(TWCVideoViewRenderer * _Nonnull)rendererWithRenderingType:(TWCVideoRenderingType)renderingType delegate:(id<TWCVideoViewRendererDelegate> _Nullable)delegate;
		[Static]
		[Export("rendererWithRenderingType:delegate:")]
		VideoViewRenderer RendererWithRenderingType(VideoRenderingType renderingType, [NullAllowed] VideoViewRendererDelegate @delegate);

		[Wrap("WeakDelegate")]
		[NullAllowed]
		/*TWC*/VideoViewRendererDelegate Delegate { get; }

		// @property (readonly, nonatomic, weak) id<TWCVideoViewRendererDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; }

		// @property (readonly, assign, nonatomic) CMVideoDimensions videoFrameDimensions;
		[Export("videoFrameDimensions", ArgumentSemantic.Assign)]
		//mc++ CMVideoDimensions VideoFrameDimensions { get; }
		IntPtr VideoFrameDimensions { get; }

		// @property (readonly, assign, nonatomic) TWCVideoOrientation videoFrameOrientation;
		[Export("videoFrameOrientation", ArgumentSemantic.Assign)]
		/*TWC*/VideoOrientation VideoFrameOrientation { get; }

		// @property (readonly, assign, atomic) BOOL hasVideoData;
		[Export("hasVideoData")]
		bool HasVideoData { get; }

		// @property (readonly, nonatomic, strong) UIView * _Nonnull view;
		[Export("view", ArgumentSemantic.Strong)]
		UIView View { get; }
	}

	// @interface TWCMediaTrackStatsRecord : NSObject
	//mc++ [BaseType(typeof(NSObject))]
	[BaseType(typeof(NSObject), Name = "TWCMediaTrackStatsRecord")]
	interface /*TWC*/MediaTrackStatsRecord
	{
		// @property (readonly, nonatomic) NSString * trackId;
		[Export("trackId")]
		string TrackId { get; }

		// @property (readonly, nonatomic) NSUInteger packetsLost;
		[Export("packetsLost")]
		nuint PacketsLost { get; }

		// @property (readonly, nonatomic) NSString * direction;
		[Export("direction")]
		string Direction { get; }

		// @property (readonly, nonatomic) NSString * codecName;
		[Export("codecName")]
		string CodecName { get; }

		// @property (readonly, nonatomic) NSString * ssrc;
		[Export("ssrc")]
		string Ssrc { get; }

		// @property (readonly, nonatomic) NSString * participantSID;
		[Export("participantSID")]
		string ParticipantSID { get; }

		// @property (readonly, assign, nonatomic) CFTimeInterval timestamp;
		[Export("timestamp")]
		double Timestamp { get; }
	}

	// @interface TWCLocalVideoMediaStatsRecord : TWCMediaTrackStatsRecord
	//mc++ [BaseType(typeof(TWCMediaTrackStatsRecord))]
	[BaseType(typeof(/*TWC*/MediaTrackStatsRecord), Name = "TWCLocalVideoMediaStatsRecord")]
	interface /*TWC*/LocalVideoMediaStatsRecord
	{
		// @property (readonly, nonatomic) NSUInteger bytesSent;
		[Export("bytesSent")]
		nuint BytesSent { get; }

		// @property (readonly, nonatomic) NSUInteger packetsSent;
		[Export("packetsSent")]
		nuint PacketsSent { get; }

		// @property (readonly, assign, nonatomic) CMVideoDimensions captureDimensions;
		[Export("captureDimensions", ArgumentSemantic.Assign)]
		//mc++ CMVideoDimensions CaptureDimensions { get; }
		CMVideoDimensions CaptureDimensions { get; }

		// @property (readonly, assign, nonatomic) CMVideoDimensions sentDimensions;
		[Export("sentDimensions", ArgumentSemantic.Assign)]
		//mc++ CMVideoDimensions SentDimensions { get; }
		CMVideoDimensions SentDimensions { get; }

		// @property (readonly, nonatomic) NSUInteger frameRate;
		[Export("frameRate")]
		nuint FrameRate { get; }

		// @property (readonly, nonatomic) NSUInteger roundTripTime;
		[Export("roundTripTime")]
		nuint RoundTripTime { get; }
	}

	// @interface TWCLocalAudioMediaStatsRecord : TWCMediaTrackStatsRecord
	//mc++ [BaseType(typeof(TWCMediaTrackStatsRecord))]
	[BaseType(typeof(MediaTrackStatsRecord), Name = "TWCLocalAudioMediaStatsRecord")]
	interface /*TWC*/LocalAudioMediaStatsRecord
	{
		// @property (readonly, nonatomic) NSUInteger bytesSent;
		[Export("bytesSent")]
		nuint BytesSent { get; }

		// @property (readonly, nonatomic) NSUInteger packetsSent;
		[Export("packetsSent")]
		nuint PacketsSent { get; }

		// @property (readonly, nonatomic) NSUInteger audioInputLevel;
		[Export("audioInputLevel")]
		nuint AudioInputLevel { get; }

		// @property (readonly, nonatomic) NSUInteger jitterReceived;
		[Export("jitterReceived")]
		nuint JitterReceived { get; }

		// @property (readonly, nonatomic) NSUInteger jitter;
		[Export("jitter")]
		nuint Jitter { get; }

		// @property (readonly, nonatomic) NSUInteger roundTripTime;
		[Export("roundTripTime")]
		nuint RoundTripTime { get; }
	}

	// @interface TWCRemoteVideoMediaStatsRecord : TWCMediaTrackStatsRecord
	//mc++ [BaseType(typeof(TWCMediaTrackStatsRecord))]
	[BaseType(typeof(MediaTrackStatsRecord), Name = "TWCRemoteVideoMediaStatsRecord")]
	interface /*TWC*/RemoteVideoMediaStatsRecord
	{
		// @property (readonly, nonatomic) NSUInteger bytesReceived;
		[Export("bytesReceived")]
		nuint BytesReceived { get; }

		// @property (readonly, nonatomic) NSUInteger packetsReceived;
		[Export("packetsReceived")]
		nuint PacketsReceived { get; }

		// @property (readonly, assign, nonatomic) CMVideoDimensions dimensions;
		[Export("dimensions", ArgumentSemantic.Assign)]
		//mc++ CMVideoDimensions Dimensions { get; }
		IntPtr Dimensions { get; }

		// @property (readonly, nonatomic) NSUInteger frameRate;
		[Export("frameRate")]
		nuint FrameRate { get; }

		// @property (readonly, nonatomic) NSUInteger jitterBuffer;
		[Export("jitterBuffer")]
		nuint JitterBuffer { get; }
	}

	// @interface TWCRemoteAudioMediaStatsRecord : TWCMediaTrackStatsRecord
	//mc++ [BaseType(typeof(TWCMediaTrackStatsRecord))]
	[BaseType(typeof(MediaTrackStatsRecord), Name = "TWCRemoteAudioMediaStatsRecord")]
	interface /*TWC*/RemoteAudioMediaStatsRecord
	{
		// @property (readonly, nonatomic) NSUInteger bytesReceived;
		[Export("bytesReceived")]
		nuint BytesReceived { get; }

		// @property (readonly, nonatomic) NSUInteger packetsReceived;
		[Export("packetsReceived")]
		nuint PacketsReceived { get; }

		// @property (readonly, nonatomic) NSUInteger audioOutputLevel;
		[Export("audioOutputLevel")]
		nuint AudioOutputLevel { get; }

		// @property (readonly, nonatomic) NSUInteger jitterBuffer;
		[Export("jitterBuffer")]
		nuint JitterBuffer { get; }

		// @property (readonly, nonatomic) NSUInteger jitterReceived;
		[Export("jitterReceived")]
		nuint JitterReceived { get; }
	}

	[Static]
	//mc++ [Verify(ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const TWCConversationsErrorDomain;
		[Field("TWCConversationsErrorDomain", "__Internal")]
		NSString TWCConversationsErrorDomain { get; }
	}

	// @interface TwilioConversationsClient : NSObject
	//mc++ [BaseType(typeof(NSObject))]
	[BaseType(typeof(NSObject), Name = "TwilioConversationsClient")]
	interface TwilioConversationsClient
	{
		[Wrap("WeakDelegate")]
		[NullAllowed]
		TwilioConversationsClientDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<TwilioConversationsClientDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) TwilioAccessManager * _Nonnull accessManager;
		[Export("accessManager", ArgumentSemantic.Strong)]
		TwilioAccessManager AccessManager { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nullable identity;
		[NullAllowed, Export("identity", ArgumentSemantic.Strong)]
		string Identity { get; }

		// @property (readonly, assign, nonatomic) BOOL listening;
		[Export("listening")]
		bool Listening { get; }

		// +(TwilioConversationsClient * _Nullable)conversationsClientWithAccessManager:(TwilioAccessManager * _Nonnull)accessManager delegate:(id<TwilioConversationsClientDelegate> _Nullable)delegate;
		[Static]
		[Export("conversationsClientWithAccessManager:delegate:")]
		[return: NullAllowed]
		TwilioConversationsClient ConversationsClientWithAccessManager(TwilioAccessManager accessManager, [NullAllowed] TwilioConversationsClientDelegate @delegate);

		// +(TwilioConversationsClient * _Nullable)conversationsClientWithAccessManager:(TwilioAccessManager * _Nonnull)accessManager options:(TWCClientOptions * _Nullable)options delegateQueue:(dispatch_queue_t _Nullable)queue delegate:(id<TwilioConversationsClientDelegate> _Nullable)delegate;
		[Static]
		[Export("conversationsClientWithAccessManager:options:delegateQueue:delegate:")]
		[return: NullAllowed]
		TwilioConversationsClient ConversationsClientWithAccessManager(TwilioAccessManager accessManager, [NullAllowed] /*TWC*/ClientOptions options, [NullAllowed] DispatchQueue queue, [NullAllowed] TwilioConversationsClientDelegate @delegate);

		// -(void)listen;
		[Export("listen")]
		void Listen();

		// -(void)unlisten;
		[Export("unlisten")]
		void Unlisten();

		// -(TWCOutgoingInvite * _Nullable)inviteToConversation:(NSString * _Nonnull)client handler:(TWCInviteAcceptanceBlock _Nonnull)handler;
		[Export("inviteToConversation:handler:")]
		[return: NullAllowed]
		/*TWC*/OutgoingInvite InviteToConversation(string client, /*TWC*/InviteAcceptanceBlock handler);

		// -(TWCOutgoingInvite * _Nullable)inviteToConversation:(NSString * _Nonnull)client localMedia:(TWCLocalMedia * _Nonnull)localMedia handler:(TWCInviteAcceptanceBlock _Nonnull)handler;
		[Export("inviteToConversation:localMedia:handler:")]
		[return: NullAllowed]
		/*TWC*/OutgoingInvite InviteToConversation(string client, /*TWC*/LocalMedia localMedia, /*TWC*/InviteAcceptanceBlock handler);

		// -(TWCOutgoingInvite * _Nullable)inviteManyToConversation:(NSArray<NSString *> * _Nonnull)clients localMedia:(TWCLocalMedia * _Nonnull)localMedia handler:(TWCInviteAcceptanceBlock _Nonnull)handler;
		[Export("inviteManyToConversation:localMedia:handler:")]
		[return: NullAllowed]
		/*TWC*/OutgoingInvite InviteManyToConversation(string[] clients, /*TWC*/LocalMedia localMedia, /*TWC*/InviteAcceptanceBlock handler);

		// -(TWCOutgoingInvite * _Nullable)inviteManyToConversation:(NSArray<NSString *> * _Nonnull)clients localMedia:(TWCLocalMedia * _Nonnull)localMedia iceOptions:(TWCIceOptions * _Nonnull)iceOptions handler:(TWCInviteAcceptanceBlock _Nonnull)handler;
		[Export("inviteManyToConversation:localMedia:iceOptions:handler:")]
		[return: NullAllowed]
		/*TWC*/OutgoingInvite InviteManyToConversation(string[] clients, /*TWC*/LocalMedia localMedia, /*TWC*/IceOptions iceOptions, /*TWC*/InviteAcceptanceBlock handler);

		// +(NSString * _Nonnull)version;
		[Static]
		[Export("version")]
		//mc++ [Verify(MethodToProperty)]
		string Version { get; }

		// +(TWCLogLevel)logLevel;
		// +(void)setLogLevel:(TWCLogLevel)logLevel;
		[Static]
		[Export("logLevel")]
		//mc++ [Verify(MethodToProperty)]
		/*TWC*/LogLevel LogLevel { get; set; }

		// +(void)setLogLevel:(TWCLogLevel)logLevel module:(TWCLogModule)module;
		[Static]
		[Export("setLogLevel:module:")]
		void SetLogLevel(/*TWC*/LogLevel logLevel, /*TWC*/LogModule module);

		// +(void)setAudioOutput:(TWCAudioOutput)audioOutput;
		[Static]
		[Export("setAudioOutput:")]
		void SetAudioOutput(/*TWC*/AudioOutput audioOutput);

		// +(TWCAudioOutput)audioOutput;
		[Static]
		[Export("audioOutput")]
		/*TWC*/AudioOutput AudioOutput();
	}

	// @protocol TwilioConversationsClientDelegate <NSObject>
	[Protocol, Model]
	//mc++ [BaseType(typeof(NSObject))]
	[BaseType(typeof(NSObject), Name = "TwilioConversationsClientDelegate")]
	interface TwilioConversationsClientDelegate
	{
		// @optional -(void)conversationsClientDidStartListeningForInvites:(TwilioConversationsClient * _Nonnull)conversationsClient;
		[Export("conversationsClientDidStartListeningForInvites:")]
		void ConversationsClientDidStartListeningForInvites(TwilioConversationsClient conversationsClient);

		// @optional -(void)conversationsClient:(TwilioConversationsClient * _Nonnull)conversationsClient didFailToStartListeningWithError:(NSError * _Nonnull)error;
		[Export("conversationsClient:didFailToStartListeningWithError:")]
		void ConversationsClient(TwilioConversationsClient conversationsClient, NSError error);

		// @optional -(void)conversationsClientDidStopListeningForInvites:(TwilioConversationsClient * _Nonnull)conversationsClient error:(NSError * _Nullable)error;
		[Export("conversationsClientDidStopListeningForInvites:error:")]
		void ConversationsClientDidStopListeningForInvites(TwilioConversationsClient conversationsClient, [NullAllowed] NSError error);

		// @optional -(void)conversationsClient:(TwilioConversationsClient * _Nonnull)conversationsClient didReceiveInvite:(TWCIncomingInvite * _Nonnull)invite;
		[Export("conversationsClient:didReceiveInvite:")]
		void ConversationsClientInviteReceived(TwilioConversationsClient conversationsClient, /*TWC*/IncomingInvite invite);

		// @optional -(void)conversationsClient:(TwilioConversationsClient * _Nonnull)conversationsClient inviteDidCancel:(TWCIncomingInvite * _Nonnull)invite;
		[Export("conversationsClient:inviteDidCancel:")]
		void ConversationsClientInviteCancelled(TwilioConversationsClient conversationsClient, /*TWC*/IncomingInvite invite);
	}
}
