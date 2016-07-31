using Microsoft.Phone.Tasks;
using cattletracker_app.WinPhone;
using Xamarin.Forms;

[assembly: Dependency(typeof(PhoneDialer))]

namespace cattletracker_app.WinPhone
{
    public class PhoneDialer : IDialer
    {
        public bool Dial(string number)
        {
            PhoneCallTask phoneCallTask = new PhoneCallTask
            {
                PhoneNumber = number,
                DisplayName = "cattletracker_app"
            };

            phoneCallTask.Show();
            return true;
        }
    }
}