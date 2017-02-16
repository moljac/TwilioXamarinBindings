using System;
using Foundation;
using Twilio.Video;

namespace TwilioRoomsSampleiOS
{
	public class VideoParticipantDelegate : ParticipantDelegate
	{
		public Action<string, Participant, VideoTrack> OnAddedVideoTrack;
		public Action<string, Participant, VideoTrack> OnRemovedVideoTrack;
		public Action<string> OnAddedAudioTrack;
		public Action<string> OnRemovedAudioTrack;
		public Action<string> OnEnabledTrack;
		public Action<string> OnDisabledTrack;

		[Export("participant:addedVideoTrack:")]
		public override void AddedVideoTrack(Participant participant, VideoTrack videoTrack)
		{
			var msg = $"Participant {participant.Identity} added video track.";
			OnAddedVideoTrack?.Invoke(msg, participant, videoTrack);
		}

		[Export("participant:removedVideoTrack:")]
		public override void RemovedVideoTrack(Participant participant, VideoTrack videoTrack)
		{
			var msg = $"Participant {participant.Identity} removed video track.";
			OnAddedVideoTrack?.Invoke(msg, participant, videoTrack);
		}

		[Export("participant:addedAudioTrack:")]
		public override void AddedAudioTrack(Participant participant, AudioTrack audioTrack)
		{
			var msg = $"Participant {participant.Identity} added audio track.";
			OnAddedAudioTrack?.Invoke(msg);
		}

		[Export("participant:removedAudioTrack:")]
		public override void RemovedAudioTrack(Participant participant, AudioTrack audioTrack)
		{
			var msg = $"Participant {participant.Identity} removed audio track.";
			OnRemovedAudioTrack?.Invoke(msg);
		}

		[Export("participant:enabledTrack:")]
		public override void EnabledTrack(Participant participant, Track track)
		{
			var type = track is AudioTrack ? "audio" : "video";
			var msg = $"Participant {participant.Identity} enabled {type} track.";
			OnEnabledTrack?.Invoke(msg);
		}

		[Export("participant:disabledTrack:")]
		public override void DisabledTrack(Participant participant, Track track)
		{
			var type = track is AudioTrack ? "audio" : "video";
			var msg = $"Participant {participant.Identity} disabled {type} track.";
			OnDisabledTrack?.Invoke(msg);
		}
	}
}