using System;
using CoreFoundation;
using CoreMedia;
using Foundation;
using ObjCRuntime;
using Twilio.Video;
using UIKit;

namespace Twilio.Video
{
	// @interface TVII420Frame : NSObject
	[BaseType (typeof(NSObject), Name = "TVII420Frame")]
	interface /*mc++TVI*/I420Frame
	{
		// @property (readonly, nonatomic) NSUInteger width;
		[Export ("width")]
		nuint Width { get; }

		// @property (readonly, nonatomic) NSUInteger height;
		[Export ("height")]
		nuint Height { get; }

		// @property (readonly, nonatomic) NSUInteger chromaWidth;
		[Export ("chromaWidth")]
		nuint ChromaWidth { get; }

		// @property (readonly, nonatomic) NSUInteger chromaHeight;
		[Export ("chromaHeight")]
		nuint ChromaHeight { get; }

		// @property (readonly, nonatomic) NSUInteger chromaSize;
		[Export ("chromaSize")]
		nuint ChromaSize { get; }

		// @property (readonly, nonatomic) TVIVideoOrientation orientation;
		[Export ("orientation")]
		/*mc++TVI*/VideoOrientation Orientation { get; }

		// @property (readonly, nonatomic) const uint8_t * yPlane;
		[Export ("yPlane")]
		unsafe /*mc++ byte* */ IntPtr YPlane { get; }

		// @property (readonly, nonatomic) const uint8_t * uPlane;
		[Export ("uPlane")]
		unsafe /*mc++ byte* */ IntPtr  UPlane { get; }

		// @property (readonly, nonatomic) const uint8_t * vPlane;
		[Export ("vPlane")]
		unsafe /*mc++ byte* */ IntPtr  VPlane { get; }

		// @property (readonly, nonatomic) NSInteger yPitch;
		[Export ("yPitch")]
		nint YPitch { get; }

		// @property (readonly, nonatomic) NSInteger uPitch;
		[Export ("uPitch")]
		nint UPitch { get; }

		// @property (readonly, nonatomic) NSInteger vPitch;
		[Export ("vPitch")]
		nint VPitch { get; }
	}

	// @interface TVIAudioConstraintsBuilder : NSObject
	[BaseType (typeof(NSObject), Name = "TVIAudioConstraintsBuilder")]
	interface /*mc++TVI*/AudioConstraintsBuilder
	{
		// @property (assign, nonatomic) BOOL autoGainControl;
		[Export ("autoGainControl")]
		bool AutoGainControl { get; set; }

		// @property (assign, nonatomic) BOOL noiseReduction;
		[Export ("noiseReduction")]
		bool NoiseReduction { get; set; }
	}

	// typedef void (^TVIAudioConstraintsBuilderBlock)(TVIAudioConstraintsBuilder * _Nonnull);
	delegate void /*mc++TVI*/AudioConstraintsBuilderBlock (/*mc++TVI*/AudioConstraintsBuilder arg0);

	// @interface TVIAudioConstraints : NSObject
	[BaseType (typeof(NSObject), Name = "TVIAudioConstraints")]
	interface /*mc++TVI*/AudioConstraints
	{
		// @property (readonly, assign, nonatomic) BOOL autoGainControl;
		[Export ("autoGainControl")]
		bool AutoGainControl { get; }

		// @property (readonly, assign, nonatomic) BOOL noiseReduction;
		[Export ("noiseReduction")]
		bool NoiseReduction { get; }

		// +(instancetype _Null_unspecified)constraints;
		[Static]
		[Export ("constraints")]
		/*mc++TVI*/AudioConstraints Constraints ();

		// +(instancetype _Null_unspecified)constraintsWithBlock:(TVIAudioConstraintsBuilderBlock _Nonnull)block;
		[Static]
		[Export ("constraintsWithBlock:")]
		/*mc++TVI*/AudioConstraints ConstraintsWithBlock (/*mc++TVI*/AudioConstraintsBuilderBlock block);
	}

	// @interface TVIAudioController : NSObject
	[BaseType (typeof(NSObject), Name = "TVIAudioController")]
	[DisableDefaultCtor]
	interface /*mc++TVI*/AudioController
	{
		// @property (assign, nonatomic) TVIAudioOutput audioOutput;
		[Export ("audioOutput", ArgumentSemantic.Assign)]
		/*mc++TVI*/AudioOutput AudioOutput { get; set; }
	}

	// @interface CallKit (TVIAudioController)
	[Category]
	[BaseType (typeof(/*mc++TVI*/AudioController), Name="TVIAudioController_CallKit")]
	interface /*mc++TVI*/AudioController_CallKit
	{
		// -(void)configureAudioSession:(TVIAudioOutput)audioOutput;
		[Export ("configureAudioSession:")]
		void ConfigureAudioSession (/*mc++TVI*/AudioOutput audioOutput);

		// -(BOOL)startAudio;
		[Export("startAudio")]
		//mc++ [Verify (MethodToProperty)]
		bool StartAudio();//mc++ { get; }

		// -(void)stopAudio;
		[Export ("stopAudio")]
		void StopAudio ();
	}

	// @interface TVITrack : NSObject
	[BaseType (typeof(NSObject), Name = "TVITrack")]
	[DisableDefaultCtor]
	interface /*mc++TVI*/Track
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull trackId;
		[Export ("trackId")]
		string TrackId { get; }

		// @property (readonly, getter = isEnabled, assign, nonatomic) BOOL enabled;
		[Export ("enabled")]
		bool Enabled { [Bind ("isEnabled")] get; }

		// @property (readonly, assign, nonatomic) TVITrackState state;
		[Export ("state", ArgumentSemantic.Assign)]
		/*mc++TVI*/TrackState State { get; }
	}

	// @interface TVIAudioTrack : TVITrack
	[BaseType (typeof(/*mc++TVI*/Track), Name = "TVIAudioTrack")]
	[DisableDefaultCtor]
	interface /*mc++TVI*/AudioTrack
	{
	}

	// @interface TVILocalAudioTrack : TVIAudioTrack
	[BaseType (typeof(/*mc++TVI*/AudioTrack), Name = "TVILocalAudioTrack")]
	[DisableDefaultCtor]
	interface /*mc++TVI*/LocalAudioTrack
	{
		// @property (readonly, nonatomic, strong) TVIAudioConstraints * _Nonnull constraints;
		[Export ("constraints", ArgumentSemantic.Strong)]
		/*mc++TVI*/AudioConstraints Constraints { get; }

		// @property (getter = isEnabled, assign, nonatomic) BOOL enabled;
		[Export ("enabled")]
		bool Enabled { [Bind ("isEnabled")] get; set; }
	}

	// @interface TVIVideoFormat : NSObject
	[BaseType (typeof(NSObject), Name = "TVIVideoFormat")]
	interface /*mc++TVI*/VideoFormat
	{
		// @property (assign, nonatomic) CMVideoDimensions dimensions;
		[Export ("dimensions", ArgumentSemantic.Assign)]
		CMVideoDimensions Dimensions { get; set; }

		// @property (assign, nonatomic) NSUInteger frameRate;
		[Export ("frameRate")]
		nuint FrameRate { get; set; }

		// @property (assign, nonatomic) TVIPixelFormat pixelFormat;
		[Export ("pixelFormat", ArgumentSemantic.Assign)]
		/*mc++TVI*/PixelFormat PixelFormat { get; set; }
	}

	// @protocol TVIVideoCaptureConsumer <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject), Name = "TVIVideoCaptureConsumer")]
	interface /*mc++TVI*/VideoCaptureConsumer
	{
		// @required -(void)consumeCapturedFrame:(TVIVideoFrame)frame;
		[Abstract]
		[Export ("consumeCapturedFrame:")]
		void ConsumeCapturedFrame (/*mc++TVI*/VideoFrame frame);

		// @required -(void)captureDidStart:(BOOL)success;
		[Abstract]
		[Export ("captureDidStart:")]
		void CaptureDidStart (bool success);
	}

	// @protocol TVIVideoCapturer <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject), Name = "TVIVideoCapturer")]
	interface /*mc++TVI*/VideoCapturer
	{
		// @required @property (readonly, getter = isScreencast, assign, nonatomic) BOOL screencast;
		[Abstract]
		[Export ("screencast")]
		bool Screencast { [Bind ("isScreencast")] get; }

		// @required @property (readonly, copy, nonatomic) NSArray<TVIVideoFormat *> * _Nonnull supportedFormats;
		[Abstract]
		[Export ("supportedFormats", ArgumentSemantic.Copy)]
		/*mc++TVI*/VideoFormat[] SupportedFormats { get; }

		// @required -(void)startCapture:(TVIVideoFormat * _Nonnull)format consumer:(id<TVIVideoCaptureConsumer> _Nonnull)consumer;
		[Abstract]
		[Export ("startCapture:consumer:")]
		void StartCapture (/*mc++TVI*/VideoFormat format, /*mc++TVI*/VideoCaptureConsumer consumer);

		// @required -(void)stopCapture;
		[Abstract]
		[Export ("stopCapture")]
		void StopCapture ();
	}

	//mc++ [Static]
	//mc++ [Verify (ConstantsInterfaceAssociation)]
	partial interface VideoConstraintsConstants
	{
		// extern const CMVideoDimensions TVIVideoConstraintsSize352x288;
		[Field ("TVIVideoConstraintsSize352x288", "__Internal")]
		/*mc++ CMVideoDimensions*/ IntPtr /*mc++TVI*//*mc++VideoConstraints*/Size352x288 { get; }

		// extern const CMVideoDimensions TVIVideoConstraintsSize480x360;
		[Field ("TVIVideoConstraintsSize480x360", "__Internal")]
		/*mc++ CMVideoDimensions*/ IntPtr /*mc++TVI*//*mc++VideoConstraints*/Size480x360 { get; }

		// extern const CMVideoDimensions TVIVideoConstraintsSize640x480;
		[Field ("TVIVideoConstraintsSize640x480", "__Internal")]
		/*mc++ CMVideoDimensions*/ IntPtr /*mc++TVI*//*mc++VideoConstraints*/Size640x480 { get; }

		// extern const CMVideoDimensions TVIVideoConstraintsSize960x540;
		[Field ("TVIVideoConstraintsSize960x540", "__Internal")]
		/*mc++ CMVideoDimensions*/ IntPtr /*mc++TVI*//*mc++VideoConstraints*/Size960x540 { get; }

		// extern const CMVideoDimensions TVIVideoConstraintsSize1280x720;
		[Field ("TVIVideoConstraintsSize1280x720", "__Internal")]
		/*mc++ CMVideoDimensions*/ IntPtr /*mc++TVI*//*mc++VideoConstraints*/Size1280x720 { get; }

		// extern const CMVideoDimensions TVIVideoConstraintsSize1280x960;
		[Field ("TVIVideoConstraintsSize1280x960", "__Internal")]
		/*mc++ CMVideoDimensions*/ IntPtr /*mc++TVI*//*mc++VideoConstraints*/Size1280x960 { get; }

		// extern const NSUInteger TVIVideoConstraintsFrameRate30;
		[Field ("TVIVideoConstraintsFrameRate30", "__Internal")]
		nuint /*mc++TVI*//*mc++VideoConstraints*/FrameRate30 { get; }

		// extern const NSUInteger TVIVideoConstraintsFrameRate24;
		[Field ("TVIVideoConstraintsFrameRate24", "__Internal")]
		nuint /*mc++TVI*//*mc++VideoConstraints*/FrameRate24 { get; }

		// extern const NSUInteger TVIVideoConstraintsFrameRate20;
		[Field ("TVIVideoConstraintsFrameRate20", "__Internal")]
		nuint /*mc++TVI*//*mc++VideoConstraints*/FrameRate20 { get; }

		// extern const NSUInteger TVIVideoConstraintsFrameRate15;
		[Field ("TVIVideoConstraintsFrameRate15", "__Internal")]
		nuint /*mc++TVI*//*mc++VideoConstraints*/FrameRate15 { get; }

		// extern const NSUInteger TVIVideoConstraintsFrameRate10;
		[Field ("TVIVideoConstraintsFrameRate10", "__Internal")]
		nuint /*mc++TVI*//*mc++VideoConstraints*/FrameRate10 { get; }
	}

	// @protocol TVICameraCapturerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject), Name = "TVICameraCapturerDelegate")]
	interface /*mc++TVI*/CameraCapturerDelegate
	{
		// @optional -(void)cameraCapturerPreviewDidStart:(TVICameraCapturer * _Nonnull)capturer;
		[Export ("cameraCapturerPreviewDidStart:")]
		void CameraCapturerPreviewDidStart (/*mc++TVI*/CameraCapturer capturer);

		// @optional -(void)cameraCapturer:(TVICameraCapturer * _Nonnull)capturer didStartWithSource:(TVIVideoCaptureSource)source;
		[Export ("cameraCapturer:didStartWithSource:")]
		void CameraCapturer (/*mc++TVI*/CameraCapturer capturer, /*mc++TVI*/VideoCaptureSource source);

		// @optional -(void)cameraCapturerWasInterrupted:(TVICameraCapturer * _Nonnull)capturer;
		[Export ("cameraCapturerWasInterrupted:")]
		void CameraCapturerWasInterrupted (/*mc++TVI*/CameraCapturer capturer);

		// @optional -(void)cameraCapturer:(TVICameraCapturer * _Nonnull)capturer didStopRunningWithError:(NSError * _Nonnull)error;
		[Export ("cameraCapturer:didStopRunningWithError:")]
		void CameraCapturer (/*mc++TVI*/CameraCapturer capturer, NSError error);
	}

	// @interface TVICameraCapturer : NSObject <TVIVideoCapturer>
	[BaseType (typeof(NSObject), Name="TVICameraCapturer")]
	interface /*mc++TVI*/CameraCapturer : /*mc++I*//*mc++TVI*/VideoCapturer
	{
		// @property (readonly, assign, nonatomic) TVIVideoCaptureSource source;
		[Export ("source", ArgumentSemantic.Assign)]
		/*mc++TVI*/VideoCaptureSource Source { get; }

		// @property (readonly, getter = isCapturing, assign, atomic) BOOL capturing;
		[Export ("capturing")]
		bool Capturing { [Bind ("isCapturing")] get; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		/*mc++TVI*/CameraCapturerDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<TVICameraCapturerDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, assign, nonatomic) CMVideoDimensions previewDimensions;
		[Export ("previewDimensions", ArgumentSemantic.Assign)]
		CMVideoDimensions PreviewDimensions { get; }

		// @property (readonly, nonatomic, strong) TVICameraPreviewView * _Nullable previewView;
		[NullAllowed, Export ("previewView", ArgumentSemantic.Strong)]
		/*mc++TVI*/CameraPreviewView PreviewView { get; }

		// @property (readonly, getter = isInterrupted, assign, nonatomic) BOOL interrupted;
		[Export ("interrupted")]
		bool Interrupted { [Bind ("isInterrupted")] get; }

		// -(instancetype _Nonnull)initWithSource:(TVIVideoCaptureSource)source;
		[Export ("initWithSource:")]
		IntPtr Constructor (/*mc++TVI*/VideoCaptureSource source);

		// -(instancetype _Nonnull)initWithDelegate:(id<TVICameraCapturerDelegate> _Nullable)delegate source:(TVIVideoCaptureSource)source;
		[Export ("initWithDelegate:source:")]
		IntPtr Constructor ([NullAllowed] /*mc++TVI*/CameraCapturerDelegate @delegate, /*mc++TVI*/VideoCaptureSource source);

		// -(void)selectSource:(TVIVideoCaptureSource)source;
		[Export ("selectSource:")]
		void SelectSource (/*mc++TVI*/VideoCaptureSource source);

		// -(void)selectNextSource;
		[Export ("selectNextSource")]
		void SelectNextSource ();

		// +(BOOL)isSourceAvailable:(TVIVideoCaptureSource)source;
		[Static]
		[Export ("isSourceAvailable:")]
		bool IsSourceAvailable (/*mc++TVI*/VideoCaptureSource source);

		// +(NSArray<NSNumber *> * _Nonnull)availableSources;
		[Static]
		[Export ("availableSources")]
		//mc++ [Verify (MethodToProperty)]
		NSNumber[] AvailableSources { get; }
	}

	// @interface TVICameraPreviewView : UIView
	[BaseType (typeof(UIView), Name = "TVICameraPreviewView")]
	interface /*mc++TVI*/CameraPreviewView
	{
		// @property (readonly, assign, nonatomic) UIInterfaceOrientation orientation;
		[Export ("orientation", ArgumentSemantic.Assign)]
		UIInterfaceOrientation Orientation { get; }
	}

	// @interface TVIClientOptionsBuilder : NSObject
	[BaseType (typeof(NSObject), Name="TVIClientOptionsBuilder")]
	interface /*mc++TVI*/ClientOptionsBuilder
	{
		// @property (nonatomic, strong) dispatch_queue_t _Nullable delegateQueue;
		[NullAllowed, Export ("delegateQueue", ArgumentSemantic.Strong)]
		DispatchQueue DelegateQueue { get; set; }
	}

	// typedef void (^TVIClientOptionsBuilderBlock)(TVIClientOptionsBuilder * _Nonnull);
	delegate void /*mc++TVI*/ClientOptionsBuilderBlock (/*mc++TVI*/ClientOptionsBuilder arg0);

	// @interface TVIClientOptions : NSObject
	[BaseType (typeof(NSObject), Name = "TVIClientOptions")]
	interface /*mc++TVI*/ClientOptions
	{
		// @property (readonly, nonatomic, strong) dispatch_queue_t _Nullable delegateQueue;
		[NullAllowed, Export ("delegateQueue", ArgumentSemantic.Strong)]
		DispatchQueue DelegateQueue { get; }

		// +(instancetype _Nonnull)options;
		[Static]
		[Export ("options")]
		/*mc++TVI*/ClientOptions Options ();

		// +(instancetype _Nonnull)optionsWithBlock:(TVIClientOptionsBuilderBlock _Nonnull)block;
		[Static]
		[Export ("optionsWithBlock:")]
		/*mc++TVI*/ClientOptions OptionsWithBlock (/*mc++TVI*/ClientOptionsBuilderBlock block);
	}

	// @interface TVIConnectOptionsBuilder : NSObject
	[BaseType (typeof(NSObject), Name = "TVIConnectOptionsBuilder")]
	interface /*mc++TVI*/ConnectOptionsBuilder
	{
		// @property (nonatomic, strong) TVIIceOptions * _Nullable iceOptions;
		[NullAllowed, Export ("iceOptions", ArgumentSemantic.Strong)]
		/*mc++TVI*/IceOptions IceOptions { get; set; }

		// @property (nonatomic, strong) TVILocalMedia * _Nullable localMedia;
		[NullAllowed, Export ("localMedia", ArgumentSemantic.Strong)]
		/*mc++TVI*/LocalMedia LocalMedia { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export ("name")]
		string Name { get; set; }
	}

	// @interface CallKit (TVIConnectOptionsBuilder)
	[Category]
	[BaseType (typeof(/*mc++TVI*/ConnectOptionsBuilder), Name = "TVIConnectOptionsBuilder_CallKit")]
	interface /*mc++TVI*/ConnectOptionsBuilder_CallKit
	{
		[Static] //mc++
		// @property (nonatomic, strong) NSUUID * _Nullable uuid;
		[NullAllowed, Export ("uuid", ArgumentSemantic.Strong)]
		NSUuid Uuid { get; set; }
	}

	// typedef void (^TVIConnectOptionsBuilderBlock)(TVIConnectOptionsBuilder * _Nonnull);
	delegate void /*mc++TVI*/ConnectOptionsBuilderBlock (/*mc++TVI*/ConnectOptionsBuilder arg0);

	// @interface TVIConnectOptions : NSObject
	[BaseType (typeof(NSObject), Name = "TVIConnectOptions")]
	interface /*mc++TVI*/ConnectOptions
	{
		// @property (readonly, nonatomic, strong) TVIIceOptions * _Nullable iceOptions;
		[NullAllowed, Export ("iceOptions", ArgumentSemantic.Strong)]
		/*mc++TVI*/IceOptions IceOptions { get; }

		// @property (readonly, nonatomic, strong) TVILocalMedia * _Nullable localMedia;
		[NullAllowed, Export ("localMedia", ArgumentSemantic.Strong)]
		/*mc++TVI*/LocalMedia LocalMedia { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable name;
		[NullAllowed, Export ("name")]
		string Name { get; }

		// +(instancetype _Nonnull)options;
		[Static]
		[Export ("options")]
		/*mc++TVI*/ConnectOptions Options ();

		// +(instancetype _Nonnull)optionsWithBlock:(TVIConnectOptionsBuilderBlock _Nonnull)block;
		[Static]
		[Export ("optionsWithBlock:")]
		/*mc++TVI*/ConnectOptions OptionsWithBlock (/*mc++TVI*/ConnectOptionsBuilderBlock block);
	}

	// @interface CallKit (TVIConnectOptions)
	[Category]
	[BaseType (typeof(/*mc++TVI*/ConnectOptions), Name = "TVIConnectOptions_CallKit")]
	interface /*mc++TVI*/ConnectOptions_CallKit
	{
		[Static] //mc++
		// @property (readonly, nonatomic, strong) NSUUID * _Nullable uuid;
		[NullAllowed, Export ("uuid", ArgumentSemantic.Strong)]
		NSUuid Uuid { get; }
	}

	//mc++ [Static]
	//mc++ [Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const kTVIErrorDomain;
		[Field ("kTVIErrorDomain", "__Internal")]
		NSString kTVIErrorDomain { get; }
	}

	// @interface TVIIceServer : NSObject
	[BaseType (typeof(NSObject), Name = "TVIIceServer")]
	interface /*mc++TVI*/IceServer
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull url;
		[Export ("url")]
		string Url { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable username;
		[NullAllowed, Export ("username")]
		string Username { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable password;
		[NullAllowed, Export ("password")]
		string Password { get; }

		// -(instancetype _Null_unspecified)initWithURL:(NSString * _Nonnull)serverUrl;
		[Export ("initWithURL:")]
		IntPtr Constructor (string serverUrl);

		// -(instancetype _Null_unspecified)initWithURL:(NSString * _Nonnull)serverUrl username:(NSString * _Nullable)username password:(NSString * _Nullable)password;
		[Export ("initWithURL:username:password:")]
		IntPtr Constructor (string serverUrl, [NullAllowed] string username, [NullAllowed] string password);
	}

	// @interface TVIIceOptionsBuilder : NSObject
	[BaseType (typeof(NSObject), Name = "TVIIceOptionsBuilder")]
	interface /*mc++TVI*/IceOptionsBuilder
	{
		// @property (nonatomic, strong) NSArray<TVIIceServer *> * _Nullable servers;
		[NullAllowed, Export ("servers", ArgumentSemantic.Strong)]
		/*mc++TVI*/IceServer[] Servers { get; set; }

		// @property (assign, nonatomic) TVIIceTransportPolicy transportPolicy;
		[Export ("transportPolicy", ArgumentSemantic.Assign)]
		/*mc++TVI*/IceTransportPolicy TransportPolicy { get; set; }
	}

	// typedef void (^TVIIceOptionsBuilderBlock)(TVIIceOptionsBuilder * _Nonnull);
	delegate void /*mc++TVI*/IceOptionsBuilderBlock (/*mc++TVI*/IceOptionsBuilder arg0);

	// @interface TVIIceOptions : NSObject
	[BaseType (typeof(NSObject), Name = "TVIIceOptions")]
	interface /*mc++TVI*/IceOptions
	{
		// @property (readonly, copy, nonatomic) NSArray<TVIIceServer *> * _Nonnull servers;
		[Export ("servers", ArgumentSemantic.Copy)]
		/*mc++TVI*/IceServer[] Servers { get; }

		// @property (readonly, assign, nonatomic) TVIIceTransportPolicy transportPolicy;
		[Export ("transportPolicy", ArgumentSemantic.Assign)]
		/*mc++TVI*/IceTransportPolicy TransportPolicy { get; }

		// +(instancetype _Null_unspecified)options;
		[Static]
		[Export ("options")]
		/*mc++TVI*/IceOptions Options ();

		// +(instancetype _Nonnull)optionsWithBlock:(TVIIceOptionsBuilderBlock _Nonnull)block;
		[Static]
		[Export ("optionsWithBlock:")]
		/*mc++TVI*/IceOptions OptionsWithBlock (/*mc++TVI*/IceOptionsBuilderBlock block);
	}

	// @interface TVILocalMedia : NSObject
	[BaseType (typeof(NSObject), Name = "TVILocalMedia")]
	interface /*mc++TVI*/LocalMedia
	{
		// @property (readonly, nonatomic, strong) TVIAudioController * _Nonnull audioController;
		[Export ("audioController", ArgumentSemantic.Strong)]
		/*mc++TVI*/AudioController AudioController { get; }

		// @property (readonly, nonatomic, strong) NSArray<TVILocalAudioTrack *> * _Nonnull audioTracks;
		[Export ("audioTracks", ArgumentSemantic.Strong)]
		/*mc++TVI*/LocalAudioTrack[] AudioTracks { get; }

		// @property (readonly, nonatomic, strong) NSArray<TVILocalVideoTrack *> * _Nonnull videoTracks;
		[Export ("videoTracks", ArgumentSemantic.Strong)]
		/*mc++TVI*/LocalVideoTrack[] VideoTracks { get; }

		// -(TVILocalAudioTrack * _Nullable)addAudioTrack:(BOOL)enabled;
		[Export ("addAudioTrack:")]
		[return: NullAllowed]
		/*mc++TVI*/LocalAudioTrack AddAudioTrack (bool enabled);

		// -(TVILocalAudioTrack * _Nullable)addAudioTrack:(BOOL)enabled constraints:(TVIAudioConstraints * _Nullable)constraints error:(NSError * _Nullable * _Nullable)error;
		[Export ("addAudioTrack:constraints:error:")]
		[return: NullAllowed]
		/*mc++TVI*/LocalAudioTrack AddAudioTrack (bool enabled, [NullAllowed] /*mc++TVI*/AudioConstraints constraints, [NullAllowed] out NSError error);

		// -(BOOL)removeAudioTrack:(TVILocalAudioTrack * _Nonnull)track;
		[Export ("removeAudioTrack:")]
		bool RemoveAudioTrack (/*mc++TVI*/LocalAudioTrack track);

		// -(BOOL)removeAudioTrack:(TVILocalAudioTrack * _Nonnull)track error:(NSError * _Nullable * _Nullable)error;
		[Export ("removeAudioTrack:error:")]
		bool RemoveAudioTrack (/*mc++TVI*/LocalAudioTrack track, [NullAllowed] out NSError error);

		// -(TVILocalVideoTrack * _Nullable)addVideoTrack:(BOOL)enabled capturer:(id<TVIVideoCapturer> _Nonnull)capturer;
		[Export ("addVideoTrack:capturer:")]
		[return: NullAllowed]
		/*mc++TVI*/LocalVideoTrack AddVideoTrack (bool enabled, /*mc++TVI*/VideoCapturer capturer);

		// -(TVILocalVideoTrack * _Nullable)addVideoTrack:(BOOL)enabled capturer:(id<TVIVideoCapturer> _Nonnull)capturer constraints:(TVIVideoConstraints * _Nullable)constraints error:(NSError * _Nullable * _Nullable)error;
		[Export ("addVideoTrack:capturer:constraints:error:")]
		[return: NullAllowed]
		/*mc++TVI*/LocalVideoTrack AddVideoTrack (bool enabled, /*mc++TVI*/VideoCapturer capturer, [NullAllowed] /*mc++TVI*/VideoConstraints constraints, [NullAllowed] out NSError error);

		// -(BOOL)removeVideoTrack:(TVILocalVideoTrack * _Nonnull)track;
		[Export ("removeVideoTrack:")]
		bool RemoveVideoTrack (/*mc++TVI*/LocalVideoTrack track);

		// -(BOOL)removeVideoTrack:(TVILocalVideoTrack * _Nonnull)track error:(NSError * _Nullable * _Nullable)error;
		[Export ("removeVideoTrack:error:")]
		bool RemoveVideoTrack (/*mc++TVI*/LocalVideoTrack track, [NullAllowed] out NSError error);
	}

	// @interface TVILocalParticipant : NSObject
	[BaseType (typeof(NSObject), Name = "TVILocalParticipant")]
	[DisableDefaultCtor]
	interface /*mc++TVI*/LocalParticipant
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull identity;
		[Export ("identity")]
		string Identity { get; }

		// @property (readonly, nonatomic, strong) TVILocalMedia * _Nonnull media;
		[Export ("media", ArgumentSemantic.Strong)]
		/*mc++TVI*/LocalMedia Media { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull sid;
		[Export ("sid")]
		string Sid { get; }
	}

	// @interface TVIMedia : NSObject
	[BaseType (typeof(NSObject), Name = "TVIMedia")]
	[DisableDefaultCtor]
	interface /*mc++TVI*/Media
	{
		// @property (readonly, copy, nonatomic) NSArray<TVIAudioTrack *> * _Nonnull audioTracks;
		[Export ("audioTracks", ArgumentSemantic.Copy)]
		/*mc++TVI*/AudioTrack[] AudioTracks { get; }

		// @property (readonly, copy, nonatomic) NSArray<TVIVideoTrack *> * _Nonnull videoTracks;
		[Export ("videoTracks", ArgumentSemantic.Copy)]
		/*mc++TVI*/VideoTrack[] VideoTracks { get; }

		// -(TVITrack * _Nullable)getTrack:(NSString * _Nonnull)trackId;
		[Export ("getTrack:")]
		[return: NullAllowed]
		/*mc++TVI*/Track GetTrack (string trackId);

		// -(TVIAudioTrack * _Nullable)getAudioTrack:(NSString * _Nonnull)trackId;
		[Export ("getAudioTrack:")]
		[return: NullAllowed]
		/*mc++TVI*/AudioTrack GetAudioTrack (string trackId);

		// -(TVIVideoTrack * _Nullable)getVideoTrack:(NSString * _Nonnull)trackId;
		[Export ("getVideoTrack:")]
		[return: NullAllowed]
		/*mc++TVI*/VideoTrack GetVideoTrack (string trackId);
	}

	// @interface TVIParticipant : NSObject
	[BaseType (typeof(NSObject), Name = "TVIParticipant")]
	[DisableDefaultCtor]
	interface /*mc++TVI*/Participant
	{
		// @property (readonly, getter = isConnected, assign, nonatomic) BOOL connected;
		[Export ("connected")]
		bool Connected { [Bind ("isConnected")] get; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		/*mc++TVI*/ParticipantDelegate Delegate { get; set; }

		// @property (atomic, weak) id<TVIParticipantDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull identity;
		[Export ("identity")]
		string Identity { get; }

		// @property (readonly, nonatomic, strong) TVIMedia * _Nonnull media;
		[Export ("media", ArgumentSemantic.Strong)]
		/*mc++TVI*/Media Media { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable sid;
		[NullAllowed, Export ("sid")]
		string Sid { get; }
	}

	// @protocol TVIParticipantDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject), Name = "TVIParticipantDelegate")]
	interface /*mc++TVI*/ParticipantDelegate
	{
		// @optional -(void)participant:(TVIParticipant * _Nonnull)participant addedVideoTrack:(TVIVideoTrack * _Nonnull)videoTrack;
		[Export ("participant:addedVideoTrack:")]
		void AddedVideoTrack (/*mc++TVI*/Participant participant, /*mc++TVI*/VideoTrack videoTrack);

		// @optional -(void)participant:(TVIParticipant * _Nonnull)participant removedVideoTrack:(TVIVideoTrack * _Nonnull)videoTrack;
		[Export ("participant:removedVideoTrack:")]
		void RemovedVideoTrack (/*mc++TVI*/Participant participant, /*mc++TVI*/VideoTrack videoTrack);

		// @optional -(void)participant:(TVIParticipant * _Nonnull)participant addedAudioTrack:(TVIAudioTrack * _Nonnull)audioTrack;
		[Export ("participant:addedAudioTrack:")]
		void AddedAudioTrack (/*mc++TVI*/Participant participant, /*mc++TVI*/AudioTrack audioTrack);

		// @optional -(void)participant:(TVIParticipant * _Nonnull)participant removedAudioTrack:(TVIAudioTrack * _Nonnull)audioTrack;
		[Export ("participant:removedAudioTrack:")]
		void RemovedAudioTrack (/*mc++TVI*/Participant participant, /*mc++TVI*/AudioTrack audioTrack);

		// @optional -(void)participant:(TVIParticipant * _Nonnull)participant enabledTrack:(TVITrack * _Nonnull)track;
		[Export ("participant:enabledTrack:")]
		void EnabledTrack (/*mc++TVI*/Participant participant, /*mc++TVI*/Track track);

		// @optional -(void)participant:(TVIParticipant * _Nonnull)participant disabledTrack:(TVITrack * _Nonnull)track;
		[Export ("participant:disabledTrack:")]
		void DisabledTrack (/*mc++TVI*/Participant participant, /*mc++TVI*/Track track);
	}

	// @interface TVIRoom : NSObject
	[BaseType (typeof(NSObject), Name = "TVIRoom")]
	[DisableDefaultCtor]
	interface /*mc++TVI*/Room
	{
		[Wrap ("WeakDelegate")]
		[NullAllowed]
		/*mc++TVI*/RoomDelegate Delegate { get; }

		// @property (readonly, nonatomic, weak) id<TVIRoomDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; }

		// @property (readonly, nonatomic, strong) TVILocalParticipant * _Nullable localParticipant;
		[NullAllowed, Export ("localParticipant", ArgumentSemantic.Strong)]
		/*mc++TVI*/LocalParticipant LocalParticipant { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull name;
		[Export ("name")]
		string Name { get; }

		// @property (readonly, copy, nonatomic) NSArray<TVIParticipant *> * _Nonnull participants;
		[Export ("participants", ArgumentSemantic.Copy)]
		/*mc++TVI*/Participant[] Participants { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull sid;
		[Export ("sid")]
		string Sid { get; }

		// @property (readonly, assign, nonatomic) TVIRoomState state;
		[Export ("state", ArgumentSemantic.Assign)]
		/*mc++TVI*/RoomState State { get; }

		// -(TVIParticipant * _Nullable)getParticipantWithSid:(NSString * _Nonnull)sid;
		[Export ("getParticipantWithSid:")]
		[return: NullAllowed]
		/*mc++TVI*/Participant GetParticipantWithSid (string sid);

		// -(void)disconnect;
		[Export ("disconnect")]
		void Disconnect ();
	}

	// @interface CallKit (TVIRoom)
	[Category]
	[BaseType (typeof(/*mc++TVI*/Room), Name = "TVIRoom_CallKit")]
	interface /*mc++TVI*/Room_CallKit
	{
		[Static] //mc++
		// @property (readonly, nonatomic) NSUUID * _Nullable uuid;
		[NullAllowed, Export ("uuid")]
		NSUuid Uuid { get; }
	}

	// @protocol TVIRoomDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject), Name = "TVIRoomDelegate")]
	interface /*mc++TVI*/RoomDelegate
	{
		// @optional -(void)didConnectToRoom:(TVIRoom * _Nonnull)room;
		[Export ("didConnectToRoom:")]
		void DidConnectToRoom (/*mc++TVI*/Room room);

		// @optional -(void)room:(TVIRoom * _Nonnull)room didFailToConnectWithError:(NSError * _Nonnull)error;
		[Export ("room:didFailToConnectWithError:")]
		void RoomFailedToConnect (/*mc++TVI*/Room room, NSError error);

		// @optional -(void)room:(TVIRoom * _Nonnull)room didDisconnectWithError:(NSError * _Nullable)error;
		[Export ("room:didDisconnectWithError:")]
		void RoomDisconnected (/*mc++TVI*/Room room, [NullAllowed] NSError error);

		// @optional -(void)room:(TVIRoom * _Nonnull)room participantDidConnect:(TVIParticipant * _Nonnull)participant;
		[Export ("room:participantDidConnect:")]
		void Room (/*mc++TVI*/Room room, /*mc++TVI*/Participant participant);

		// @optional -(void)room:(TVIRoom * _Nonnull)room participantDidDisconnect:(TVIParticipant * _Nonnull)participant;
		[Export ("room:participantDidDisconnect:")]
		void RoomparticipantDisconnected (/*mc++TVI*/Room room, /*mc++TVI*/Participant participant);
	}

	// @interface TVIScreenCapturer : NSObject <TVIVideoCapturer>
	[BaseType (typeof(NSObject), Name = "TVIScreenCapturer")]
	[DisableDefaultCtor]
	interface /*mc++TVI*/ScreenCapturer : /*mc++ I*//*mc++TVI*/VideoCapturer
	{
		// @property (readonly, getter = isCapturing, assign, atomic) BOOL capturing;
		[Export ("capturing")]
		bool Capturing { [Bind ("isCapturing")] get; }

		// -(instancetype _Null_unspecified)initWithView:(UIView * _Nonnull)view;
		[Export ("initWithView:")]
		IntPtr Constructor (UIView view);
	}

	[Static]
	//mc++ [Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern const NSUInteger TVIVideoConstraintsMaximumFPS;
		[Field ("TVIVideoConstraintsMaximumFPS", "__Internal")]
		nuint /*mc++TVI*/VideoConstraintsMaximumFPS { get; }

		// extern const NSUInteger TVIVideoConstraintsMinimumFPS;
		[Field ("TVIVideoConstraintsMinimumFPS", "__Internal")]
		nuint /*mc++TVI*/VideoConstraintsMinimumFPS { get; }

		// extern const CMVideoDimensions TVIVideoConstraintsSizeNone;
		[Field ("TVIVideoConstraintsSizeNone", "__Internal")]
		/*mc++ CMVideoDimensions*/ IntPtr /*mc++TVI*/VideoConstraintsSizeNone { get; }

		// extern const NSUInteger TVIVideoConstraintsFrameRateNone;
		[Field ("TVIVideoConstraintsFrameRateNone", "__Internal")]
		nuint TVIVideoConstraintsFrameRateNone { get; }

		// extern const TVIAspectRatio TVIVideoConstraintsAspectRatioNone;
		[Field ("TVIVideoConstraintsAspectRatioNone", "__Internal")]
		/*mc++ TVIAspectRatio*/ IntPtr /*mc++TVI*/VideoConstraintsAspectRatioNone { get; }

		// extern const TVIAspectRatio TVIAspectRatio11x9;
		[Field ("TVIAspectRatio11x9", "__Internal")]
		/*mc++ TVIAspectRatio*/ IntPtr /*mc++TVI*/AspectRatio11x9 { get; }

		// extern const TVIAspectRatio TVIAspectRatio4x3;
		[Field ("TVIAspectRatio4x3", "__Internal")]
		/*mc++ TVIAspectRatio*/ IntPtr /*mc++TVI*/AspectRatio4x3 { get; }

		// extern const TVIAspectRatio TVIAspectRatio16x9;
		[Field ("TVIAspectRatio16x9", "__Internal")]
		/*mc++ TVIAspectRatio*/ IntPtr /*mc++TVI*/AspectRatio16x9 { get; }
	}

	// @interface TVIVideoConstraintsBuilder : NSObject
	[BaseType (typeof(NSObject), Name="TVIVideoConstraintsBuilder")]
	interface /*mc++TVI*/VideoConstraintsBuilder
	{
		// @property (assign, nonatomic) CMVideoDimensions maxSize;
		[Export ("maxSize", ArgumentSemantic.Assign)]
		CMVideoDimensions MaxSize { get; set; }

		// @property (assign, nonatomic) CMVideoDimensions minSize;
		[Export ("minSize", ArgumentSemantic.Assign)]
		CMVideoDimensions MinSize { get; set; }

		// @property (assign, nonatomic) NSUInteger maxFrameRate;
		[Export ("maxFrameRate")]
		nuint MaxFrameRate { get; set; }

		// @property (assign, nonatomic) NSUInteger minFrameRate;
		[Export ("minFrameRate")]
		nuint MinFrameRate { get; set; }

		// @property (assign, nonatomic) TVIAspectRatio aspectRatio;
		[Export ("aspectRatio", ArgumentSemantic.Assign)]
		/*mc++TVI*/AspectRatio AspectRatio { get; set; }
	}

	// typedef void (^TVIVideoConstraintsBuilderBlock)(TVIVideoConstraintsBuilder * _Nonnull);
	delegate void /*mc++TVI*/VideoConstraintsBuilderBlock (/*mc++TVI*/VideoConstraintsBuilder arg0);

	// @interface TVIVideoConstraints : NSObject
	[BaseType (typeof(NSObject), Name = "TVIVideoConstraints")]
	interface /*mc++TVI*/VideoConstraints
	{
		// +(instancetype _Null_unspecified)constraints;
		[Static]
		[Export ("constraints")]
		/*mc++TVI*/VideoConstraints Constraints ();

		// +(instancetype _Null_unspecified)constraintsWithBlock:(TVIVideoConstraintsBuilderBlock _Nonnull)builderBlock;
		[Static]
		[Export ("constraintsWithBlock:")]
		/*mc++TVI*/VideoConstraints ConstraintsWithBlock (/*mc++TVI*/VideoConstraintsBuilderBlock builderBlock);

		// @property (readonly, assign, nonatomic) CMVideoDimensions maxSize;
		[Export ("maxSize", ArgumentSemantic.Assign)]
		CMVideoDimensions MaxSize { get; }

		// @property (readonly, assign, nonatomic) CMVideoDimensions minSize;
		[Export ("minSize", ArgumentSemantic.Assign)]
		CMVideoDimensions MinSize { get; }

		// @property (readonly, assign, nonatomic) NSUInteger maxFrameRate;
		[Export ("maxFrameRate")]
		nuint MaxFrameRate { get; }

		// @property (readonly, assign, nonatomic) NSUInteger minFrameRate;
		[Export ("minFrameRate")]
		nuint MinFrameRate { get; }

		// @property (readonly, assign, nonatomic) TVIAspectRatio aspectRatio;
		[Export ("aspectRatio", ArgumentSemantic.Assign)]
		/*mc++TVI*/AspectRatio AspectRatio { get; }
	}

	// @protocol TVIVideoRenderer <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject), Name = "TVIVideoRenderer")]
	interface /*mc++TVI*/VideoRenderer
	{
		// @required -(void)renderFrame:(TVII420Frame * _Nonnull)frame;
		[Abstract]
		[Export ("renderFrame:")]
		void RenderFrame (/*mc++TVI*/I420Frame frame);

		// @required -(void)updateVideoSize:(CMVideoDimensions)videoSize orientation:(TVIVideoOrientation)orientation;
		[Abstract]
		[Export ("updateVideoSize:orientation:")]
		void UpdateVideoSize (CMVideoDimensions videoSize, /*mc++TVI*/VideoOrientation orientation);

		// @optional -(BOOL)supportsVideoFrameOrientation;
		[Export ("supportsVideoFrameOrientation")]
		//mc++ [Verify (MethodToProperty)]
		bool SupportsVideoFrameOrientation { get; }
	}

	// @protocol TVIVideoTrackDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject), Name = "TVIVideoTrackDelegate")]
	interface /*mc++TVI*/VideoTrackDelegate
	{
		// @optional -(void)videoTrack:(TVIVideoTrack * _Nonnull)track dimensionsDidChange:(CMVideoDimensions)dimensions;
		[Export ("videoTrack:dimensionsDidChange:")]
		void DimensionsDidChange (/*mc++TVI*/VideoTrack track, CMVideoDimensions dimensions);
	}

	// @interface TVIVideoTrack : TVITrack
	[BaseType (typeof(/*mc++TVI*/Track), Name = "TVIVideoTrack")]
	[DisableDefaultCtor]
	interface /*mc++TVI*/VideoTrack
	{
		[Wrap ("WeakDelegate")]
		[NullAllowed]
		/*mc++TVI*/VideoTrackDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<TVIVideoTrackDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) NSArray<UIView *> * _Nonnull attachedViews;
		[Export ("attachedViews", ArgumentSemantic.Strong)]
		UIView[] AttachedViews { get; }

		// @property (readonly, nonatomic, strong) NSArray<id<TVIVideoRenderer>> * _Nonnull renderers;
		[Export ("renderers", ArgumentSemantic.Strong)]
		/*mc++TVI*/VideoRenderer[] Renderers { get; }

		// @property (readonly, assign, nonatomic) CMVideoDimensions videoDimensions;
		[Export ("videoDimensions", ArgumentSemantic.Assign)]
		CMVideoDimensions VideoDimensions { get; }

		// -(void)attach:(UIView * _Nonnull)view;
		[Export ("attach:")]
		void Attach (UIView view);

		// -(void)detach:(UIView * _Nonnull)view;
		[Export ("detach:")]
		void Detach (UIView view);

		// -(void)addRenderer:(id<TVIVideoRenderer> _Nonnull)renderer;
		[Export ("addRenderer:")]
		void AddRenderer (/*mc++TVI*/VideoRenderer renderer);

		// -(void)removeRenderer:(id<TVIVideoRenderer> _Nonnull)renderer;
		[Export ("removeRenderer:")]
		void RemoveRenderer (/*mc++TVI*/VideoRenderer renderer);
	}

	// @interface TVILocalVideoTrack : TVIVideoTrack
	[BaseType (typeof(/*mc++TVI*/VideoTrack), Name = "TVILocalVideoTrack")]
	[DisableDefaultCtor]
	interface /*mc++TVI*/LocalVideoTrack
	{
		// @property (getter = isEnabled, assign, nonatomic) BOOL enabled;
		[Export ("enabled")]
		bool Enabled { [Bind ("isEnabled")] get; set; }

		// @property (readonly, nonatomic, strong) id<TVIVideoCapturer> _Nonnull capturer;
		[Export ("capturer", ArgumentSemantic.Strong)]
		/*mc++TVI*/VideoCapturer Capturer { get; }

		// @property (readonly, nonatomic, strong) TVIVideoConstraints * _Nonnull constraints;
		[Export ("constraints", ArgumentSemantic.Strong)]
		/*mc++TVI*/VideoConstraints Constraints { get; }
	}

	// @protocol TVIVideoViewRendererDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject), Name = "TVIVideoViewRendererDelegate")]
	interface /*mc++TVI*/VideoViewRendererDelegate
	{
		// @optional -(void)rendererDidReceiveVideoData:(TVIVideoViewRenderer * _Nonnull)renderer;
		[Export ("rendererDidReceiveVideoData:")]
		void RendererDidReceiveVideoData (/*mc++TVI*/VideoViewRenderer renderer);

		// @optional -(void)renderer:(TVIVideoViewRenderer * _Nonnull)renderer dimensionsDidChange:(CMVideoDimensions)dimensions;
		[Export ("renderer:dimensionsDidChange:")]
		void Renderer (/*mc++TVI*/VideoViewRenderer renderer, CMVideoDimensions dimensions);

		// @optional -(void)renderer:(TVIVideoViewRenderer * _Nonnull)renderer orientationDidChange:(TVIVideoOrientation)orientation;
		[Export ("renderer:orientationDidChange:")]
		void Renderer (/*mc++TVI*/VideoViewRenderer renderer, /*mc++TVI*/VideoOrientation orientation);

		// @optional -(BOOL)rendererShouldRotateContent:(TVIVideoViewRenderer * _Nonnull)renderer;
		[Export ("rendererShouldRotateContent:")]
		bool RendererShouldRotateContent (/*mc++TVI*/VideoViewRenderer renderer);
	}

	// @interface TVIVideoViewRenderer : NSObject <TVIVideoRenderer>
	[BaseType (typeof(NSObject), Name = "TVIVideoViewRenderer")]
	interface /*mc++TVI*/VideoViewRenderer : /*mc++ I*//*mc++TVI*/VideoRenderer
	{
		// -(instancetype _Nonnull)initWithDelegate:(id<TVIVideoViewRendererDelegate> _Nullable)delegate;
		[Export ("initWithDelegate:")]
		IntPtr Constructor ([NullAllowed] /*mc++TVI*/VideoViewRendererDelegate @delegate);

		// +(TVIVideoViewRenderer * _Nonnull)rendererWithDelegate:(id<TVIVideoViewRendererDelegate> _Nullable)delegate;
		[Static]
		[Export ("rendererWithDelegate:")]
		/*mc++TVI*/VideoViewRenderer RendererWithDelegate ([NullAllowed] /*mc++TVI*/VideoViewRendererDelegate @delegate);

		// +(TVIVideoViewRenderer * _Nonnull)rendererWithRenderingType:(TVIVideoRenderingType)renderingType delegate:(id<TVIVideoViewRendererDelegate> _Nullable)delegate;
		[Static]
		[Export ("rendererWithRenderingType:delegate:")]
		/*mc++TVI*/VideoViewRenderer RendererWithRenderingType (/*mc++TVI*/VideoRenderingType renderingType, [NullAllowed] /*mc++TVI*/VideoViewRendererDelegate @delegate);

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		/*mc++TVI*/VideoViewRendererDelegate Delegate { get; }

		// @property (readonly, nonatomic, weak) id<TVIVideoViewRendererDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; }

		// @property (readonly, assign, nonatomic) CMVideoDimensions videoFrameDimensions;
		[Export ("videoFrameDimensions", ArgumentSemantic.Assign)]
		CMVideoDimensions VideoFrameDimensions { get; }

		// @property (readonly, assign, nonatomic) TVIVideoOrientation videoFrameOrientation;
		[Export ("videoFrameOrientation", ArgumentSemantic.Assign)]
		/*mc++TVI*/VideoOrientation VideoFrameOrientation { get; }

		// @property (readonly, assign, atomic) BOOL hasVideoData;
		[Export ("hasVideoData")]
		bool HasVideoData { get; }

		// @property (readonly, nonatomic, strong) UIView * _Nonnull view;
		[Export ("view", ArgumentSemantic.Strong)]
		UIView View { get; }
	}

	// @interface TVIVideoClient : NSObject
	[BaseType (typeof(NSObject), Name = "TVIVideoClient")]
	[DisableDefaultCtor]
	interface /*mc++TVI*/VideoClient
	{
		// +(instancetype _Null_unspecified)clientWithToken:(NSString * _Nonnull)token;
		[Static]
		[Export ("clientWithToken:")]
		/*mc++TVI*/VideoClient ClientWithToken (string token);

		// +(instancetype _Null_unspecified)clientWithToken:(NSString * _Nonnull)token options:(TVIClientOptions * _Nullable)clientOptions;
		[Static]
		[Export ("clientWithToken:options:")]
		/*mc++TVI*/VideoClient ClientWithToken (string token, [NullAllowed] /*mc++TVI*/ClientOptions clientOptions);

		// -(void)updateToken:(NSString * _Nonnull)token;
		[Export ("updateToken:")]
		void UpdateToken (string token);

		// -(TVIRoom * _Nonnull)connectWithDelegate:(id<TVIRoomDelegate> _Nullable)delegate;
		[Export ("connectWithDelegate:")]
		/*mc++TVI*/Room ConnectWithDelegate ([NullAllowed] /*mc++TVI*/RoomDelegate @delegate);

		// -(TVIRoom * _Nonnull)connectWithOptions:(TVIConnectOptions * _Nullable)options delegate:(id<TVIRoomDelegate> _Nullable)delegate;
		[Export ("connectWithOptions:delegate:")]
		/*mc++TVI*/Room ConnectWithOptions ([NullAllowed] /*mc++TVI*/ConnectOptions options, [NullAllowed] /*mc++TVI*/RoomDelegate @delegate);

		// +(NSString * _Nonnull)version;
		[Static]
		[Export ("version")]
		//mc++ [Verify (MethodToProperty)]
		string Version { get; }

		// +(TVILogLevel)logLevel;
		// +(void)setLogLevel:(TVILogLevel)logLevel;
		[Static]
		[Export ("logLevel")]
		//mc++ [Verify (MethodToProperty)]
		/*mc++TVI*/LogLevel LogLevel { get; set; }

		// +(void)setLogLevel:(TVILogLevel)logLevel module:(TVILogModule)module;
		[Static]
		[Export ("setLogLevel:module:")]
		void SetLogLevel (/*mc++TVI*/LogLevel logLevel, /*mc++TVI*/LogModule module);
	}
}
