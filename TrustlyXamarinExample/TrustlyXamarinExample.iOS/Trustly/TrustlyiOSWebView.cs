using System;
using TrustlyXamarinExample.Trustly;
using TrustlyXamarinExample.iOS;
using Xamarin.Forms;
using WebKit;
using Xamarin.Forms.Platform.iOS;
using Foundation;

[assembly: ExportRenderer(typeof(TrustlyWebView), typeof(TrustlyiOSWebView))]
namespace TrustlyXamarinExample.iOS
{
    public class TrustlyiOSWebView : WkWebViewRenderer, IWKScriptMessageHandler
    {
        WKUserContentController userController;
        public TrustlyiOSWebView() : this(new WKWebViewConfiguration())
        {
        }

        public TrustlyiOSWebView(WKWebViewConfiguration config) : base(config)
        {
            userController = config.UserContentController;
            userController.AddScriptMessageHandler(this, "trustlySDKBridge");
        }

        public void DidReceiveScriptMessage(WKUserContentController userContentController, WKScriptMessage message)
        {
            var trustlyEventJson = GetParsedJSON(message.Body.Description as object);

            ((TrustlyWebView)Element).PostCheckoutEvent(new TrustlyCheckoutEventArgs(trustlyEventJson["type"].ToString(), trustlyEventJson["type"].ToString(), ""));
        }

        private NSDictionary GetParsedJSON(object obj)
        {
            try
            {
                var jsonString = obj.ToString();
                var jsonData = NSData.FromString(jsonString, NSStringEncoding.UTF8);
                var parsed = NSJsonSerialization.Deserialize(jsonData, NSJsonReadingOptions.FragmentsAllowed, out NSError error) as NSDictionary;
                return parsed;
            }
            catch { }
            return null;
        }
    }
}
