using Foundation;

namespace Twilio.Voice
{
	[Static]
	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern double TwilioVoiceClientVersionNumber;
		[Field ("TwilioVoiceClientVersionNumber", "__Internal")]
		double TwilioVoiceClientVersionNumber { get; }

		// extern const unsigned char [] TwilioVoiceClientVersionString;
		[Field ("TwilioVoiceClientVersionString", "__Internal")]
		byte[] TwilioVoiceClientVersionString { get; }
	}
}
