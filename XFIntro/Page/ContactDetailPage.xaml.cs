using Xamarin.Forms;
using XFIntro.Model;
using XFIntro.ViewModel;

namespace XFIntro.Page
{
    public partial class ContactDetailPage : ContentPage
    {
        public ContactDetailPage(Contact contact)
        {
            InitializeComponent();

            BindingContext = new ContactDetailViewModel(contact);
        }
    }
}
