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
	[BaseType(typeof(NSObject))]
	interface TWCMediaTrack
	{
		// @property (readonly, getter = isEnabled, assign, nonatomic) BOOL enabled;
		[Export("enabled")]
		bool Enabled { [Bind("isEnabled")] get; }

		// @property (readonly, assign, nonatomic) TWCMediaTrackState state;
		[Export("state", ArgumentSemantic.Assign)]
		TWCMediaTrackState State { get; }

		// @property (readonly, copy, nonatomic) NSString * trackId;
		[Export("trackId")]
		string TrackId { get; }
	}

	// @interface TWCAudioTrack : TWCMediaTrack
	[BaseType(typeof(TWCMediaTrack))]
	interface TWCAudioTrack
	{
	}

	// @protocol TWCVideoCapturer <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface TWCVideoCapturer
	{
		// @required @property (readonly, getter = isCapturing, assign, atomic) BOOL capturing;
		[Abstract]
		[Export("capturing")]
		bool Capturing { [Bind("isCapturing")] get; }

		// @required @property (nonatomic, weak) TWCLocalVideoTrack * _Nullable videoTrack;
		[Abstract]
		[NullAllowed, Export("videoTrack", ArgumentSemantic.Weak)]
		TWCLocalVideoTrack VideoTrack { get; set; }
	}

	//mc++ [Static]
	//mc++ [Verify(ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern const CMVideoDimensions TWCVideoConstraintsSize352x288;
		[Field("TWCVideoConstraintsSize352x288", "__Internal")]
		//mc++ CMVideoDimensions TWCVideoConstraintsSize352x288 { get; }
		IntPtr TWCVideoConstraintsSize352x288 { get; }

		// extern const CMVideoDimensions TWCVideoConstraintsSize480x360;
		[Field("TWCVideoConstraintsSize480x360", "__Internal")]
		//mc++ CMVideoDimensions TWCVideoConstraintsSize480x360 { get; }
		IntPtr TWCVideoConstraintsSize480x360 { get; }

		// extern const CMVideoDimensions TWCVideoConstraintsSize640x480;
		[Field("TWCVideoConstraintsSize640x480", "__Internal")]
		//mc++ CMVideoDimensions TWCVideoConstraintsSize640x480 { get; }
		IntPtr TWCVideoConstraintsSize640x480 { get; }

		// extern const CMVideoDimensions TWCVideoConstraintsSize960x540;
		[Field("TWCVideoConstraintsSize960x540", "__Internal")]
		//mc++ CMVideoDimensions TWCVideoConstraintsSize960x540 { get; }
		IntPtr TWCVideoConstraintsSize960x540 { get; }

		// extern const CMVideoDimensions TWCVideoConstraintsSize1280x720;
		[Field("TWCVideoConstraintsSize1280x720", "__Internal")]
		//mc++ CMVideoDimensions TWCVideoConstraintsSize1280x720 { get; }
		IntPtr TWCVideoConstraintsSize1280x720 { get; }

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
	[BaseType(typeof(NSObject))]
	interface TWCCameraCapturerDelegate
	{
		// @optional -(void)cameraCapturerPreviewDidStart:(TWCCameraCapturer * _Nonnull)capturer;
		[Export("cameraCapturerPreviewDidStart:")]
		void CameraCapturerPreviewDidStart(TWCCameraCapturer capturer);

		// @optional -(void)cameraCapturer:(TWCCameraCapturer * _Nonnull)capturer didStartWithSource:(TWCVideoCaptureSource)source;
		[Export("cameraCapturer:didStartWithSource:")]
		void CameraCapturer(TWCCameraCapturer capturer, TWCVideoCaptureSource source);

		// @optional -(void)cameraCapturerWasInterrupted:(TWCCameraCapturer * _Nonnull)capturer;
		[Export("cameraCapturerWasInterrupted:")]
		void CameraCapturerWasInterrupted(TWCCameraCapturer capturer);

		// @optional -(void)cameraCapturer:(TWCCameraCapturer * _Nonnull)capturer didStopRunningWithError:(NSError * _Nonnull)error;
		[Export("cameraCapturer:didStopRunningWithError:")]
		void CameraCapturer(TWCCameraCapturer capturer, NSError error);
	}

	// @interface TWCCameraCapturer : NSObject <TWCVideoCapturer>
	[BaseType(typeof(NSObject))]
	interface TWCCameraCapturer : TWCVideoCapturer
	{
		// @property (assign, nonatomic) TWCVideoCaptureSource camera;
		[Export("camera", ArgumentSemantic.Assign)]
		TWCVideoCaptureSource Camera { get; set; }

		// @property (readonly, getter = isCapturing, assign, atomic) BOOL capturing;
		[Export("capturing")]
		bool Capturing { [Bind("isCapturing")] get; }

		[Wrap("WeakDelegate")]
		[NullAllowed]
		TWCCameraCapturerDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<TWCCameraCapturerDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, assign, nonatomic) CMVideoDimensions previewDimensions;
		[Export("previewDimensions", ArgumentSemantic.Assign)]
		//mc++ CMVideoDimensions PreviewDimensions { get; }
		IntPtr PreviewDimensions { get; }

		// @property (readonly, nonatomic, strong) TWCCameraPreviewView * _Nullable previewView;
		[NullAllowed, Export("previewView", ArgumentSemantic.Strong)]
		TWCCameraPreviewView PreviewView { get; }

		// @property (nonatomic, weak) TWCLocalVideoTrack * _Nullable videoTrack;
		[NullAllowed, Export("videoTrack", ArgumentSemantic.Weak)]
		TWCLocalVideoTrack VideoTrack { get; set; }

		// @property (readonly, getter = isInterrupted, assign, nonatomic) BOOL interrupted;
		[Export("interrupted")]
		bool Interrupted { [Bind("isInterrupted")] get; }

		// -(instancetype _Nonnull)initWithSource:(TWCVideoCaptureSource)source;
		[Export("initWithSource:")]
		IntPtr Constructor(TWCVideoCaptureSource source);

		// -(instancetype _Nonnull)initWithDelegate:(id<TWCCameraCapturerDelegate> _Nullable)delegate source:(TWCVideoCaptureSource)source;
		[Export("initWithDelegate:source:")]
		IntPtr Constructor([NullAllowed] TWCCameraCapturerDelegate @delegate, TWCVideoCaptureSource source);

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
	[BaseType(typeof(UIView))]
	interface TWCCameraPreviewView
	{
		// @property (readonly, assign, nonatomic) UIInterfaceOrientation orientation;
		[Export("orientation", ArgumentSemantic.Assign)]
		UIInterfaceOrientation Orientation { get; }
	}

	// @interface TWCClientOptions : NSObject
	[BaseType(typeof(NSObject))]
	interface TWCClientOptions
	{
		// @property (readonly, nonatomic, strong) TWCIceOptions * _Nonnull iceOptions;
		[Export("iceOptions", ArgumentSemantic.Strong)]
		TWCIceOptions IceOptions { get; }

		// @property (readonly, assign, nonatomic) BOOL preferH264;
		[Export("preferH264")]
		bool PreferH264 { get; }

		// -(instancetype _Null_unspecified)initWithIceOptions:(TWCIceOptions * _Nonnull)options;
		[Export("initWithIceOptions:")]
		IntPtr Constructor(TWCIceOptions options);

		// -(instancetype _Null_unspecified)initWithIceOptions:(TWCIceOptions * _Nonnull)options preferH264:(BOOL)preferH264;
		[Export("initWithIceOptions:preferH264:")]
		IntPtr Constructor(TWCIceOptions options, bool preferH264);
	}

	// typedef void (^TWCInviteAcceptanceBlock)(TWCConversation * _Nullable, NSError * _Nullable);
	delegate void TWCInviteAcceptanceBlock([NullAllowed] TWCConversation arg0, [NullAllowed] NSError arg1);

	// @interface TWCOutgoingInvite : NSObject
	[BaseType(typeof(NSObject))]
	interface TWCOutgoingInvite
	{
		// @property (readonly, assign, nonatomic) TWCInviteStatus status;
		[Export("status", ArgumentSemantic.Assign)]
		TWCInviteStatus Status { get; }

		// @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nonnull to;
		[Export("to", ArgumentSemantic.Copy)]
		string[] To { get; }

		// -(void)cancel;
		[Export("cancel")]
		void Cancel();
	}

	// @interface TWCMedia : NSObject
	[BaseType(typeof(NSObject))]
	interface TWCMedia
	{
		// @property (readonly, nonatomic, strong) NSArray<TWCAudioTrack *> * _Nonnull audioTracks;
		[Export("audioTracks", ArgumentSemantic.Strong)]
		TWCAudioTrack[] AudioTracks { get; }

		// @property (readonly, nonatomic, strong) NSArray<TWCVideoTrack *> * _Nonnull videoTracks;
		[Export("videoTracks", ArgumentSemantic.Strong)]
		TWCVideoTrack[] VideoTracks { get; }

		// -(TWCMediaTrack * _Nullable)getTrack:(NSString * _Nonnull)trackId;
		[Export("getTrack:")]
		[return: NullAllowed]
		TWCMediaTrack GetTrack(string trackId);
	}

	// @protocol TWCLocalMediaDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface TWCLocalMediaDelegate
	{
		// @optional -(void)localMedia:(TWCLocalMedia * _Nonnull)media didAddVideoTrack:(TWCVideoTrack * _Nonnull)videoTrack;
		[Export("localMedia:didAddVideoTrack:")]
		void DidAddVideoTrack(TWCLocalMedia media, TWCVideoTrack videoTrack);

		// @optional -(void)localMedia:(TWCLocalMedia * _Nonnull)media didFailToAddVideoTrack:(TWCVideoTrack * _Nonnull)videoTrack error:(NSError * _Nonnull)error;
		[Export("localMedia:didFailToAddVideoTrack:error:")]
		void DidFailToAddVideoTrack(TWCLocalMedia media, TWCVideoTrack videoTrack, NSError error);

		// @optional -(void)localMedia:(TWCLocalMedia * _Nonnull)media didRemoveVideoTrack:(TWCVideoTrack * _Nonnull)videoTrack;
		[Export("localMedia:didRemoveVideoTrack:")]
		void DidRemoveVideoTrack(TWCLocalMedia media, TWCVideoTrack videoTrack);
	}

	// @interface TWCLocalMedia : TWCMedia
	[BaseType(typeof(TWCMedia))]
	interface TWCLocalMedia
	{
		// @property (getter = isMicrophoneMuted, assign, nonatomic) BOOL microphoneMuted;
		[Export("microphoneMuted")]
		bool MicrophoneMuted { [Bind("isMicrophoneMuted")] get; set; }

		// @property (readonly, getter = isMicrophoneAdded, assign, nonatomic) BOOL microphoneAdded;
		[Export("microphoneAdded")]
		bool MicrophoneAdded { [Bind("isMicrophoneAdded")] get; }

		[Wrap("WeakDelegate")]
		[NullAllowed]
		TWCLocalMediaDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<TWCLocalMediaDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// -(instancetype _Nullable)initWithDelegate:(id<TWCLocalMediaDelegate> _Nullable)delegate;
		[Export("initWithDelegate:")]
		IntPtr Constructor([NullAllowed] TWCLocalMediaDelegate @delegate);

		// -(BOOL)addTrack:(TWCVideoTrack * _Nonnull)track;
		[Export("addTrack:")]
		bool AddTrack(TWCVideoTrack track);

		// -(BOOL)addTrack:(TWCVideoTrack * _Nonnull)track error:(NSError * _Nullable * _Nullable)error;
		[Export("addTrack:error:")]
		bool AddTrack(TWCVideoTrack track, [NullAllowed] out NSError error);

		// -(BOOL)removeTrack:(TWCVideoTrack * _Nonnull)track;
		[Export("removeTrack:")]
		bool RemoveTrack(TWCVideoTrack track);

		// -(BOOL)removeTrack:(TWCVideoTrack * _Nonnull)track error:(NSError * _Nullable * _Nullable)error;
		[Export("removeTrack:error:")]
		bool RemoveTrack(TWCVideoTrack track, [NullAllowed] out NSError error);

		// -(TWCCameraCapturer * _Nullable)addCameraTrack;
		[NullAllowed, Export("addCameraTrack")]
		//mc++ [Verify(MethodToProperty)]
		TWCCameraCapturer AddCameraTrack(); //mc++ { get; }

		// -(TWCCameraCapturer * _Nullable)addCameraTrack:(NSError * _Nullable * _Nullable)error;
		[Export("addCameraTrack:")]
		[return: NullAllowed]
		TWCCameraCapturer AddCameraTrack([NullAllowed] out NSError error);

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
	[BaseType(typeof(NSObject))]
	interface TWCParticipantDelegate
	{
		// @optional -(void)participant:(TWCParticipant * _Nonnull)participant addedVideoTrack:(TWCVideoTrack * _Nonnull)videoTrack;
		[Export("participant:addedVideoTrack:")]
		void AddedVideoTrack(TWCParticipant participant, TWCVideoTrack videoTrack);

		// @optional -(void)participant:(TWCParticipant * _Nonnull)participant removedVideoTrack:(TWCVideoTrack * _Nonnull)videoTrack;
		[Export("participant:removedVideoTrack:")]
		void RemovedVideoTrack(TWCParticipant participant, TWCVideoTrack videoTrack);

		// @optional -(void)participant:(TWCParticipant * _Nonnull)participant addedAudioTrack:(TWCAudioTrack * _Nonnull)audioTrack;
		[Export("participant:addedAudioTrack:")]
		void AddedAudioTrack(TWCParticipant participant, TWCAudioTrack audioTrack);

		// @optional -(void)participant:(TWCParticipant * _Nonnull)participant removedAudioTrack:(TWCAudioTrack * _Nonnull)audioTrack;
		[Export("participant:removedAudioTrack:")]
		void RemovedAudioTrack(TWCParticipant participant, TWCAudioTrack audioTrack);

		// @optional -(void)participant:(TWCParticipant * _Nonnull)participant disabledTrack:(TWCMediaTrack * _Nonnull)track;
		[Export("participant:disabledTrack:")]
		void DisabledTrack(TWCParticipant participant, TWCMediaTrack track);

		// @optional -(void)participant:(TWCParticipant * _Nonnull)participant enabledTrack:(TWCMediaTrack * _Nonnull)track;
		[Export("participant:enabledTrack:")]
		void EnabledTrack(TWCParticipant participant, TWCMediaTrack track);
	}

	// @interface TWCParticipant : NSObject
	[BaseType(typeof(NSObject))]
	interface TWCParticipant
	{
		// @property (readonly, nonatomic, strong) NSString * _Nonnull identity;
		[Export("identity", ArgumentSemantic.Strong)]
		string Identity { get; }

		// @property (readonly, nonatomic, weak) TWCConversation * _Null_unspecified conversation;
		[Export("conversation", ArgumentSemantic.Weak)]
		TWCConversation Conversation { get; }

		[Wrap("WeakDelegate")]
		[NullAllowed]
		TWCParticipantDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<TWCParticipantDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) TWCMedia * _Nonnull media;
		[Export("media", ArgumentSemantic.Strong)]
		TWCMedia Media { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nullable sid;
		[NullAllowed, Export("sid", ArgumentSemantic.Strong)]
		string Sid { get; }
	}

	// @interface TWCConversation : NSObject
	[BaseType(typeof(NSObject))]
	interface TWCConversation
	{
		// @property (readonly, nonatomic, strong) NSArray<TWCParticipant *> * _Nonnull participants;
		[Export("participants", ArgumentSemantic.Strong)]
		TWCParticipant[] Participants { get; }

		// @property (readonly, nonatomic, strong) TWCLocalMedia * _Nullable localMedia;
		[NullAllowed, Export("localMedia", ArgumentSemantic.Strong)]
		TWCLocalMedia LocalMedia { get; }

		[Wrap("WeakDelegate")]
		[NullAllowed]
		TWCConversationDelegate Delegate { get; set; }

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
		TWCParticipant GetParticipant(string participantSID);
	}

	// @protocol TWCConversationDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface TWCConversationDelegate
	{
		// @optional -(void)conversation:(TWCConversation * _Nonnull)conversation didConnectParticipant:(TWCParticipant * _Nonnull)participant;
		[Export("conversation:didConnectParticipant:")]
		void ConversationDidConnectParticipant(TWCConversation conversation, TWCParticipant participant);

		// @optional -(void)conversation:(TWCConversation * _Nonnull)conversation didFailToConnectParticipant:(TWCParticipant * _Nonnull)participant error:(NSError * _Nonnull)error;
		[Export("conversation:didFailToConnectParticipant:error:")]
		void Conversation(TWCConversation conversation, TWCParticipant participant, NSError error);

		// @optional -(void)conversation:(TWCConversation * _Nonnull)conversation didDisconnectParticipant:(TWCParticipant * _Nonnull)participant;
		[Export("conversation:didDisconnectParticipant:")]
		void ConversationDidDisconnectParticipant(TWCConversation conversation, TWCParticipant participant);

		// @optional -(void)conversationEnded:(TWCConversation * _Nonnull)conversation;
		[Export("conversationEnded:")]
		void ConversationEnded(TWCConversation conversation);

		// @optional -(void)conversationEnded:(TWCConversation * _Nonnull)conversation error:(NSError * _Nonnull)error;
		[Export("conversationEnded:error:")]
		void ConversationEnded(TWCConversation conversation, NSError error);
	}

	// @protocol TWCMediaTrackStatisticsDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface TWCMediaTrackStatisticsDelegate
	{
		// @required -(void)conversation:(TWCConversation * _Nonnull)conversation didReceiveTrackStatistics:(TWCMediaTrackStatsRecord * _Nonnull)trackStatistics;
		[Abstract]
		[Export("conversation:didReceiveTrackStatistics:")]
		void DidReceiveTrackStatistics(TWCConversation conversation, TWCMediaTrackStatsRecord trackStatistics);
	}

	// @interface TWCIncomingInvite : NSObject
	[BaseType(typeof(NSObject))]
	interface TWCIncomingInvite
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
		TWCInviteStatus Status { get; }

		// -(void)acceptWithCompletion:(TWCInviteAcceptanceBlock _Nonnull)acceptHandler;
		[Export("acceptWithCompletion:")]
		void AcceptWithCompletion(TWCInviteAcceptanceBlock acceptHandler);

		// -(void)acceptWithLocalMedia:(TWCLocalMedia * _Nonnull)localMedia completion:(TWCInviteAcceptanceBlock _Nonnull)acceptHandler;
		[Export("acceptWithLocalMedia:completion:")]
		void AcceptWithLocalMedia(TWCLocalMedia localMedia, TWCInviteAcceptanceBlock acceptHandler);

		// -(void)acceptWithLocalMedia:(TWCLocalMedia * _Nonnull)localMedia iceOptions:(TWCIceOptions * _Nonnull)iceOptions completion:(TWCInviteAcceptanceBlock _Nonnull)acceptHandler;
		[Export("acceptWithLocalMedia:iceOptions:completion:")]
		void AcceptWithLocalMedia(TWCLocalMedia localMedia, TWCIceOptions iceOptions, TWCInviteAcceptanceBlock acceptHandler);

		// -(void)reject;
		[Export("reject")]
		void Reject();
	}

	// @interface TWCIceServer : NSObject
	[BaseType(typeof(NSObject))]
	interface TWCIceServer
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
	[BaseType(typeof(NSObject))]
	interface TWCIceOptions
	{
		// @property (readonly, copy, nonatomic) NSArray<TWCIceServer *> * _Nonnull iceServers;
		[Export("iceServers", ArgumentSemantic.Copy)]
		TWCIceServer[] IceServers { get; }

		// @property (readonly, assign, nonatomic) TWCIceTransportPolicy iceTransportPolicy;
		[Export("iceTransportPolicy", ArgumentSemantic.Assign)]
		TWCIceTransportPolicy IceTransportPolicy { get; }

		// -(instancetype _Null_unspecified)initWithTransportPolicy:(TWCIceTransportPolicy)transportPolicy;
		[Export("initWithTransportPolicy:")]
		IntPtr Constructor(TWCIceTransportPolicy transportPolicy);

		// -(instancetype _Null_unspecified)initWithTransportPolicy:(TWCIceTransportPolicy)transportPolicy servers:(NSArray<TWCIceServer *> * _Nonnull)servers;
		[Export("initWithTransportPolicy:servers:")]
		IntPtr Constructor(TWCIceTransportPolicy transportPolicy, TWCIceServer[] servers);
	}

	// @interface TWCI420Frame : NSObject
	[BaseType(typeof(NSObject))]
	interface TWCI420Frame
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
		TWCVideoOrientation Orientation { get; }

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
	[BaseType(typeof(NSObject))]
	interface TWCVideoConstraintsBuilder
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
	delegate void TWCVideoConstraintsBuilderBlock(TWCVideoConstraintsBuilder arg0);

	// @interface TWCVideoConstraints : NSObject
	[BaseType(typeof(NSObject))]
	interface TWCVideoConstraints
	{
		// +(instancetype _Null_unspecified)constraints;
		[Static]
		[Export("constraints")]
		TWCVideoConstraints Constraints();

		// +(instancetype _Null_unspecified)constraintsWithBlock:(TWCVideoConstraintsBuilderBlock _Nonnull)builderBlock;
		[Static]
		[Export("constraintsWithBlock:")]
		TWCVideoConstraints ConstraintsWithBlock(TWCVideoConstraintsBuilderBlock builderBlock);

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
	[BaseType(typeof(NSObject))]
	interface TWCVideoRenderer
	{
		// @required -(void)renderFrame:(TWCI420Frame * _Nonnull)frame;
		[Abstract]
		[Export("renderFrame:")]
		void RenderFrame(TWCI420Frame frame);

		// @required -(void)updateVideoSize:(CMVideoDimensions)videoSize orientation:(TWCVideoOrientation)orientation;
		[Abstract]
		[Export("updateVideoSize:orientation:")]
		void UpdateVideoSize(CMVideoDimensions videoSize, TWCVideoOrientation orientation);

		// @optional -(BOOL)supportsVideoFrameOrientation;
		[Export("supportsVideoFrameOrientation")]
		//mc++ [Verify(MethodToProperty)]
		bool SupportsVideoFrameOrientation { get; }
	}

	// @protocol TWCVideoTrackDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface TWCVideoTrackDelegate
	{
		// @optional -(void)videoTrack:(TWCVideoTrack * _Nonnull)track dimensionsDidChange:(CMVideoDimensions)dimensions;
		[Export("videoTrack:dimensionsDidChange:")]
		void DimensionsDidChange(TWCVideoTrack track, CMVideoDimensions dimensions);
	}

	// @interface TWCVideoTrack : TWCMediaTrack
	[BaseType(typeof(TWCMediaTrack))]
	interface TWCVideoTrack
	{
		[Wrap("WeakDelegate")]
		[NullAllowed]
		TWCVideoTrackDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<TWCVideoTrackDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) NSArray<UIView *> * _Nonnull attachedViews;
		[Export("attachedViews", ArgumentSemantic.Strong)]
		UIView[] AttachedViews { get; }

		// @property (readonly, nonatomic, strong) NSArray<id<TWCVideoRenderer>> * _Nonnull renderers;
		[Export("renderers", ArgumentSemantic.Strong)]
		TWCVideoRenderer[] Renderers { get; }

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
		void AddRenderer(TWCVideoRenderer renderer);

		// -(void)removeRenderer:(id<TWCVideoRenderer> _Nonnull)renderer;
		[Export("removeRenderer:")]
		void RemoveRenderer(TWCVideoRenderer renderer);
	}

	// @interface TWCLocalVideoTrack : TWCVideoTrack
	[BaseType(typeof(TWCVideoTrack))]
	interface TWCLocalVideoTrack
	{
		// -(instancetype _Nonnull)initWithCapturer:(id<TWCVideoCapturer> _Nonnull)capturer;
		[Export("initWithCapturer:")]
		IntPtr Constructor(TWCVideoCapturer capturer);

		// -(instancetype _Nonnull)initWithCapturer:(id<TWCVideoCapturer> _Nonnull)capturer constraints:(TWCVideoConstraints * _Nonnull)constraints;
		[Export("initWithCapturer:constraints:")]
		IntPtr Constructor(TWCVideoCapturer capturer, TWCVideoConstraints constraints);

		// @property (getter = isEnabled, assign, nonatomic) BOOL enabled;
		[Export("enabled")]
		bool Enabled { [Bind("isEnabled")] get; set; }

		// @property (readonly, nonatomic, strong) id<TWCVideoCapturer> _Nonnull capturer;
		[Export("capturer", ArgumentSemantic.Strong)]
		TWCVideoCapturer Capturer { get; }

		// @property (readonly, nonatomic, strong) TWCVideoConstraints * _Nonnull constraints;
		[Export("constraints", ArgumentSemantic.Strong)]
		TWCVideoConstraints Constraints { get; }
	}

	// @protocol TWCVideoViewRendererDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface TWCVideoViewRendererDelegate
	{
		// @optional -(void)rendererDidReceiveVideoData:(TWCVideoViewRenderer * _Nonnull)renderer;
		[Export("rendererDidReceiveVideoData:")]
		void RendererDidReceiveVideoData(TWCVideoViewRenderer renderer);

		// @optional -(void)renderer:(TWCVideoViewRenderer * _Nonnull)renderer dimensionsDidChange:(CMVideoDimensions)dimensions;
		[Export("renderer:dimensionsDidChange:")]
		void Renderer(TWCVideoViewRenderer renderer, CMVideoDimensions dimensions);

		// @optional -(void)renderer:(TWCVideoViewRenderer * _Nonnull)renderer orientationDidChange:(TWCVideoOrientation)orientation;
		[Export("renderer:orientationDidChange:")]
		void Renderer(TWCVideoViewRenderer renderer, TWCVideoOrientation orientation);

		// @optional -(BOOL)rendererShouldRotateContent:(TWCVideoViewRenderer * _Nonnull)renderer;
		[Export("rendererShouldRotateContent:")]
		bool RendererShouldRotateContent(TWCVideoViewRenderer renderer);
	}

	// @interface TWCVideoViewRenderer : NSObject <TWCVideoRenderer>
	[BaseType(typeof(NSObject))]
	interface TWCVideoViewRenderer : TWCVideoRenderer
	{
		// -(instancetype _Nonnull)initWithDelegate:(id<TWCVideoViewRendererDelegate> _Nullable)delegate;
		[Export("initWithDelegate:")]
		IntPtr Constructor([NullAllowed] TWCVideoViewRendererDelegate @delegate);

		// +(TWCVideoViewRenderer * _Nonnull)rendererWithDelegate:(id<TWCVideoViewRendererDelegate> _Nullable)delegate;
		[Static]
		[Export("rendererWithDelegate:")]
		TWCVideoViewRenderer RendererWithDelegate([NullAllowed] TWCVideoViewRendererDelegate @delegate);

		// +(TWCVideoViewRenderer * _Nonnull)rendererWithRenderingType:(TWCVideoRenderingType)renderingType delegate:(id<TWCVideoViewRendererDelegate> _Nullable)delegate;
		[Static]
		[Export("rendererWithRenderingType:delegate:")]
		TWCVideoViewRenderer RendererWithRenderingType(TWCVideoRenderingType renderingType, [NullAllowed] TWCVideoViewRendererDelegate @delegate);

		[Wrap("WeakDelegate")]
		[NullAllowed]
		TWCVideoViewRendererDelegate Delegate { get; }

		// @property (readonly, nonatomic, weak) id<TWCVideoViewRendererDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; }

		// @property (readonly, assign, nonatomic) CMVideoDimensions videoFrameDimensions;
		[Export("videoFrameDimensions", ArgumentSemantic.Assign)]
		//mc++ CMVideoDimensions VideoFrameDimensions { get; }
		IntPtr VideoFrameDimensions { get; }

		// @property (readonly, assign, nonatomic) TWCVideoOrientation videoFrameOrientation;
		[Export("videoFrameOrientation", ArgumentSemantic.Assign)]
		TWCVideoOrientation VideoFrameOrientation { get; }

		// @property (readonly, assign, atomic) BOOL hasVideoData;
		[Export("hasVideoData")]
		bool HasVideoData { get; }

		// @property (readonly, nonatomic, strong) UIView * _Nonnull view;
		[Export("view", ArgumentSemantic.Strong)]
		UIView View { get; }
	}

	// @interface TWCMediaTrackStatsRecord : NSObject
	[BaseType(typeof(NSObject))]
	interface TWCMediaTrackStatsRecord
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
	[BaseType(typeof(TWCMediaTrackStatsRecord))]
	interface TWCLocalVideoMediaStatsRecord
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
		IntPtr CaptureDimensions { get; }

		// @property (readonly, assign, nonatomic) CMVideoDimensions sentDimensions;
		[Export("sentDimensions", ArgumentSemantic.Assign)]
		//mc++ CMVideoDimensions SentDimensions { get; }
		IntPtr SentDimensions { get; }

		// @property (readonly, nonatomic) NSUInteger frameRate;
		[Export("frameRate")]
		nuint FrameRate { get; }

		// @property (readonly, nonatomic) NSUInteger roundTripTime;
		[Export("roundTripTime")]
		nuint RoundTripTime { get; }
	}

	// @interface TWCLocalAudioMediaStatsRecord : TWCMediaTrackStatsRecord
	[BaseType(typeof(TWCMediaTrackStatsRecord))]
	interface TWCLocalAudioMediaStatsRecord
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
	[BaseType(typeof(TWCMediaTrackStatsRecord))]
	interface TWCRemoteVideoMediaStatsRecord
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
	[BaseType(typeof(TWCMediaTrackStatsRecord))]
	interface TWCRemoteAudioMediaStatsRecord
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
	[BaseType(typeof(NSObject))]
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
		TwilioConversationsClient ConversationsClientWithAccessManager(TwilioAccessManager accessManager, [NullAllowed] TWCClientOptions options, [NullAllowed] DispatchQueue queue, [NullAllowed] TwilioConversationsClientDelegate @delegate);

		// -(void)listen;
		[Export("listen")]
		void Listen();

		// -(void)unlisten;
		[Export("unlisten")]
		void Unlisten();

		// -(TWCOutgoingInvite * _Nullable)inviteToConversation:(NSString * _Nonnull)client handler:(TWCInviteAcceptanceBlock _Nonnull)handler;
		[Export("inviteToConversation:handler:")]
		[return: NullAllowed]
		TWCOutgoingInvite InviteToConversation(string client, TWCInviteAcceptanceBlock handler);

		// -(TWCOutgoingInvite * _Nullable)inviteToConversation:(NSString * _Nonnull)client localMedia:(TWCLocalMedia * _Nonnull)localMedia handler:(TWCInviteAcceptanceBlock _Nonnull)handler;
		[Export("inviteToConversation:localMedia:handler:")]
		[return: NullAllowed]
		TWCOutgoingInvite InviteToConversation(string client, TWCLocalMedia localMedia, TWCInviteAcceptanceBlock handler);

		// -(TWCOutgoingInvite * _Nullable)inviteManyToConversation:(NSArray<NSString *> * _Nonnull)clients localMedia:(TWCLocalMedia * _Nonnull)localMedia handler:(TWCInviteAcceptanceBlock _Nonnull)handler;
		[Export("inviteManyToConversation:localMedia:handler:")]
		[return: NullAllowed]
		TWCOutgoingInvite InviteManyToConversation(string[] clients, TWCLocalMedia localMedia, TWCInviteAcceptanceBlock handler);

		// -(TWCOutgoingInvite * _Nullable)inviteManyToConversation:(NSArray<NSString *> * _Nonnull)clients localMedia:(TWCLocalMedia * _Nonnull)localMedia iceOptions:(TWCIceOptions * _Nonnull)iceOptions handler:(TWCInviteAcceptanceBlock _Nonnull)handler;
		[Export("inviteManyToConversation:localMedia:iceOptions:handler:")]
		[return: NullAllowed]
		TWCOutgoingInvite InviteManyToConversation(string[] clients, TWCLocalMedia localMedia, TWCIceOptions iceOptions, TWCInviteAcceptanceBlock handler);

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
		TWCLogLevel LogLevel { get; set; }

		// +(void)setLogLevel:(TWCLogLevel)logLevel module:(TWCLogModule)module;
		[Static]
		[Export("setLogLevel:module:")]
		void SetLogLevel(TWCLogLevel logLevel, TWCLogModule module);

		// +(void)setAudioOutput:(TWCAudioOutput)audioOutput;
		[Static]
		[Export("setAudioOutput:")]
		void SetAudioOutput(TWCAudioOutput audioOutput);

		// +(TWCAudioOutput)audioOutput;
		[Static]
		[Export("audioOutput")]
		TWCAudioOutput AudioOutput();
	}

	// @protocol TwilioConversationsClientDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
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
		void ConversationsClientInviteReceived(TwilioConversationsClient conversationsClient, TWCIncomingInvite invite);

		// @optional -(void)conversationsClient:(TwilioConversationsClient * _Nonnull)conversationsClient inviteDidCancel:(TWCIncomingInvite * _Nonnull)invite;
		[Export("conversationsClient:inviteDidCancel:")]
		void ConversationsClientInviteCancelled(TwilioConversationsClient conversationsClient, TWCIncomingInvite invite);
	}
}
