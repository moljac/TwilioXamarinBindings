using System;
using Foundation;
using Twilio.Video;

namespace TwilioRoomsSampleiOS
{
	public class VideoRoomDelegate : RoomDelegate
	{
		public VideoRoomDelegate()
		{
		}

		[Export("didConnectToRoom:")]
		public override void DidConnectToRoom(Room room)
		{
			// At the moment, this example only supports rendering one Participant at a time.
		}

		[Export("room:didFailToConnectWithError:")]
		public override void RoomFailedToConnect(Room room, NSError error)
		{
		}

		[Export("room:didDisconnectWithError:")]
		public override void RoomDisconnected(Room room, NSError error)
		{
		}

		[Export("room:participantDidConnect:")]
		public override void Room(Room room, Participant participant)
		{
		}

		[Export("room:participantDidDisconnect:")]
		public override void RoomparticipantDisconnected(Room room, Participant participant)
		{
		}
	}
}