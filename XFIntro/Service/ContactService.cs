using System.Collections.Generic;
using XFIntro.Model;

namespace XFIntro.Service
{
    public class ContactService
    {
        static ContactService _instance;
        public static ContactService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ContactService();
                }

                return _instance;
            }
        }

        public IEnumerable<Contact> GetContacts()
        {
            var contacts = new List<Contact>();

            for (int i = 0; i < 20; i++)
            {
                contacts.Add(new Contact { FirstName = "Contact", LastName = $"{i}" });
            }

            return contacts;
        }
    }
}
