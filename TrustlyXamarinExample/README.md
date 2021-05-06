# Trustly Xamarin Example
This repo contains an Xamarin Forms application that show an example implementation on how to render the Trustly Checkout and support all neccesary events, e.g. switching to different apps during the checkout.
 
This implementation creates a `TrustlyWebView` using [Custom Renderers](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/custom-renderer/) for Xamarins Forms WebView control to enable support for Checkout Events. 

See `CheckoutPage` for details on how you can opt-in and handle the different events.

## Use in your Xamarin solution
If you want to manually integration this implementation into your Xamarin Forms solution you can do so by:
1. Import the folder named 'Trustly' for each project in your solution (Forms, Android, iOS).
2. Use the TrustlyWebView to render your Trustly Checkout URL (see CheckoutPage for an example).
