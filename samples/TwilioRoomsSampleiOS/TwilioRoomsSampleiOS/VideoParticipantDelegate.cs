using System;
using Foundation;
using Twilio.Video;

namespace TwilioRoomsSampleiOS
{
	public class VideoParticipantDelegate : ParticipantDelegate
	{
		public VideoParticipantDelegate()
		{
		}

		[Export("participant:addedVideoTrack:")]
		public override void AddedVideoTrack(Participant participant, VideoTrack videoTrack)
		{
		}

		[Export("participant:removedVideoTrack:")]
		public override void RemovedVideoTrack(Participant participant, VideoTrack videoTrack)
		{
		}

		[Export("participant:addedAudioTrack:")]
		public override void AddedAudioTrack(Participant participant, AudioTrack audioTrack)
		{
		}

		[Export("participant:removedAudioTrack:")]
		public override void RemovedAudioTrack(Participant participant, AudioTrack audioTrack)
		{
		}

		[Export("participant:enabledTrack:")]
		public override void EnabledTrack(Participant participant, Track track)
		{
		}

		[Export("participant:disabledTrack:")]
		public override void DisabledTrack(Participant participant, Track track)
		{
		}
	}
}