using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace cattletracker_app
{
    public partial class MenuPage : MasterDetailPage
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void HomeBtn_OnClicked(object sender, EventArgs e)
        {
            Detail = new HomePage();
            IsPresented = false;
        }

        private void MyHerdBtn_OnClicked(object sender, EventArgs e)
        {
            Detail = new MyHerdPage();
            IsPresented = false;
        }

        private void ManagementBtn_OnClicked(object sender, EventArgs e)
        {
            Detail = new ManagementPage();
            IsPresented = false;
        }

        private void HealthBtn_OnClicked(object sender, EventArgs e)
        {
            Detail = new HealthPage();
            IsPresented = false;
        }

        private void SalesBtn_OnClicked(object sender, EventArgs e)
        {
            Detail = new SalesPage();
            IsPresented = false;
        }
    }
}
