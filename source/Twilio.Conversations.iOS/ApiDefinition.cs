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
		/*mc++ TWC*/MediaTrackState State { get; }

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

	// Avoid linker stripping the following symbols
	// FieldAttribute does not support certain (all) types
	//		in this case structs (struct CMVideoDimensions)
	//		these symbols are used in Extra.Fields.cs
	// [Internal] 	// already applied
	// [Static]		// already applied
	//mc++ [Verify(ConstantsInterfaceAssociation)]
	partial interface VideoConstraintsFieldsSentinel //mc++Constants
	{
		// extern const CMVideoDimensions TWCVideoConstraintsSize352x288;
		[Field("TWCVideoConstraintsSize352x288", "__Internal")]
		//mc++ CMVideoDimensions TWCVideoConstraintsSize352x288 { get; }
		IntPtr /*mc++ VideoConstraints*/Size352x288 { get; }

		// extern const CMVideoDimensions TWCVideoConstraintsSize480x360;
		[Field("TWCVideoConstraintsSize480x360", "__Internal")]
		//mc++ CMVideoDimensions TWCVideoConstraintsSize480x360 { get; }
		IntPtr /*mc++ VideoConstraints*/Size480x360 { get; }

		// extern const CMVideoDimensions TWCVideoConstraintsSize640x480;
		[Field("TWCVideoConstraintsSize640x480", "__Internal")]
		//mc++ CMVideoDimensions TWCVideoConstraintsSize640x480 { get; }
		IntPtr /*mc++ VideoConstraints*/Size640x480 { get; }

		// extern const CMVideoDimensions TWCVideoConstraintsSize960x540;
		[Field("TWCVideoConstraintsSize960x540", "__Internal")]
		//mc++ CMVideoDimensions TWCVideoConstraintsSize960x540 { get; }
		IntPtr /*mc++ VideoConstraints*/Size960x540 { get; }

		// extern const CMVideoDimensions TWCVideoConstraintsSize1280x720;
		[Field("TWCVideoConstraintsSize1280x720", "__Internal")]
		//mc++ CMVideoDimensions TWCVideoConstraintsSize1280x720 { get; }
		IntPtr /*mc++ VideoConstraints*/Size1280x720 { get; }

		// extern const CMVideoDimensions TWCVideoConstraintsSize1280x960;
		[Field("TWCVideoConstraintsSize1280x960", "__Internal")]
		//mc++ CMVideoDimensions TWCVideoConstraintsSize1280x960 { get; }
		IntPtr /*mc++ VideoConstraints*/Size1280x960 { get; }

		// extern const NSUInteger TWCVideoConstraintsFrameRate30;
		[Field("TWCVideoConstraintsFrameRate30", "__Internal")]
		nuint /*mc++ VideoConstraints*/FrameRate30 { get; }

		// extern const NSUInteger TWCVideoConstraintsFrameRate24;
		[Field("TWCVideoConstraintsFrameRate24", "__Internal")]
		nuint /*mc++ VideoConstraints*/FrameRate24 { get; }

		// extern const NSUInteger TWCVideoConstraintsFrameRate20;
		[Field("TWCVideoConstraintsFrameRate20", "__Internal")]
		nuint /*mc++ VideoConstraints*/FrameRate20 { get; }

		// extern const NSUInteger TWCVideoConstraintsFrameRate15;
		[Field("TWCVideoConstraintsFrameRate15", "__Internal")]
		nuint /*mc++ VideoConstraints*/FrameRate15 { get; }

		// extern const NSUInteger TWCVideoConstraintsFrameRate10;
		[Field("TWCVideoConstraintsFrameRate10", "__Internal")]
		nuint /*mc++ VideoConstraints*/FrameRate10 { get; }
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
		IntPtr Constructor([NullAllowed] /*mc++ TWC*/CameraCapturerDelegate @delegate, /*mc++ TWC*/VideoCaptureSource source);

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
		/*mc++ TWC*/IceOptions IceOptions { get; }

		// @property (readonly, assign, nonatomic) BOOL preferH264;
		[Export("preferH264")]
		bool PreferH264 { get; }

		// -(instancetype _Null_unspecified)initWithIceOptions:(TWCIceOptions * _Nonnull)options;
		[Export("initWithIceOptions:")]
		IntPtr Constructor(/*mc++ TWC*/IceOptions options);

		// -(instancetype _Null_unspecified)initWithIceOptions:(TWCIceOptions * _Nonnull)options preferH264:(BOOL)preferH264;
		[Export("initWithIceOptions:preferH264:")]
		IntPtr Constructor(/*mc++ TWC*/IceOptions options, bool preferH264);
	}

	// typedef void (^TWCInviteAcceptanceBlock)(TWCConversation * _Nullable, NSError * _Nullable);
	delegate void /*mc++ TWC*/InviteAcceptanceBlock([NullAllowed] /*mc++ TWC*/Conversation arg0, [NullAllowed] NSError arg1);

	// @interface TWCOutgoingInvite : NSObject
	//mc++ [BaseType(typeof(NSObject))]
	[BaseType(typeof(NSObject), Name = "TWCOutgoingInvite")]
	interface /*mc++ TWC*/OutgoingInvite
	{
		// @property (readonly, assign, nonatomic) TWCInviteStatus status;
		[Export("status", ArgumentSemantic.Assign)]
		/*mc++ TWC*/InviteStatus Status { get; }

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
	interface /*mc++ TWC*/Media
	{
		// @property (readonly, nonatomic, strong) NSArray<TWCAudioTrack *> * _Nonnull audioTracks;
		[Export("audioTracks", ArgumentSemantic.Strong)]
		/*mc++ TWC*/AudioTrack[] AudioTracks { get; }

		// @property (readonly, nonatomic, strong) NSArray<TWCVideoTrack *> * _Nonnull videoTracks;
		[Export("videoTracks", ArgumentSemantic.Strong)]
		/*mc++ TWC*/VideoTrack[] VideoTracks { get; }

		// -(TWCMediaTrack * _Nullable)getTrack:(NSString * _Nonnull)trackId;
		[Export("getTrack:")]
		[return: NullAllowed]
		/*mc++ TWC*/MediaTrack GetTrack(string trackId);
	}

	// @protocol TWCLocalMediaDelegate <NSObject>
	[Protocol, Model]
	//mc++ [BaseType(typeof(NSObject))]
	[BaseType(typeof(NSObject), Name = "TWCLocalMediaDelegate")]
	interface LocalMediaDelegate
	{
		// @optional -(void)localMedia:(TWCLocalMedia * _Nonnull)media didAddVideoTrack:(TWCVideoTrack * _Nonnull)videoTrack;
		[Export("localMedia:didAddVideoTrack:")]
		void DidAddVideoTrack(/*mc++ TWC*/LocalMedia media, /*mc++ TWC*/VideoTrack videoTrack);

		// @optional -(void)localMedia:(TWCLocalMedia * _Nonnull)media didFailToAddVideoTrack:(TWCVideoTrack * _Nonnull)videoTrack error:(NSError * _Nonnull)error;
		[Export("localMedia:didFailToAddVideoTrack:error:")]
		void DidFailToAddVideoTrack(/*mc++ TWC*/LocalMedia media, /*mc++ TWC*/VideoTrack videoTrack, NSError error);

		// @optional -(void)localMedia:(TWCLocalMedia * _Nonnull)media didRemoveVideoTrack:(TWCVideoTrack * _Nonnull)videoTrack;
		[Export("localMedia:didRemoveVideoTrack:")]
		void DidRemoveVideoTrack(/*mc++ TWC*/LocalMedia media, /*mc++ TWC*/VideoTrack videoTrack);
	}

	// @interface TWCLocalMedia : TWCMedia
	//mc++ [BaseType(typeof(TWCMedia))]
	[BaseType(typeof(/*mc++ TWC*/Media), Name = "TWCLocalMedia")]
	interface /*mc++ TWC*/LocalMedia
	{
		// @property (getter = isMicrophoneMuted, assign, nonatomic) BOOL microphoneMuted;
		[Export("microphoneMuted")]
		bool MicrophoneMuted { [Bind("isMicrophoneMuted")] get; set; }

		// @property (readonly, getter = isMicrophoneAdded, assign, nonatomic) BOOL microphoneAdded;
		[Export("microphoneAdded")]
		bool MicrophoneAdded { [Bind("isMicrophoneAdded")] get; }

		[Wrap("WeakDelegate")]
		[NullAllowed]
		/*mc++ TWC*/LocalMediaDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<TWCLocalMediaDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// -(instancetype _Nullable)initWithDelegate:(id<TWCLocalMediaDelegate> _Nullable)delegate;
		[Export("initWithDelegate:")]
		IntPtr Constructor([NullAllowed] /*mc++ TWC*/LocalMediaDelegate @delegate);

		// -(BOOL)addTrack:(TWCVideoTrack * _Nonnull)track;
		[Export("addTrack:")]
		bool AddTrack(/*mc++ TWC*/VideoTrack track);

		// -(BOOL)addTrack:(TWCVideoTrack * _Nonnull)track error:(NSError * _Nullable * _Nullable)error;
		[Export("addTrack:error:")]
		bool AddTrack(/*mc++ TWC*/VideoTrack track, [NullAllowed] out NSError error);

		// -(BOOL)removeTrack:(TWCVideoTrack * _Nonnull)track;
		[Export("removeTrack:")]
		bool RemoveTrack(/*mc++ TWC*/VideoTrack track);

		// -(BOOL)removeTrack:(TWCVideoTrack * _Nonnull)track error:(NSError * _Nullable * _Nullable)error;
		[Export("removeTrack:error:")]
		bool RemoveTrack(/*mc++ TWC*/VideoTrack track, [NullAllowed] out NSError error);

		// -(TWCCameraCapturer * _Nullable)addCameraTrack;
		[NullAllowed, Export("addCameraTrack")]
		//mc++ [Verify(MethodToProperty)]
		/*mc++ TWC*/CameraCapturer AddCameraTrack(); //mc++ { get; }

		// -(TWCCameraCapturer * _Nullable)addCameraTrack:(NSError * _Nullable * _Nullable)error;
		[Export("addCameraTrack:")]
		[return: NullAllowed]
		/*mc++ TWC*/CameraCapturer AddCameraTrack([NullAllowed] out NSError error);

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
		void AddedVideoTrack(/*mc++ TWC*/Participant participant, /*mc++ TWC*/VideoTrack videoTrack);

		// @optional -(void)participant:(TWCParticipant * _Nonnull)participant removedVideoTrack:(TWCVideoTrack * _Nonnull)videoTrack;
		[Export("participant:removedVideoTrack:")]
		void RemovedVideoTrack(/*mc++ TWC*/Participant participant, /*mc++ TWC*/VideoTrack videoTrack);

		// @optional -(void)participant:(TWCParticipant * _Nonnull)participant addedAudioTrack:(TWCAudioTrack * _Nonnull)audioTrack;
		[Export("participant:addedAudioTrack:")]
		void AddedAudioTrack(/*mc++ TWC*/Participant participant, /*mc++ TWC*/AudioTrack audioTrack);

		// @optional -(void)participant:(TWCParticipant * _Nonnull)participant removedAudioTrack:(TWCAudioTrack * _Nonnull)audioTrack;
		[Export("participant:removedAudioTrack:")]
		void RemovedAudioTrack(/*mc++ TWC*/Participant participant, /*mc++ TWC*/AudioTrack audioTrack);

		// @optional -(void)participant:(TWCParticipant * _Nonnull)participant disabledTrack:(TWCMediaTrack * _Nonnull)track;
		[Export("participant:disabledTrack:")]
		void DisabledTrack(/*mc++ TWC*/Participant participant, /*mc++ TWC*/MediaTrack track);

		// @optional -(void)participant:(TWCParticipant * _Nonnull)participant enabledTrack:(TWCMediaTrack * _Nonnull)track;
		[Export("participant:enabledTrack:")]
		void EnabledTrack(/*mc++ TWC*/Participant participant, /*mc++ TWC*/MediaTrack track);
	}

	// @interface TWCParticipant : NSObject
	//mc++ [BaseType(typeof(NSObject))]
	[BaseType(typeof(NSObject), Name = "TWCParticipant")]
	interface /*mc++ TWC*/Participant
	{
		// @property (readonly, nonatomic, strong) NSString * _Nonnull identity;
		[Export("identity", ArgumentSemantic.Strong)]
		string Identity { get; }

		// @property (readonly, nonatomic, weak) TWCConversation * _Null_unspecified conversation;
		[Export("conversation", ArgumentSemantic.Weak)]
		/*mc++ TWC*/Conversation Conversation { get; }

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
		/*mc++ TWC*/Participant[] Participants { get; }

		// @property (readonly, nonatomic, strong) TWCLocalMedia * _Nullable localMedia;
		[NullAllowed, Export("localMedia", ArgumentSemantic.Strong)]
		/*mc++ TWC*/LocalMedia LocalMedia { get; }

		[Wrap("WeakDelegate")]
		[NullAllowed]
		/*mc++ TWC*/ConversationDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<TWCConversationDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		[Wrap("WeakStatisticsDelegate")]
		[NullAllowed]
		/*mc++ TWC*/MediaTrackStatisticsDelegate StatisticsDelegate { get; set; }

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
		/*mc++ TWC*/Participant GetParticipant(string participantSID);
	}

	// @protocol TWCConversationDelegate <NSObject>
	[Protocol, Model]
	//mc++ [BaseType(typeof(NSObject))]
	[BaseType(typeof(NSObject), Name = "TWCConversationDelegate")]
	interface ConversationDelegate
	{
		// @optional -(void)conversation:(TWCConversation * _Nonnull)conversation didConnectParticipant:(TWCParticipant * _Nonnull)participant;
		[Export("conversation:didConnectParticipant:")]
		void ConversationDidConnectParticipant(/*mc++ TWC*/Conversation conversation, /*mc++ TWC*/Participant participant);

		// @optional -(void)conversation:(TWCConversation * _Nonnull)conversation didFailToConnectParticipant:(TWCParticipant * _Nonnull)participant error:(NSError * _Nonnull)error;
		[Export("conversation:didFailToConnectParticipant:error:")]
		void Conversation(/*mc++ TWC*/Conversation conversation, /*mc++ TWC*/Participant participant, NSError error);

		// @optional -(void)conversation:(TWCConversation * _Nonnull)conversation didDisconnectParticipant:(TWCParticipant * _Nonnull)participant;
		[Export("conversation:didDisconnectParticipant:")]
		void ConversationDidDisconnectParticipant(/*mc++ TWC*/Conversation conversation, /*mc++ TWC*/Participant participant);

		// @optional -(void)conversationEnded:(TWCConversation * _Nonnull)conversation;
		[Export("conversationEnded:")]
		void ConversationEnded(/*mc++ TWC*/Conversation conversation);

		// @optional -(void)conversationEnded:(TWCConversation * _Nonnull)conversation error:(NSError * _Nonnull)error;
		[Export("conversationEnded:error:")]
		void ConversationEnded(/*mc++ TWC*/Conversation conversation, NSError error);
	}

	// @protocol TWCMediaTrackStatisticsDelegate <NSObject>
	[Protocol, Model]
	//mc++ [BaseType(typeof(NSObject))]
	[BaseType(typeof(NSObject), Name = "TWCMediaTrackStatisticsDelegate")]
	interface /*mc++ TWC*/MediaTrackStatisticsDelegate
	{
		// @required -(void)conversation:(TWCConversation * _Nonnull)conversation didReceiveTrackStatistics:(TWCMediaTrackStatsRecord * _Nonnull)trackStatistics;
		[Abstract]
		[Export("conversation:didReceiveTrackStatistics:")]
		void DidReceiveTrackStatistics(/*mc++ TWC*/Conversation conversation, /*mc++ TWC*/MediaTrackStatsRecord trackStatistics);
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
		/*mc++ TWC*/InviteStatus Status { get; }

		// -(void)acceptWithCompletion:(TWCInviteAcceptanceBlock _Nonnull)acceptHandler;
		[Export("acceptWithCompletion:")]
		void AcceptWithCompletion(/*mc++ TWC*/InviteAcceptanceBlock acceptHandler);

		// -(void)acceptWithLocalMedia:(TWCLocalMedia * _Nonnull)localMedia completion:(TWCInviteAcceptanceBlock _Nonnull)acceptHandler;
		[Export("acceptWithLocalMedia:completion:")]
		void AcceptWithLocalMedia(/*mc++ TWC*/LocalMedia localMedia, /*mc++ TWC*/InviteAcceptanceBlock acceptHandler);

		// -(void)acceptWithLocalMedia:(TWCLocalMedia * _Nonnull)localMedia iceOptions:(TWCIceOptions * _Nonnull)iceOptions completion:(TWCInviteAcceptanceBlock _Nonnull)acceptHandler;
		[Export("acceptWithLocalMedia:iceOptions:completion:")]
		void AcceptWithLocalMedia(/*mc++ TWC*/LocalMedia localMedia, /*mc++ TWC*/IceOptions iceOptions, /*mc++ TWC*/InviteAcceptanceBlock acceptHandler);

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
		/*mc++ TWC*/IceServer[] IceServers { get; }

		// @property (readonly, assign, nonatomic) TWCIceTransportPolicy iceTransportPolicy;
		[Export("iceTransportPolicy", ArgumentSemantic.Assign)]
		/*mc++ TWC*/IceTransportPolicy IceTransportPolicy { get; }

		// -(instancetype _Null_unspecified)initWithTransportPolicy:(TWCIceTransportPolicy)transportPolicy;
		[Export("initWithTransportPolicy:")]
		IntPtr Constructor(/*mc++ TWC*/IceTransportPolicy transportPolicy);

		// -(instancetype _Null_unspecified)initWithTransportPolicy:(TWCIceTransportPolicy)transportPolicy servers:(NSArray<TWCIceServer *> * _Nonnull)servers;
		[Export("initWithTransportPolicy:servers:")]
		IntPtr Constructor(/*mc++ TWC*/IceTransportPolicy transportPolicy, /*mc++ TWC*/IceServer[] servers);
	}

	// @interface TWCI420Frame : NSObject
	//mc++ [BaseType(typeof(NSObject))]
	[BaseType(typeof(NSObject), Name = "TWCI420Frame")]
	interface /*mc++ TWC*/I420Frame
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
		/*mc++ TWC*/VideoOrientation Orientation { get; }

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

	// Avoid linker stripping the following symbols
	// FieldAttribute does not support certain (all) types
	//		in this case structs (struct CMVideoDimensions)
	//		these symbols are used in Extra.Fields.cs
	[Internal]
	[Static]
	//mc++ [Verify(ConstantsInterfaceAssociation)]
	partial interface VideoConstraintsFieldsSentinel //mc++Constants
	{
		// extern const NSUInteger TWCVideoConstraintsMaximumFPS;
		[Field("TWCVideoConstraintsMaximumFPS", "__Internal")]
		/*mc++ nuint*/ IntPtr /*mc++ TWC*/VideoConstraintsMaximumFPS { get; }

		// extern const NSUInteger TWCVideoConstraintsMinimumFPS;
		[Field("TWCVideoConstraintsMinimumFPS", "__Internal")]
		/*mc++ nuint*/ IntPtr /*mc++ TWC*/VideoConstraintsMinimumFPS { get; }

		// extern const CMVideoDimensions TWCVideoSizeConstraintsNone;
		[Field("TWCVideoSizeConstraintsNone", "__Internal")]
		//mc++ CMVideoDimensions TWCVideoSizeConstraintsNone { get; }
		IntPtr /*mc++ TWC*/VideoSizeConstraintsNone { get; }

		// extern const NSUInteger TWCVideoFrameRateConstraintsNone;
		[Field("TWCVideoFrameRateConstraintsNone", "__Internal")]
		/*mc++ nuint*/ IntPtr /*TWC*/VideoFrameRateConstraintsNone { get; }

		// extern const TWCAspectRatio TWCVideoAspectRatioConstraintsNone;
		[Field("TWCVideoAspectRatioConstraintsNone", "__Internal")]
		//mc++ TWCAspectRatio TWCVideoAspectRatioConstraintsNone { get; }
		IntPtr /*TWCVideo*/AspectRatioConstraintsNone { get; }

		// extern const TWCAspectRatio TWCAspectRatio11x9;
		[Field("TWCAspectRatio11x9", "__Internal")]
		//mc++ TWCAspectRatio TWCAspectRatio11x9 { get; }
		IntPtr /*TWC*/AspectRatio11x9 { get; }

		// extern const TWCAspectRatio TWCAspectRatio4x3;
		[Field("TWCAspectRatio4x3", "__Internal")]
		//mc++ TWCAspectRatio TWCAspectRatio4x3 { get; }
		IntPtr /*TWC*/AspectRatio4x3 { get; }

		// extern const TWCAspectRatio TWCAspectRatio16x9;
		[Field("TWCAspectRatio16x9", "__Internal")]
		//mc++TWCAspectRatio TWCAspectRatio16x9 { get; }
		IntPtr /*TWC*/AspectRatio16x9 { get; }
	}

	// @interface TWCVideoConstraintsBuilder : NSObject
	//mc++ [BaseType(typeof(NSObject))]
	[BaseType(typeof(NSObject), Name = "TWCVideoConstraintsBuilder")]
	interface VideoConstraintsBuilder
	{
		// @property (assign, nonatomic) CMVideoDimensions maxSize;
		[Export("maxSize", ArgumentSemantic.Assign)]
		//mc++ CMVideoDimensions MaxSize { get; set; }
		CMVideoDimensions MaxSize { get; set; }

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
		/*TWC*/AspectRatio AspectRatio { get; set; }
	}

	// typedef void (^TWCVideoConstraintsBuilderBlock)(TWCVideoConstraintsBuilder * _Nonnull);
	delegate void /*mc++ TWC*/VideoConstraintsBuilderBlock(/*mc++ TWC*/VideoConstraintsBuilder arg0);

	// @interface TWCVideoConstraints : NSObject
	//mc++ [BaseType(typeof(NSObject))]
	[BaseType(typeof(NSObject), Name = "TWCVideoConstraints")]
	interface VideoConstraints
	{
		// +(instancetype _Null_unspecified)constraints;
		[Static]
		[Export("constraints")]
		/*mc++ TWC*/VideoConstraints Constraints();

		// +(instancetype _Null_unspecified)constraintsWithBlock:(TWCVideoConstraintsBuilderBlock _Nonnull)builderBlock;
		[Static]
		[Export("constraintsWithBlock:")]
		/*mc++ TWC*/VideoConstraints ConstraintsWithBlock(/*mc++ TWC*/VideoConstraintsBuilderBlock builderBlock);

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
		/*TWC*/AspectRatio AspectRatio { get; }
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
		void RenderFrame(/*mc++ TWC*/I420Frame frame);

		// @required -(void)updateVideoSize:(CMVideoDimensions)videoSize orientation:(TWCVideoOrientation)orientation;
		[Abstract]
		[Export("updateVideoSize:orientation:")]
		void UpdateVideoSize(CMVideoDimensions videoSize, /*mc++ TWC*/VideoOrientation orientation);

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
		void DimensionsDidChange(/*mc++ TWC*/VideoTrack track, CMVideoDimensions dimensions);
	}

	// @interface TWCVideoTrack : TWCMediaTrack
	//mc++ [BaseType(typeof(TWCMediaTrack))]
	[BaseType(typeof(/*mc++ TWC*/MediaTrack), Name = "TWCVideoTrack")]
	interface /*mc++ TWC*/VideoTrack
	{
		[Wrap("WeakDelegate")]
		[NullAllowed]
		/*mc++ TWC*/VideoTrackDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<TWCVideoTrackDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) NSArray<UIView *> * _Nonnull attachedViews;
		[Export("attachedViews", ArgumentSemantic.Strong)]
		UIView[] AttachedViews { get; }

		// @property (readonly, nonatomic, strong) NSArray<id<TWCVideoRenderer>> * _Nonnull renderers;
		[Export("renderers", ArgumentSemantic.Strong)]
		/*mc++ TWC*/VideoRenderer[] Renderers { get; }

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
		void AddRenderer(/*mc++ TWC*/VideoRenderer renderer);

		// -(void)removeRenderer:(id<TWCVideoRenderer> _Nonnull)renderer;
		[Export("removeRenderer:")]
		void RemoveRenderer(/*mc++ TWC*/VideoRenderer renderer);
	}

	// @interface TWCLocalVideoTrack : TWCVideoTrack
	//mc++ [BaseType(typeof(TWCVideoTrack))]
	[BaseType(typeof(/*mc++ TWC*/VideoTrack), Name = "TWCLocalVideoTrack")]
	interface /*mc++ TWC*/LocalVideoTrack
	{
		// -(instancetype _Nonnull)initWithCapturer:(id<TWCVideoCapturer> _Nonnull)capturer;
		[Export("initWithCapturer:")]
		IntPtr Constructor(/*mc++ TWC*/VideoCapturer capturer);

		// -(instancetype _Nonnull)initWithCapturer:(id<TWCVideoCapturer> _Nonnull)capturer constraints:(TWCVideoConstraints * _Nonnull)constraints;
		[Export("initWithCapturer:constraints:")]
		IntPtr Constructor(/*mc++ TWC*/VideoCapturer capturer, /*mc++ TWC*/VideoConstraints constraints);

		// @property (getter = isEnabled, assign, nonatomic) BOOL enabled;
		[Export("enabled")]
		bool Enabled { [Bind("isEnabled")] get; set; }

		// @property (readonly, nonatomic, strong) id<TWCVideoCapturer> _Nonnull capturer;
		[Export("capturer", ArgumentSemantic.Strong)]
		/*mc++ TWC*/VideoCapturer Capturer { get; }

		// @property (readonly, nonatomic, strong) TWCVideoConstraints * _Nonnull constraints;
		[Export("constraints", ArgumentSemantic.Strong)]
		/*mc++ TWC*/VideoConstraints Constraints { get; }
	}

	// @protocol TWCVideoViewRendererDelegate <NSObject>
	[Protocol, Model]
	//mc++ [BaseType(typeof(NSObject))]
	[BaseType(typeof(NSObject), Name = "TWCVideoViewRendererDelegate")]
	interface /*mc++ TWC*/VideoViewRendererDelegate
	{
		// @optional -(void)rendererDidReceiveVideoData:(TWCVideoViewRenderer * _Nonnull)renderer;
		[Export("rendererDidReceiveVideoData:")]
		void RendererDidReceiveVideoData(/*mc++ TWC*/VideoViewRenderer renderer);

		// @optional -(void)renderer:(TWCVideoViewRenderer * _Nonnull)renderer dimensionsDidChange:(CMVideoDimensions)dimensions;
		[Export("renderer:dimensionsDidChange:")]
		void Renderer(/*mc++ TWC*/VideoViewRenderer renderer, CMVideoDimensions dimensions);

		// @optional -(void)renderer:(TWCVideoViewRenderer * _Nonnull)renderer orientationDidChange:(TWCVideoOrientation)orientation;
		[Export("renderer:orientationDidChange:")]
		void Renderer(/*mc++ TWC*/VideoViewRenderer renderer, /*mc++ TWC*/VideoOrientation orientation);

		// @optional -(BOOL)rendererShouldRotateContent:(TWCVideoViewRenderer * _Nonnull)renderer;
		[Export("rendererShouldRotateContent:")]
		bool RendererShouldRotateContent(/*mc++ TWC*/VideoViewRenderer renderer);
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
		/*mc++ TWC*/VideoViewRendererDelegate Delegate { get; }

		// @property (readonly, nonatomic, weak) id<TWCVideoViewRendererDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; }

		// @property (readonly, assign, nonatomic) CMVideoDimensions videoFrameDimensions;
		[Export("videoFrameDimensions", ArgumentSemantic.Assign)]
		//mc++ CMVideoDimensions VideoFrameDimensions { get; }
		IntPtr VideoFrameDimensions { get; }

		// @property (readonly, assign, nonatomic) TWCVideoOrientation videoFrameOrientation;
		[Export("videoFrameOrientation", ArgumentSemantic.Assign)]
		/*mc++ TWC*/VideoOrientation VideoFrameOrientation { get; }

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
	interface /*mc++ TWC*/MediaTrackStatsRecord
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
	[BaseType(typeof(/*mc++ TWC*/MediaTrackStatsRecord), Name = "TWCLocalVideoMediaStatsRecord")]
	interface /*mc++ TWC*/LocalVideoMediaStatsRecord
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
	interface /*mc++ TWC*/LocalAudioMediaStatsRecord
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
	interface /*mc++ TWC*/RemoteVideoMediaStatsRecord
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
	interface /*mc++ TWC*/RemoteAudioMediaStatsRecord
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
		NSString /*mc++ TWC*/ConversationsErrorDomain { get; }
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
		TwilioConversationsClient ConversationsClientWithAccessManager(TwilioAccessManager accessManager, [NullAllowed] /*mc++ TWC*/ClientOptions options, [NullAllowed] DispatchQueue queue, [NullAllowed] TwilioConversationsClientDelegate @delegate);

		// -(void)listen;
		[Export("listen")]
		void Listen();

		// -(void)unlisten;
		[Export("unlisten")]
		void Unlisten();

		// -(TWCOutgoingInvite * _Nullable)inviteToConversation:(NSString * _Nonnull)client handler:(TWCInviteAcceptanceBlock _Nonnull)handler;
		[Export("inviteToConversation:handler:")]
		[return: NullAllowed]
		/*mc++ TWC*/OutgoingInvite InviteToConversation(string client, /*mc++ TWC*/InviteAcceptanceBlock handler);

		// -(TWCOutgoingInvite * _Nullable)inviteToConversation:(NSString * _Nonnull)client localMedia:(TWCLocalMedia * _Nonnull)localMedia handler:(TWCInviteAcceptanceBlock _Nonnull)handler;
		[Export("inviteToConversation:localMedia:handler:")]
		[return: NullAllowed]
		/*mc++ TWC*/OutgoingInvite InviteToConversation(string client, /*mc++ TWC*/LocalMedia localMedia, /*mc++ TWC*/InviteAcceptanceBlock handler);

		// -(TWCOutgoingInvite * _Nullable)inviteManyToConversation:(NSArray<NSString *> * _Nonnull)clients localMedia:(TWCLocalMedia * _Nonnull)localMedia handler:(TWCInviteAcceptanceBlock _Nonnull)handler;
		[Export("inviteManyToConversation:localMedia:handler:")]
		[return: NullAllowed]
		/*mc++ TWC*/OutgoingInvite InviteManyToConversation(string[] clients, /*mc++ TWC*/LocalMedia localMedia, /*mc++ TWC*/InviteAcceptanceBlock handler);

		// -(TWCOutgoingInvite * _Nullable)inviteManyToConversation:(NSArray<NSString *> * _Nonnull)clients localMedia:(TWCLocalMedia * _Nonnull)localMedia iceOptions:(TWCIceOptions * _Nonnull)iceOptions handler:(TWCInviteAcceptanceBlock _Nonnull)handler;
		[Export("inviteManyToConversation:localMedia:iceOptions:handler:")]
		[return: NullAllowed]
		/*mc++ TWC*/OutgoingInvite InviteManyToConversation(string[] clients, /*mc++ TWC*/LocalMedia localMedia, /*mc++ TWC*/IceOptions iceOptions, /*mc++ TWC*/InviteAcceptanceBlock handler);

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
		/*mc++ TWC*/LogLevel LogLevel { get; set; }

		// +(void)setLogLevel:(TWCLogLevel)logLevel module:(TWCLogModule)module;
		[Static]
		[Export("setLogLevel:module:")]
		void SetLogLevel(/*mc++ TWC*/LogLevel logLevel, /*mc++ TWC*/LogModule module);

		// +(void)setAudioOutput:(TWCAudioOutput)audioOutput;
		[Static]
		[Export("setAudioOutput:")]
		void SetAudioOutput(/*mc++ TWC*/AudioOutput audioOutput);

		// +(TWCAudioOutput)audioOutput;
		[Static]
		[Export("audioOutput")]
		/*mc++ TWC*/AudioOutput AudioOutput();
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
		void ConversationsClientInviteReceived(TwilioConversationsClient conversationsClient, /*mc++ TWC*/IncomingInvite invite);

		// @optional -(void)conversationsClient:(TwilioConversationsClient * _Nonnull)conversationsClient inviteDidCancel:(TWCIncomingInvite * _Nonnull)invite;
		[Export("conversationsClient:inviteDidCancel:")]
		void ConversationsClientInviteCancelled(TwilioConversationsClient conversationsClient, /*mc++ TWC*/IncomingInvite invite);
	}
}
