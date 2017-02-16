using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Foundation;
using UIKit;
using Twilio.Common;
using Twilio.IPMessaging;

namespace TwilioIPMessagingSampleiOS
{
	public partial class ViewController : UIViewController, IUITextFieldDelegate
	{
		// Token coming from sample PHP token generator.
#if DEBUG
		private const string TokenUrl = @"http://localhost:8000/token.php?device={0}";
#else
        private const string TokenUrl = @"http://localhost:8000/token.php?device={0}";
#endif
		// Configure access token manually for testing in `ViewDidLoad` if desired! 
		// You can create one manually in the Twilio Console.
		private IPMToken accessToken;

		// Twilio Common Access Manager Delegate
		AccessManagerDelegate accessManagerDelegate;
		// IPMessaging Delegate
		IPMessagingDelegate ipmMessaginingDelegate;
		// Channel Delegate
		IPMChannelDelegate ipmChannelDelegate;
		MessagesDataSource dataSource;
		TwilioIPMessagingClient client;
		Channel generalChannel;

		public ViewController(IntPtr handle) 
			: base(handle)
		{
		}

		public async override void ViewDidLoad()
		{
			base.ViewDidLoad();

			// Perform any additional setup after loading the view, typically from a nib.
			accessManagerDelegate = new AccessManagerDelegate();
			ipmMessaginingDelegate = new IPMessagingDelegate();
			ipmChannelDelegate = new IPMChannelDelegate();

			// Should dispose of these.
			ipmMessaginingDelegate.OnMessageAdded += HandleOnMessageAdded;
			ipmMessaginingDelegate.OnChannelExist += HandleOnChannelExist;
			ipmMessaginingDelegate.OnChannelDoesNotExist += HandleOnChannelDoesNotExist;

			dataSource = new MessagesDataSource();
			tableView.Source = dataSource;
			tableView.RowHeight = UITableView.AutomaticDimension;
			tableView.EstimatedRowHeight = 70;

			var ipmToken = await GetToken();
			this.NavigationItem.Prompt = $"Logged in as {ipmToken.identity}";
			var accessManager = TwilioAccessManager.AccessManagerWithToken(ipmToken.token, accessManagerDelegate);
			client = TwilioIPMessagingClient.IpMessagingClientWithAccessManager(accessManager, new TwilioIPMessagingClientProperties(), ipmMessaginingDelegate);

			// Look at IPMessaginingDelegate 

			NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillShowNotification, KeyboardWillShow);
			NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.DidShowNotification, KeyboardDidShow);
			NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillHideNotification, KeyboardWillHide);

			this.View.AddGestureRecognizer(new UITapGestureRecognizer(() =>
			{
				this.messageTextField.ResignFirstResponder();
			}));

			this.messageTextField.Delegate = this;
		}

		private async Task<IPMToken> GetToken()
		{
			var deviceId = UIDevice.CurrentDevice.IdentifierForVendor.AsString();
			var token = await Utils.GetTokenAsync(TokenUrl, deviceId);
			return token;
		}

		partial void ButtonSend_TouchUpInside(UIButton sender)
		{
			var msg = generalChannel.Messages.CreateMessageWithBody(messageTextField.Text);
			sendButton.Enabled = false;
			generalChannel.Messages.SendMessage(msg, r =>
			{

				BeginInvokeOnMainThread(() =>
				{
					messageTextField.Text = string.Empty;
					sendButton.Enabled = true;
				});

			});
		}

		public void ScrollToBottomMessage()
		{
			if (dataSource.Messages.Count == 0)
			{
				return;
			}

			var bottomIndexPath = NSIndexPath.FromRowSection(this.tableView.NumberOfRowsInSection(0) - 1, 0);
			this.tableView.ScrollToRow(bottomIndexPath, UITableViewScrollPosition.Bottom, true);
		}

		[Export("textFieldShouldReturn:")]
		public bool ShouldReturn(UITextField textField)
		{
			var message = generalChannel.Messages.CreateMessageWithBody(textField.Text);
			generalChannel.Messages.SendMessage(message, (r) =>
			{
				textField.Text = "";
			});

			return true;
		}

		#region IP Messagining Delegate Handlers
		private void HandleOnMessageAdded(Message message)
		{
			dataSource.AddMessage(message);
			tableView.ReloadData();

			if (dataSource.Messages.Count > 0)
			{
				ScrollToBottomMessage();
			}
		}

		private void LoadChannelHistory()
		{
			var msgs = generalChannel.Messages?.AllObjects?.OrderBy(m => m.Timestamp);
			if (msgs != null)
			{
				dataSource.UpdateMessages(msgs);
				tableView.ReloadData();
				ScrollToBottomMessage();
			}
		}

		private void HandleOnChannelExist(Channel channel)
		{
			generalChannel = channel;
			generalChannel.JoinWithCompletion(c =>
			{
				Console.WriteLine("Successfully joined general channel!");
				LoadChannelHistory();
			});
		}

		private void HandleOnChannelDoesNotExist(Channels channels)
		{
			var options = new NSDictionary("TWMChannelOptionFriendlyName", "General Chat Channel", "TWMChannelOptionType", 0, "TWMChannelOptionUniqueName", "general");
			channels.CreateChannelWithOptions(options, (result, channel) =>
			{
				if (result.IsSuccessful)
				{
					generalChannel = channel;
					generalChannel.JoinWithCompletion(c =>
					{
						Console.WriteLine("Created and Joined General Channel!");
					});
				}
			});
		}
		#endregion

		#region Keyboard Management
		private void KeyboardWillShow(NSNotification notification)
		{
			var keyboardHeight = ((NSValue)notification.UserInfo.ValueForKey(UIKeyboard.FrameBeginUserInfoKey)).RectangleFValue.Height;
			UIView.Animate(0.1, () =>
			{
				this.messageTextFieldBottomConstraint.Constant = keyboardHeight + 8;
				this.sendButtonBottomConstraint.Constant = keyboardHeight + 8;
				this.View.LayoutIfNeeded();
			});
		}

		private void KeyboardDidShow(NSNotification notification)
		{
			this.ScrollToBottomMessage();
		}

		private void KeyboardWillHide(NSNotification notification)
		{
			UIView.Animate(0.1, () =>
			{
				this.messageTextFieldBottomConstraint.Constant = 8;
				this.sendButtonBottomConstraint.Constant = 8;
			});
		}
		#endregion
	}

	class MessagesDataSource : UITableViewSource
	{
		public void UpdateMessages(IEnumerable<Message> messages)
		{
			Messages.Clear();
			Messages.AddRange(messages);
		}

		public void AddMessage(Message msg)
		{
			Messages.Add(msg);
		}

		public List<Message> Messages { get; private set; } = new List<Message>();

		public override nint NumberOfSections(UITableView tableView)
		{
			return 1;
		}

		public override nint RowsInSection(UITableView tableView, nint section)
		{
			return Messages.Count;
		}

		public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			var message = Messages[indexPath.Row];

			var cell = tableView.DequeueReusableCell("MessageCell") as MessageCell;
			cell.Message = message;
			cell.SetNeedsUpdateConstraints();
			cell.UpdateConstraintsIfNeeded();

			return cell;
		}
	}
}