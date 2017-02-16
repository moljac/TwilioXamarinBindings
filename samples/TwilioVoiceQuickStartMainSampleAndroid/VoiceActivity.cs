using System;
using System.Collections.Generic;

namespace TwilioVoiceQuickStartMainSampleAndroid
{

	using ActivityCompat = Android.Support.V4.App.ActivityCompat;
	using AlertDialog = Android.Support.V7.App.AlertDialog;
	using AppCompatActivity = Android.Support.V7.App.AppCompatActivity;
	using AudioManager = Android.Media.AudioManager;
	using BroadcastReceiver = Android.Content.BroadcastReceiver;
	using Bundle = Android.OS.Bundle;
	using Chronometer = Android.Widget.Chronometer;
	using ConnectionResult = /*com.google.Android.gms.common*/Android.Gms.Common.ConnectionResult;
	using Context = Android.Content.Context;
	using ContextCompat = Android.Support.V4.Content.ContextCompat;
	//mc++using NonNull = Android.Support.Annotations.NonNull;
	using CoordinatorLayout = Android.Support.Design.Widget.CoordinatorLayout;
	using DialogInterface = Android.Content.DialogInterface;
	using FloatingActionButton = Android.Support.Design.Widget.FloatingActionButton;
	using FutureCallback = com.koushikdutta.@async.future.FutureCallback;
	using GCMRegistrationService = GCMRegistrationService;
	using GoogleApiAvailability = /*com.google.Android.gms.common*/Android.GMS.Common.GoogleApiAvailability;
	using Intent = Android.Content.Intent;
	using IntentFilter = Android.Content.IntentFilter;
	using Ion = com.koushikdutta.ion.Ion;
	using LocalBroadcastManager = Android.Support.V4.Content.LocalBroadcastManager;
	using Log = Android.Util.Log;
	using Manifest = Android.Manifest;
	using NotificationManager = Android.App.NotificationManager;
	using PackageManager = Android.Content.PM.PackageManager;
	using Snackbar = Android.Support.Design.Widget.Snackbar;
	using SystemClock = Android.OS.SystemClock;
	using View = Android.Viewss.View;

	public class VoiceActivity : AppCompatActivity
	{
		FutureCallback g;

		private bool InstanceFieldsInitialized = false;

		public VoiceActivity()
		{
			if (!InstanceFieldsInitialized)
			{
				InitializeInstanceFields();
				InstanceFieldsInitialized = true;
			}
		}

		private void InitializeInstanceFields()
		{
			registrationListener_Renamed = registrationListener();
			outgoingCallListener_Renamed = outgoingCallListener();
			incomingCallListener_Renamed = IncomingCallListener();
			incomingCallMessageListener_Renamed = incomingCallMessageListener();
		}


		private const string TAG = "VoiceActivity";

		private const string ACCESS_TOKEN_SERVICE_URL = "PROVIDE_YOUR_ACCESS_TOKEN_SERVER";

		private const int MIC_PERMISSION_REQUEST_CODE = 1;
		private const int PLAY_SERVICES_RESOLUTION_REQUEST = 9000;

		private bool speakerPhone;
		private AudioManager audioManager;
		private int savedAudioMode = AudioManager.MODE_INVALID;

		private bool isReceiverRegistered;
		private VoiceBroadcastReceiver voiceBroadcastReceiver;

		// Empty HashMap, never populated for the Quickstart
		internal Dictionary<string, string> twiMLParams = new Dictionary<string, string>();

		private CoordinatorLayout coordinatorLayout;
		private FloatingActionButton callActionFab;
		private FloatingActionButton hangupActionFab;
		private FloatingActionButton speakerActionFab;
		private Chronometer chronometer;

		private OutgoingCall activeOutgoingCall;
		private IncomingCall activeIncomingCall;

		public const string ACTION_SET_GCM_TOKEN = "SET_GCM_TOKEN";
		public const string INCOMING_CALL_MESSAGE = "INCOMING_CALL_MESSAGE";
		public const string INCOMING_CALL_NOTIFICATION_ID = "INCOMING_CALL_NOTIFICATION_ID";
		public const string ACTION_INCOMING_CALL = "INCOMING_CALL";

		public const string KEY_GCM_TOKEN = "GCM_TOKEN";

		private NotificationManager notificationManager;
		private string gcmToken;
		private string accessToken;
		private AlertDialog alertDialog;

		internal RegistrationListener registrationListener_Renamed;
		internal OutgoingCall.Listener outgoingCallListener_Renamed;
		internal IncomingCall.Listener incomingCallListener_Renamed;
		internal IncomingCallMessageListener incomingCallMessageListener_Renamed;

		protected internal override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			ContentView = Resource.Layout.activity_voice;
			coordinatorLayout = (CoordinatorLayout) FindViewById<>(Resource.Id.coordinator_layout);
			callActionFab = (FloatingActionButton) FindViewById<>(Resource.Id.call_action_fab);
			hangupActionFab = (FloatingActionButton) FindViewById<>(Resource.Id.hangup_action_fab);
			speakerActionFab = (FloatingActionButton) FindViewById<>(Resource.Id.speakerphone_action_fab);
			chronometer = (Chronometer) FindViewById<>(Resource.Id.chronometer);

			callActionFab.OnClickListener = CallActionFabClickListener();
			hangupActionFab.OnClickListener = HangupActionFabClickListener();
			speakerActionFab.OnClickListener = SpeakerphoneActionFabClickListener();

			notificationManager = (NotificationManager) getSystemService(Context.NOTIFICATION_SERVICE);

			/*
			 * Setup the broadcast receiver to be notified of GCM Token updates
			 * or incoming call messages in this Activity.
			 */
			voiceBroadcastReceiver = new VoiceBroadcastReceiver(this);
			RegisterReceiver();

			/*
			 * Needed for setting/abandoning audio focus during a call
			 */
			audioManager = (AudioManager) getSystemService(Context.AUDIO_SERVICE);

			/*
			 * Enable changing the volume using the up/down keys during a conversation
			 */
			VolumeControlStream = AudioManager.STREAM_VOICE_CALL;

			/*
			 * Displays a call dialog if the intent contains an incoming call message
			 */
			HandleIncomingCallIntent(Intent);


			/*
			 * Ensure the microphone permission is enabled
			 */
			if (!CheckPermissionForMicrophone())
			{
				RequestPermissionForMicrophone();
			}
			else
			{
				startGCMRegistration();
			}
		}

		protected internal override void onNewIntent(Intent intent)
		{
			base.onNewIntent(intent);
			HandleIncomingCallIntent(intent);
		}

		private void startGCMRegistration()
		{
			if (CheckPlayServices())
			{
				Intent intent = new Intent(this, typeof(GCMRegistrationService));
				startService(intent);
			}
		}

		private IncomingCallMessageListener incomingCallMessageListener()
		{
			return new IncomingCallMessageListenerAnonymousInnerClassHelper(this);
		}

		private class IncomingCallMessageListenerAnonymousInnerClassHelper : IncomingCallMessageListener
		{
			private readonly VoiceActivity outerInstance;

			public IncomingCallMessageListenerAnonymousInnerClassHelper(VoiceActivity outerInstance)
			{
				this.outerInstance = outerInstance;
			}

			public override void onIncomingCall(IncomingCall incomingCall)
			{
				Log.d(TAG, "Incoming call from " + incomingCall.From);
				outerInstance.activeIncomingCall = incomingCall;
				outerInstance.alertDialog = CreateIncomingCallDialog(outerInstance, incomingCall, outerInstance.AnswerCallClickListener(), outerInstance.cancelCallClickListener());
				outerInstance.alertDialog.show();
			}

			public override void onIncomingCallCancelled(IncomingCall incomingCall)
			{
				Log.d(TAG, "Incoming call from " + incomingCall.From + " was cancelled");
				if (outerInstance.activeIncomingCall != null && incomingCall.CallSid == outerInstance.activeIncomingCall.CallSid && incomingCall.State == CallState.PENDING)
				{
					outerInstance.activeIncomingCall = null;
					if (outerInstance.alertDialog != null)
					{
						outerInstance.alertDialog.dismiss();
					}
				}
			}

		}

		private RegistrationListener registrationListener()
		{
			return new RegistrationListenerAnonymousInnerClassHelper(this);
		}

		private class RegistrationListenerAnonymousInnerClassHelper : RegistrationListener
		{
			private readonly VoiceActivity outerInstance;

			public RegistrationListenerAnonymousInnerClassHelper(VoiceActivity outerInstance)
			{
				this.outerInstance = outerInstance;
			}

			public override void onRegistered(string accessToken, string gcmToken)
			{
				Log.d(TAG, "Successfully registered");
			}

			public override void onError(RegistrationException error, string accessToken, string gcmToken)
			{
				Log.e(TAG, string.Format("Error: {0:D}, {1}", error.ErrorCode, error.Message));
			}
		}

		private OutgoingCall.Listener outgoingCallListener()
		{
			return new OutgoingCallListenerAnonymousInnerClassHelper(this);
		}

		private class OutgoingCallListenerAnonymousInnerClassHelper : OutgoingCall.Listener
		{
			private readonly VoiceActivity outerInstance;

			public OutgoingCallListenerAnonymousInnerClassHelper(VoiceActivity outerInstance)
			{
				this.outerInstance = outerInstance;
			}

			public override void OnConnected(OutgoingCall outgoingCall)
			{
				Log.d(TAG, "Connected");
			}

			public override void OnDisconnected(OutgoingCall outgoingCall)
			{
				outerInstance.resetUI();
				Log.d(TAG, "Disconnect");
			}

			public override void OnDisconnected(OutgoingCall outgoingCall, CallException error)
			{
				outerInstance.resetUI();
				Log.e(TAG, string.Format("Error: {0:D}, {1}", error.ErrorCode, error.Message));
			}
		}

		private IncomingCall.Listener IncomingCallListener()
		{
			return new IncomingCallListenerAnonymousInnerClassHelper(this);
		}

		private class IncomingCallListenerAnonymousInnerClassHelper : IncomingCall.Listener
		{
			private readonly VoiceActivity outerInstance;

			public IncomingCallListenerAnonymousInnerClassHelper(VoiceActivity outerInstance)
			{
				this.outerInstance = outerInstance;
			}

			public override void OnConnected(IncomingCall incomingCall)
			{
				Log.d(TAG, "Connected");
			}

			public override void OnDisconnected(IncomingCall incomingCall)
			{
				outerInstance.resetUI();
				Log.d(TAG, "Disconnected");
			}

			public override void OnDisconnected(IncomingCall incomingCall, CallException error)
			{
				outerInstance.resetUI();
				Log.e(TAG, string.Format("Error: {0:D}, {1}", error.ErrorCode, error.Message));
			}
		}

		/*
		 * The UI state when there is an active call
		 */
		private void SetCallUI()
		{
			callActionFab.hide();
			hangupActionFab.show();
			speakerActionFab.show();
			chronometer.Visibility = View.VISIBLE;
			chronometer.Base = SystemClock.ElapsedRealtime();
			chronometer.Start();
		}

		/*
		 * Reset UI elements
		 */
		private void ResetUI()
		{
			speakerPhone = false;
			audioManager.SpeakerphoneOn = speakerPhone;
			AudioFocus = speakerPhone;
			speakerActionFab.ImageDrawable = ContextCompat.GetDrawable(/*mc++ VoiceActivity.*/this, Resource.Drawable.ic_volume_down_white_24px);
			speakerActionFab.hide();
			callActionFab.show();
			hangupActionFab.hide();
			chronometer.Visibility = View.INVISIBLE;
			chronometer.Stop();
		}

		protected internal override void OnResume()
		{
			base.OnResume();
			RegisterReceiver();
		}

		protected internal override void OnPause()
		{
			base.onPause();
			LocalBroadcastManager.getInstance(this).unregisterReceiver(voiceBroadcastReceiver);
			isReceiverRegistered = false;
		}

		private void HandleIncomingCallIntent(Intent intent)
		{
			if (intent != null && intent.Action != null && intent.Action == VoiceActivity.ACTION_INCOMING_CALL)
			{
				IncomingCallMessage incomingCallMessage = intent.GetParcelableExtra(INCOMING_CALL_MESSAGE);
				VoiceClient.handleIncomingCallMessage(ApplicationContext, incomingCallMessage, incomingCallMessageListener_Renamed);
			}
		}

		private void RegisterReceiver()
		{
			if (!isReceiverRegistered)
			{
				IntentFilter intentFilter = new IntentFilter();
				intentFilter.AddAction(ACTION_SET_GCM_TOKEN);
				intentFilter.AddAction(ACTION_INCOMING_CALL);
				LocalBroadcastManager.GetInstance(this).registerReceiver(voiceBroadcastReceiver, intentFilter);
				isReceiverRegistered = true;
			}
		}

		private class VoiceBroadcastReceiver : BroadcastReceiver
		{
			private readonly VoiceActivity outerInstance;

			public VoiceBroadcastReceiver(VoiceActivity outerInstance)
			{
				this.outerInstance = outerInstance;
			}


			public override void OnReceive(Context context, Intent intent)
			{
				string action = intent.Action;
				if (action.Equals(ACTION_SET_GCM_TOKEN))
				{
					string gcmToken = intent.GetStringExtra(KEY_GCM_TOKEN);
					Log.i(TAG, "GCM Token : " + gcmToken);
					outerInstance.gcmToken = gcmToken;
					if (gcmToken == null)
					{
						Snackbar.Make(outerInstance.coordinatorLayout, "Failed to get GCM Token. Unable to receive calls", Snackbar.LENGTH_LONG).show();
					}
					outerInstance.RetrieveAccessToken();
				}
				else if (action.Equals(ACTION_INCOMING_CALL))
				{
					/*
					 * Remove the notification from the notification drawer
					 */
					outerInstance.notificationManager.Cancel(intent.GetIntExtra(VoiceActivity.INCOMING_CALL_NOTIFICATION_ID, 0));
					/*
					 * Handle the incoming call message
					 */
					VoiceClient.handleIncomingCallMessage(ApplicationContext, (IncomingCallMessage)intent.getParcelableExtra(INCOMING_CALL_MESSAGE), outerInstance.incomingCallMessageListener_Renamed);
				}
			}
		}

		private DialogInterface.OnClickListener AnswerCallClickListener()
		{
			return new OnClickListenerAnonymousInnerClassHelper(this);
		}

		private class OnClickListenerAnonymousInnerClassHelper : DialogInterface.OnClickListener
		{
			private readonly VoiceActivity outerInstance;

			public OnClickListenerAnonymousInnerClassHelper(VoiceActivity outerInstance)
			{
				this.outerInstance = outerInstance;
			}


			public override void OnClick(DialogInterface dialog, int which)
			{
				outerInstance.answer();
				outerInstance.setCallUI();
				outerInstance.alertDialog.dismiss();
			}
		}

		private DialogInterface.OnClickListener cancelCallClickListener()
		{
			return new CancelCallOnClickListenerAnonymousInnerClassHelper(this);
		}

		private class CancelCallOnClickListenerAnonymousInnerClassHelper : DialogInterface.OnClickListener
		{
			private readonly VoiceActivity outerInstance;

			public CancelCallOnClickListenerAnonymousInnerClassHelper(VoiceActivity outerInstance)
			{
				this.outerInstance = outerInstance;
			}


			public override void OnClick(DialogInterface dialogInterface, int i)
			{
				outerInstance.activeIncomingCall.reject();
				outerInstance.alertDialog.dismiss();
			}
		}

		public static AlertDialog CreateIncomingCallDialog(Context context, IncomingCall incomingCall, DialogInterface.OnClickListener answerCallClickListener, DialogInterface.OnClickListener cancelClickListener)
		{
			AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(context);
			alertDialogBuilder.Icon = Resource.Drawable.ic_call_black_24dp;
			alertDialogBuilder.Title = "Incoming Call";
			alertDialogBuilder.setPositiveButton("Accept", answerCallClickListener);
			alertDialogBuilder.setNegativeButton("Reject", cancelClickListener);
			alertDialogBuilder.Message = incomingCall.From + " is calling.";
			return alertDialogBuilder.create();
		}

		/*
		 * Register your GCM token with Twilio to enable receiving incoming calls via GCM
		 */
		private void Register()
		{
			VoiceClient.register(ApplicationContext, accessToken, gcmToken, registrationListener_Renamed);
		}

		private View.OnClickListener CallActionFabClickListener()
		{
			return new CallOnClickListenerAnonymousInnerClassHelper(this);
		}

		private class CallOnClickListenerAnonymousInnerClassHelper : View.OnClickListener
		{
			private readonly VoiceActivity outerInstance;

			public CallOnClickListenerAnonymousInnerClassHelper(VoiceActivity outerInstance)
			{
				this.outerInstance = outerInstance;
			}

			public override void OnClick(View v)
			{
				outerInstance.activeOutgoingCall = VoiceClient.Call(ApplicationContext, outerInstance.accessToken, outerInstance.twiMLParams, outerInstance.outgoingCallListener_Renamed);
				outerInstance.SetCallUI();
			}
		}

		private View.OnClickListener HangupActionFabClickListener()
		{
			return new HangupOnClickListenerAnonymousInnerClassHelper(this);
		}

		private class HangupOnClickListenerAnonymousInnerClassHelper : View.OnClickListener
		{
			private readonly VoiceActivity outerInstance;

			public HangupOnClickListenerAnonymousInnerClassHelper(VoiceActivity outerInstance)
			{
				this.outerInstance = outerInstance;
			}

			public override void OnClick(View v)
			{
				outerInstance.ResetUI();
				outerInstance.Disconnect();
			}
		}

		private View.OnClickListener SpeakerphoneActionFabClickListener()
		{
			return new SpeakerphoneOnClickListenerAnonymousInnerClassHelper(this);
		}

		private class SpeakerphoneOnClickListenerAnonymousInnerClassHelper : View.OnClickListener
		{
			private readonly VoiceActivity outerInstance;

			public SpeakerphoneOnClickListenerAnonymousInnerClassHelper(VoiceActivity outerInstance)
			{
				this.outerInstance = outerInstance;
			}

			public override void OnClick(View v)
			{
				outerInstance.ToggleSpeakerPhone();
			}
		}

		/*
		 * Accept an incoming Call
		 */
		private void Answer()
		{
			activeIncomingCall.accept(incomingCallListener_Renamed);
		}

		/*
		 * Disconnect an active Call
		 */
		private void Disconnect()
		{
			if (activeOutgoingCall != null)
			{
				activeOutgoingCall.disconnect();
				activeOutgoingCall = null;
			}
			else if (activeIncomingCall != null)
			{
				activeIncomingCall.reject();
				activeIncomingCall = null;
			}
		}

		/*
		 * Get an access token from your Twilio access token server
		 */
		private void RetrieveAccessToken()
		{
			Ion.with(ApplicationContext).load(ACCESS_TOKEN_SERVICE_URL).asString().Callback = new FutureCallbackAnonymousInnerClassHelper(this);
		}

		private class FutureCallbackAnonymousInnerClassHelper : FutureCallback<string>
		{
			private readonly VoiceActivity outerInstance;

			public FutureCallbackAnonymousInnerClassHelper(VoiceActivity outerInstance)
			{
				this.outerInstance = outerInstance;
			}

			public override void OnCompleted(Exception e, string accessToken)
			{
				if (e == null)
				{
					Log.d(TAG, "Access token: " + accessToken);
					outerInstance.accessToken = accessToken;
					outerInstance.callActionFab.show();
					if (outerInstance.gcmToken != null)
					{
						outerInstance.Register();
					}
				}
				else
				{
					Snackbar.Make(outerInstance.coordinatorLayout, "Error retrieving access token. Unable to make calls", Snackbar.LENGTH_LONG).show();
				}
			}
		}

		private void ToggleSpeakerPhone()
		{
			speakerPhone = !speakerPhone;

			AudioFocus = speakerPhone;
			audioManager.SpeakerphoneOn = speakerPhone;

			if (speakerPhone)
			{
				speakerActionFab.ImageDrawable = ContextCompat.GetDrawable(/*VoiceActivity.*/this, Resource.Drawable.ic_volume_mute_white_24px);
			}
			else
			{
				speakerActionFab.ImageDrawable = ContextCompat.GetDrawable(/*VoiceActivity.*/this, Resource.Drawable.ic_volume_down_white_24px);
			}
		}

		private bool AudioFocus
		{
			set
			{
				if (audioManager != null)
				{
					if (value)
					{
						savedAudioMode = audioManager.Mode;
						// Request audio focus before making any device switch.
						audioManager.RequestAudioFocus(null, AudioManager.STREAM_VOICE_CALL, AudioManager.AUDIOFOCUS_GAIN_TRANSIENT);
    
						/*
						 * Start by setting MODE_IN_COMMUNICATION as default audio mode. It is
						 * required to be in this mode when playout and/or recording starts for
						 * best possible VoIP performance. Some devices have difficulties with speaker mode
						 * if this is not set.
						 */
						audioManager.Mode = AudioManager.MODE_IN_COMMUNICATION;
					}
					else
					{
						audioManager.Mode = savedAudioMode;
						audioManager.AbandonAudioFocus(null);
					}
				}
			}
		}

		private bool CheckPermissionForMicrophone()
		{
			int resultMic = ContextCompat.CheckSelfPermission(this, Manifest.permission.RECORD_AUDIO);
			if (resultMic == PackageManager.PERMISSION_GRANTED)
			{
				return true;
			}
			return false;
		}

		private void RequestPermissionForMicrophone()
		{
			if (ActivityCompat.ShouldShowRequestPermissionRationale(this, Manifest.permission.RECORD_AUDIO))
			{
				Snackbar.Make(coordinatorLayout, "Microphone permissions needed. Please allow in your application settings.", Snackbar.LENGTH_LONG).show();
			}
			else
			{
				ActivityCompat.RequestPermissions(this, new string[]{Manifest.permission.RECORD_AUDIO}, MIC_PERMISSION_REQUEST_CODE);
			}
		}

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Override public void onRequestPermissionsResult(int requestCode, @NonNull String[] permissions, @NonNull int[] grantResults)
		public override void OnRequestPermissionsResult(int requestCode, string[] permissions, int[] grantResults)
		{
			/*
			 * Check if microphone permissions is granted
			 */
			if (requestCode == MIC_PERMISSION_REQUEST_CODE && permissions.Length > 0)
			{
				bool granted = true;
				if (granted)
				{
					StartGCMRegistration();
				}
				else
				{
					Snackbar.Make(coordinatorLayout, "Microphone permissions needed. Please allow in your application settings.", Snackbar.LENGTH_LONG).show();
				}
			}
		}

		/// <summary>
		/// Check the device to make sure it has the Google Play Services APK. If
		/// it doesn't, display a dialog that allows users to download the APK from
		/// the Google Play Store or enable it in the device's system settings.
		/// </summary>
		private bool CheckPlayServices()
		{
			GoogleApiAvailability apiAvailability = GoogleApiAvailability.Instance;
			int resultCode = apiAvailability.IsGooglePlayServicesAvailable(this);
			if (resultCode != ConnectionResult.SUCCESS)
			{
				if (apiAvailability.IsUserResolvableError(resultCode))
				{
					apiAvailability.GetErrorDialog(this, resultCode, PLAY_SERVICES_RESOLUTION_REQUEST).show();
				}
				else
				{
					Log.e(TAG, "This device is not supported.");
					Finish();
				}
				return false;
			}
			return true;
		}
	}

}