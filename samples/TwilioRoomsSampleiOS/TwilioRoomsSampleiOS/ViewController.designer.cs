// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace TwilioRoomsSampleiOS
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIButton connectButton { get; set; }

		[Outlet]
		UIKit.UIButton disconnectButton { get; set; }

		[Outlet]
		UIKit.UILabel messageLabel { get; set; }

		[Outlet]
		UIKit.UIButton micButton { get; set; }

		[Outlet]
		UIKit.UIView previewView { get; set; }

		[Outlet]
		UIKit.UIView remoteView { get; set; }

		[Outlet]
		UIKit.UILabel roomLabel { get; set; }

		[Outlet]
		UIKit.UIView roomLine { get; set; }

		[Outlet]
		UIKit.UITextField roomTextField { get; set; }

		[Action ("connectButtonPressed:")]
		partial void ConnectButtonPressed (Foundation.NSObject sender);

		[Action ("disconnectButtonPressed:")]
		partial void DisconnectButtonPressed (Foundation.NSObject sender);

		[Action ("micButtonPressed:")]
		partial void MicButtonPressed (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (remoteView != null) {
				remoteView.Dispose ();
				remoteView = null;
			}

			if (roomLabel != null) {
				roomLabel.Dispose ();
				roomLabel = null;
			}

			if (connectButton != null) {
				connectButton.Dispose ();
				connectButton = null;
			}

			if (roomTextField != null) {
				roomTextField.Dispose ();
				roomTextField = null;
			}

			if (roomLine != null) {
				roomLine.Dispose ();
				roomLine = null;
			}

			if (previewView != null) {
				previewView.Dispose ();
				previewView = null;
			}

			if (messageLabel != null) {
				messageLabel.Dispose ();
				messageLabel = null;
			}

			if (micButton != null) {
				micButton.Dispose ();
				micButton = null;
			}

			if (disconnectButton != null) {
				disconnectButton.Dispose ();
				disconnectButton = null;
			}
		}
	}
}
