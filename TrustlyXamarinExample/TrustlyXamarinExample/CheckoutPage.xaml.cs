using System;
using System.Collections.Generic;
using Xamarin.Forms;
using TrustlyXamarinExample.Trustly;
using Xamarin.Essentials;

namespace TrustlyXamarinExample
{
    public partial class CheckoutPage : ContentPage
    {
        public CheckoutPage(String trustlyCheckoutUrlString)
        {
            InitializeComponent();

            webView.Source = trustlyCheckoutUrlString;
            //Un-comment the line below if you want to handle the Checkout Events in the method 'OnTrustlyEvent' below.
            //webView.onTrustlyEvent += OnTrustlyEvent;
        }

        void OnTrustlyEvent(object source, TrustlyCheckoutEventArgs eventArgs)
        {
            switch (eventArgs.eventType)
            {
                case TrustlyEventType.OnTrustlyCheckoutAbort:
                    Navigation.PopModalAsync();
                    break;
                case TrustlyEventType.OnTrustlyCheckoutError:
                    //Called when an error occured within the Checkout.
                    break;
                case TrustlyEventType.OnTrustlyCheckoutRedirect:
                    //The Checkout wants to redirect
                    Uri trustlyEventUri = new Uri(eventArgs.url, UriKind.Absolute);
                    Launcher.OpenAsync(trustlyEventUri);
                    break;
                case TrustlyEventType.OnTrustlyCheckoutSuccess:
                    //Checkout completed
                    Navigation.PopModalAsync();
                    break;
                default: return;
            }

        }
    }
}
