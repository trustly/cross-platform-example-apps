using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TrustlyXamarinExample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        void onCheckoutButtonClicked(System.Object sender, System.EventArgs e)
        {
            String trustlyCheckoutURLString = "https://test.trustly.com/demo/deposit?env=live&UseIntegrationSelector=1&apiuser=apitest_child";
            CheckoutPage checkoutPage = new CheckoutPage(trustlyCheckoutURLString);
            Navigation.PushModalAsync(checkoutPage);
        }
    }
}
