using System;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace TrustlyXamarinExample.Trustly
{
    public class TrustlyWebView: WebView
    {
        public event EventHandler<TrustlyCheckoutEventArgs> onTrustlyEvent;

        public TrustlyWebView()
        {
        }

        public void PostCheckoutEvent(TrustlyCheckoutEventArgs trustlyEvent)
        {

            if (onTrustlyEvent != null)
            {
                onTrustlyEvent(this, trustlyEvent);
            }
            else
            {
                if (trustlyEvent.eventType == TrustlyEventType.OnTrustlyCheckoutRedirect)
                {
                    Uri trustlyEventUri = new Uri(trustlyEvent.url, UriKind.Absolute);
                    Launcher.OpenAsync(trustlyEventUri);
                }

            }
        }
    }
}
