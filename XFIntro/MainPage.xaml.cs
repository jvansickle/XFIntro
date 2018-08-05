using Xamarin.Forms;
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
    }
}
