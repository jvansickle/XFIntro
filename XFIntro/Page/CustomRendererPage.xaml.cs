using Xamarin.Forms;
using XFIntro.ViewModel;

namespace XFIntro.Page
{
    public partial class CustomRendererPage : ContentPage
    {
        public CustomRendererPage()
        {
            InitializeComponent();

            var vm = new CustomRendererViewModel();
            vm.Elapsed += () => DisplayAlert("You held the button!", "Yay!", "Cancel");

            BindingContext = vm;
        }
    }
}
