using System;
using Foundation;
using UIKit;
using Twilio.Video;

namespace TwilioRoomsSampleiOS
{
	public partial class ViewController : UIViewController
	{
		// Configure access token manually for testing in `ViewDidLoad`, if desired! Create one manually in the console.
		private string accessToken;
		private string tokenUrl;

		// Video SDK components
		private VideoClient client;

		public ViewController(IntPtr handle) 
			: base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		partial void connectButtonPressed(NSObject sender)
		{

		}

		partial void disconnectButtonPressed(NSObject sender)
		{

		}

		partial void micButtonPressed(NSObject sender)
		{

		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}