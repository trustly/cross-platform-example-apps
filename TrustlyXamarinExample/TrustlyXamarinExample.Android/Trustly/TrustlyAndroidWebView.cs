using System;
using Xamarin.Forms;
using TrustlyXamarinExample.Trustly;
using TrustlyXamarinExample.Droid;
using Xamarin.Forms.Platform.Android;
using Android.Content;


[assembly: ExportRenderer(typeof(TrustlyWebView), typeof(TrustlyAndroidWebView))]
namespace TrustlyXamarinExample.Droid
{
    public class TrustlyAndroidWebView : WebViewRenderer
    {
        Context _context;


        public TrustlyAndroidWebView(Context context) : base(context)
        {
            _context = context;
        }


        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                Control.RemoveJavascriptInterface("TrustlyAndroid");

            }
            if (e.NewElement != null)
            {
                Control.SetWebViewClient(new JavascriptWebViewClient(this));
                Control.AddJavascriptInterface(new TrustlyJavascriptInterface(this), "TrustlyAndroid");
                Control.Settings.JavaScriptCanOpenWindowsAutomatically = true;
                Control.Settings.DomStorageEnabled = true;
                Control.Settings.JavaScriptEnabled = true;
                Control.Settings.SetSupportMultipleWindows(true);
            }
        }


    }
}
