using Xamarin.Forms;
using XFIntro.Model;
using XFIntro.Page;
using XFIntro.ViewModel;

namespace XFIntro
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainViewModel();
        }

        void HandleItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            Navigation.PushAsync(new ContactDetailPage(args.SelectedItem as Contact));
        }
    }
}
