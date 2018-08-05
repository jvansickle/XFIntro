using System.Collections.Generic;
using Xamarin.Forms;

namespace XFIntro
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            TheListView.ItemsSource = new List<string>
            {
                "Contact 1",
                "Contact 2",
                "Contact 3"
            };
        }
    }
}
