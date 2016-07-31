using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace cattletracker_app
{
    public partial class HomePage : ContentPage
    {
        string translatedNumber;

        public HomePage()
        {
            InitializeComponent();
        }

        void OnTranslate(object sender, EventArgs e)
        {
            translatedNumber = Core.PhonewordTranslator.ToNumber(phoneNumberText.Text);
            if (!string.IsNullOrWhiteSpace(translatedNumber))
            {
                callButton.IsEnabled = true;
                callButton.Text = "Call " + translatedNumber;
            }
            else
            {
                callButton.IsEnabled = false;
                callButton.Text = "Call";
            }
        }

        async void OnCall(object sender, EventArgs e)
        {
            if (await this.DisplayAlert(
                    "Dial a Number",
                    "Would you like to call " + translatedNumber + "?",
                    "Yes",
                    "No"))
            {
                var dialer = DependencyService.Get<IDialer>();
                if (dialer != null)
                    App.PhoneNumbers.Add(translatedNumber);
                    callHistoryButton.IsEnabled = true;
                    dialer.Dial(translatedNumber);
            }
        }

        void OnCallHistory(object sender, EventArgs e)
        {
            // var mainPage = new MainPage();//this could be content page
            // var rootPage = new NavigationPage(mainPage);
            Navigation.PushModalAsync(new CallHistoryPage());
        }
    }
}