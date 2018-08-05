using XFIntro.Model;

namespace XFIntro.ViewModel
{
    public class ContactDetailViewModel : BaseViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ContactDetailViewModel(Contact contact)
        {
            FirstName = contact.FirstName;
            LastName = contact.LastName;
        }
    }
}
