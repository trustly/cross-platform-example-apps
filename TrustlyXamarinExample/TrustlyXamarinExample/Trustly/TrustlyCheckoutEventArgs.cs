using System;
namespace TrustlyXamarinExample.Trustly
{
    public class TrustlyCheckoutEventArgs : EventArgs
    {
        public TrustlyEventType eventType { get; }
        public string url { get; }
        public string packageName { get; }

        public TrustlyCheckoutEventArgs(string eventType, string url, string packageName)
        {
            this.eventType = ParseTrustlyEventType(eventType);
            this.url = url;
            this.packageName = packageName;
        }

        private TrustlyEventType ParseTrustlyEventType(string type)
        {
            switch (type)
            {
                case "onTrustlyCheckoutSuccess":
                    return TrustlyEventType.OnTrustlyCheckoutSuccess;
                case "onTrustlyCheckoutRedirect":
                    return TrustlyEventType.OnTrustlyCheckoutRedirect;
                case "onTrustlyCheckoutAbort":
                    return TrustlyEventType.OnTrustlyCheckoutAbort;
                case "onTrustlyCheckoutError":
                    return TrustlyEventType.OnTrustlyCheckoutError;

            }


            return TrustlyEventType.OnTrustlyCheckoutAbort;
        }

    }


    public enum TrustlyEventType
    {
        OnTrustlyCheckoutSuccess,
        OnTrustlyCheckoutRedirect,
        OnTrustlyCheckoutAbort,
        OnTrustlyCheckoutError

    }
}
