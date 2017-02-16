namespace com.twilio.video.quickstart.dialog
{

	using Context = Android.Content.Context;
	using DialogInterface = Android.Content.DialogInterface;
	using AlertDialog = Android.Support.V7.App.AlertDialog;
	using EditText = Android.Widget.EditText;

	public class Dialog
	{

		public static AlertDialog createConnectDialog(EditText participantEditText, DialogInterface.OnClickListener callParticipantsClickListener, DialogInterface.OnClickListener cancelClickListener, Context context)
		{
			AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(context);

			alertDialogBuilder.Icon = Resource.Drawable.ic_call_black_24dp;
			alertDialogBuilder.Title = "Connect to a room";
			alertDialogBuilder.setPositiveButton("Connect", callParticipantsClickListener);
			alertDialogBuilder.setNegativeButton("Cancel", cancelClickListener);
			alertDialogBuilder.Cancelable = false;

			setRoomNameFieldInDialog(participantEditText, alertDialogBuilder, context);

			return alertDialogBuilder.create();
		}

		private static void setRoomNameFieldInDialog(EditText roomNameEditText, AlertDialog.Builder alertDialogBuilder, Context context)
		{
			roomNameEditText.Hint = "room name";
			int horizontalPadding = context.Resources.getDimensionPixelOffset(R.dimen.activity_horizontal_margin);
			int verticalPadding = context.Resources.getDimensionPixelOffset(R.dimen.activity_vertical_margin);
			alertDialogBuilder.setView(roomNameEditText, horizontalPadding, verticalPadding, horizontalPadding, 0);
		}

	}

}