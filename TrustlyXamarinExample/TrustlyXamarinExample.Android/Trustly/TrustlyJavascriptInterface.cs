using System;
using TrustlyXamarinExample.Trustly;
using Android.Webkit;
using Java.Interop;

namespace TrustlyXamarinExample.Droid
{
    public class TrustlyJavascriptInterface : Java.Lang.Object
    {
        public WeakReference<TrustlyAndroidWebView> hybridWebViewRenderer;


        public TrustlyJavascriptInterface(TrustlyAndroidWebView hybridRenderer)
        {
            hybridWebViewRenderer = new WeakReference<TrustlyAndroidWebView>(hybridRenderer);
        }


        [JavascriptInterface]
        [Export]
        public void handleTrustlyEvent(string type, string url, string packageName)
        {

            var trustlyEvent = new TrustlyCheckoutEventArgs(type, url, packageName);
            TrustlyAndroidWebView hybridRenderer;
            if (hybridWebViewRenderer != null && hybridWebViewRenderer.TryGetTarget(out hybridRenderer))
            {
                ((TrustlyWebView)hybridRenderer.Element).PostCheckoutEvent(trustlyEvent);
            }
        }

        [JavascriptInterface]
        [Export]
        public bool openURLScheme(string packageName, string url)
        {
            var trustlyEvent = new TrustlyCheckoutEventArgs("onTrustlyCheckoutRedirect", url, packageName);
            TrustlyAndroidWebView hybridRenderer;
            if (hybridWebViewRenderer != null && hybridWebViewRenderer.TryGetTarget(out hybridRenderer))
            {
                ((TrustlyWebView)hybridRenderer.Element).PostCheckoutEvent(trustlyEvent);
            }
            return true;
        }
    }
}
