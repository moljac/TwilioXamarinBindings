using Android.App;
using Android.Widget;
using Android.OS;
using Android.Runtime;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Android.Content;

using Twilio.Common;
using Twilio.IPMessaging;

namespace TwilioIPMessagingSample
{
	[Activity(Label = "#general", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity, IPMessagingClientListener, IChannelListener, IAccessManagerListener
	{
		internal const string TAG = "TWILIO";

		Button sendButton;
		EditText textMessage;
		ListView listView;
		MessagesAdapter adapter;

		IPMessagingClient client;
		Channel generalChannel;

		protected async override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			this.ActionBar.Subtitle = "logging in...";

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			sendButton = FindViewById<Button>(Resource.Id.sendButton);
			textMessage = FindViewById<EditText>(Resource.Id.messageTextField);
			listView = FindViewById<ListView>(Resource.Id.listView);

			adapter = new MessagesAdapter(this);
			listView.Adapter = adapter;

			TwilioIPMessagingSDK.SetLogLevel((int)Android.Util.LogPriority.Debug);

			if (!TwilioIPMessagingSDK.IsInitialized)
			{
				Console.WriteLine("Initialize");

				TwilioIPMessagingSDK.InitializeSDK(this, new InitListener
				{
					InitializedHandler = async delegate
					{
						await Setup();
					},
					ErrorHandler = err =>
					{
						Console.WriteLine(err.Message);
					}
				});
			}
			else {
				await Setup();
			}

			sendButton.Click += ButtonSend_Click;
		}

		async Task Setup()
		{
			var token = await GetIdentity();
			var accessManager = TwilioAccessManagerFactory.CreateAccessManager(token, this);
			client = TwilioIPMessagingSDK.CreateIPMessagingClientWithAccessManager(accessManager, this);

			client.Channels.LoadChannelsWithListener(new StatusListener
			{
				SuccessHandler = () =>
				{
					generalChannel = client.Channels.GetChannelByUniqueName("general");

					if (generalChannel != null)
					{
						generalChannel.Listener = this;
						JoinGeneralChannel();
					}
					else
					{
						CreateAndJoinGeneralChannel();
					}
				}
			});
		}

		void JoinGeneralChannel()
		{
			generalChannel.Join(new StatusListener
			{
				SuccessHandler = () =>
				{
					RunOnUiThread(() =>
					   Toast.MakeText(this, "Joined general channel!", ToastLength.Short).Show());
				}
			});
		}

		void CreateAndJoinGeneralChannel()
		{
			var options = new Dictionary<string, Java.Lang.Object>();
			options["friendlyName"] = "General Chat Channel";
			options["ChannelType"] = ChannelChannelType.ChannelTypePublic;
			client.Channels.CreateChannel(options, new CreateChannelListener
			{
				OnCreatedHandler = channel =>
				{
					generalChannel = channel;
					channel.SetUniqueName("general", new StatusListener
					{
						SuccessHandler = () => { Console.WriteLine("set unique name successfully!"); }
					});
					this.JoinGeneralChannel();
				},
				OnErrorHandler = () => { }
			});
		}

		void ButtonSend_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(textMessage.Text))
			{
				var msg = generalChannel.Messages.CreateMessage(textMessage.Text);

				generalChannel.Messages.SendMessage(msg, new StatusListener
				{
					SuccessHandler = () =>
					{
						RunOnUiThread(() =>
						{
							textMessage.Text = string.Empty;
						});
					}
				});
			}
		}

		async Task<string> GetIdentity()
		{
			var androidId = Android.Provider.Settings.Secure.GetString(ContentResolver,
								Android.Provider.Settings.Secure.AndroidId);

			var tokenEndpoint = $"https://twilio.redth.info/token.php?device={androidId}";

			var http = new HttpClient();
			var data = await http.GetStringAsync(tokenEndpoint);

			var json = System.Json.JsonObject.Parse(data);

			var identity = json["identity"]?.ToString()?.Trim('"');
			this.ActionBar.Subtitle = $"Logged in as {identity}";
			var token = json["token"]?.ToString()?.Trim('"');

			return token;
		}


		public void OnAttributesChange(string attr)
		{

		}
		public void OnChannelAdd(Channel channel)
		{

		}
		public void OnChannelChange(Channel channel)
		{
			//Android.Util.Log.Debug (TAG, "Channel Changed");
			//adapter.UpdateMessages (channel.Messages.GetMessages ());
		}
		public void OnChannelDelete(Channel channel)
		{
		}
		public void OnChannelHistoryLoaded(Channel channel)
		{
			Android.Util.Log.Debug(TAG, "Channel History Loaded");
			adapter.UpdateMessages(channel.Messages.GetMessages());
			listView.SmoothScrollToPosition(adapter.Count - 1);
		}
		public void OnError(ErrorInfo errorInfo)
		{
			Console.WriteLine($"Error: {errorInfo.ErrorCode} -> {errorInfo.ErrorText}");
		}

		public void OnUserInfoChange(UserInfo userInfo)
		{
			Console.WriteLine($"UserInfoChanged: {userInfo.Identity} -> {userInfo.FriendlyName}");
		}

		public void OnAttributesChange(IDictionary<string, string> attrs)
		{
		}

		public void OnMemberChange(Member member)
		{
			Android.Util.Log.Debug(TAG, $"Member Changed: {member.Sid}");
		}

		public void OnMemberDelete(Member member)
		{
		}

		public void OnMemberJoin(Member member)
		{
			Android.Util.Log.Debug(TAG, $"Member Joined: {member.Sid}");
		}

		public void OnMessageAdd(Twilio.IPMessaging.Message message)
		{
			adapter.AddMessage(message);
			listView.SmoothScrollToPosition(adapter.Count - 1);
		}

		public void OnMessageChange(Twilio.IPMessaging.Message message)
		{
			Android.Util.Log.Debug(TAG, "Message Changed");
		}

		public void OnMessageDelete(Twilio.IPMessaging.Message message)
		{
			Android.Util.Log.Debug(TAG, "Message Deleted");
		}

		public void OnTypingEnded(Member member)
		{
			Android.Util.Log.Debug(TAG, $"Typing Ended for {member.Sid}");
		}

		public void OnTypingStarted(Member member)
		{
			Android.Util.Log.Debug(TAG, $"Typing Started for {member.Sid}");
		}

		public void OnError(AccessManager p0, string p1)
		{
			Console.WriteLine("error in access manager");
		}

		public void OnTokenExpired(AccessManager p0)
		{
			Console.WriteLine("token expired");
		}

		public void OnTokenUpdated(AccessManager p0)
		{
			Console.WriteLine("token updated");
		}
	}

	class MessagesAdapter : BaseAdapter<Twilio.IPMessaging.Message>
	{
		public MessagesAdapter(Activity parentActivity)
		{
			activity = parentActivity;
		}

		List<IMessage> messages = new List<Twilio.IPMessaging.Message>();
		Activity activity;

		public void UpdateMessages(IEnumerable<Twilio.IPMessaging.Message> msgs)
		{
			lock (messages)
			{
				messages.Clear();
				messages.AddRange(msgs.OrderBy(m => m.TimeStamp));
			}

			activity.RunOnUiThread(() =>
			   NotifyDataSetChanged());
		}

		public void AddMessage(Twilio.IPMessaging.Message msg)
		{
			lock (messages)
			{
				messages.Add(msg);
			}

			activity.RunOnUiThread(() =>
			   NotifyDataSetChanged());
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override Android.Views.View GetView(int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
		{
			var view = convertView as LinearLayout ?? activity.LayoutInflater.Inflate(Resource.Layout.MessageItemLayout, null) as LinearLayout;
			var msg = messages[position];

			view.FindViewById<TextView>(Resource.Id.authorTextView).Text = msg.Author;
			view.FindViewById<TextView>(Resource.Id.messageTextView).Text = msg.MessageBody;

			return view;
		}

		public override int Count { get { return messages.Count; } }
		public override Twilio.IPMessaging.Message this[int index] { get { return messages[index]; } }
	}

	public class CreateChannelListener : ConstantsCreateChannelListener
	{
		public Action<Channel> OnCreatedHandler { get; set; }
		public Action OnErrorHandler { get; set; }

		public override void OnCreated(Channel channel)
		{
			OnCreatedHandler?.Invoke(channel);
		}

		public override void OnError(ErrorInfo errorInfo)
		{
			base.OnError(errorInfo);
		}
	}
}
