using System;
using Foundation;
using Twilio.Video;

namespace TwilioRoomsSampleiOS
{
	public class VideoRoomDelegate : RoomDelegate
	{
		public Action<string, Room> OnDidConnectToRoom;
		public Action<string> OnDisconnectedWithError;
		public Action<string> OnRoomFailedToConnect;
		public Action<string, Participant> OnParticipantDidConnect;
		public Action<string, Participant> OnParticipantDisconnected;

		[Export("didConnectToRoom:")]
		public override void DidConnectToRoom(Room room)
		{
			// At the moment, this example only supports rendering one Participant at a time.
			var message = $"Connected to room {room.Name} as {room.LocalParticipant.Identity}.";
			OnDidConnectToRoom?.Invoke(message, room);
		}

		[Export("room:didDisconnectWithError:")]
		public override void DisconnectedWithError(Room room, NSError error)
		{
			var message = $"Disconnected from room {room.Name} with error: {error}";
			OnDisconnectedWithError?.Invoke(message);
		}

		[Export("room:didFailToConnectWithError:")]
		public override void FailedToConnect(Room room, NSError error)
		{
			var message = $"Failed to connect to room with error: {error}";
			OnRoomFailedToConnect?.Invoke(message);
		}

		[Export("room:participantDidConnect:")]
		public override void ParticipantDidConnect(Room room, Participant participant)
		{
			var message = $"Room {room.Name} participant {participant.Identity} connected.";
			OnParticipantDidConnect?.Invoke(message, participant);
		}

		[Export("room:participantDidDisconnect:")]
		public override void ParticipantDisconnected(Room room, Participant participant)
		{
			var message = $"Room {room.Name} participant {participant.Identity} disconnected.";
			OnParticipantDidConnect?.Invoke(message, participant);
		}
	}
}