using System;
using TrustlyXamarinExample.Droid;
using Android.Webkit;
using Xamarin.Forms.Platform.Android;

namespace TrustlyXamarinExample.Droid
{
    public class JavascriptWebViewClient : FormsWebViewClient
    {

        public JavascriptWebViewClient(TrustlyAndroidWebView renderer) : base(renderer)
        {
        }

        public override void OnPageFinished(WebView view, string url)
        {
            base.OnPageFinished(view, url);
            //view.EvaluateJavascript(, null);
        }
    }
}
