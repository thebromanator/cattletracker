using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace cattletracker_app
{
    public partial class MyHerdPage : TabbedPage
    {
        public MyHerdPage()
        {
            this.Title = "MyHerd";
            this.Children.Add(new ContentPage
            {
                Title = "Cows",
                Content = new ListView
                {
                    ItemsSource = new List<string>
                    {
                        "Honey", "Scarlet", "Chloe"
                    }
                }
            }
            );
            this.Children.Add(new ContentPage
            {
                Title = "Calves",
                Content = new ListView
                {
                    ItemsSource = new List<string>
                    {
                        "#18", "#29", "#34"
                    }
                }
            });
        }
    }
}
