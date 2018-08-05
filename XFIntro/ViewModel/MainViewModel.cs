using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using XFIntro.Model;
using XFIntro.Service;

namespace XFIntro.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<Contact> Contacts { get; set; }

        bool _isRefreshing;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { _isRefreshing = value; NotifyPropertyChanged(); }
        }

        public ICommand RefreshContacts => new Command(LoadContacts);

        public MainViewModel()
        {
            Contacts = new ObservableCollection<Contact>();
        }

        public void LoadContacts()
        {
            IsRefreshing = true;

            Contacts.Clear();

            ContactService.Instance.GetContacts().ForEach((contact) =>
            {
                Contacts.Add(contact);
            });

            IsRefreshing = false;
        }
    }
}
