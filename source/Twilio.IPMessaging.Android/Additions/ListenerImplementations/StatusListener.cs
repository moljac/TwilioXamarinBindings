using System;
namespace Twilio.IPMessaging
{
    public partial class StatusListener : ConstantsStatusListener
    {
        public Action ErrorHandler { get; set; }
        public Action SuccessHandler { get; set; }

        public override void OnError (IErrorInfo errInfo)
        {
            ErrorHandler?.Invoke ();
        }

        public override void OnSuccess ()
        {
            SuccessHandler?.Invoke ();
        }
    }
}
