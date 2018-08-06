using System;
using System.Net.Mail;
using Xamarin.Forms;

namespace XFIntro.Behavior
{
    public class EmailValidation : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(bindable);
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            try
            {
#pragma warning disable RECS0026 // Possible unassigned object created by 'new'
                new MailAddress(args.NewTextValue);
#pragma warning restore RECS0026 // Possible unassigned object created by 'new'

                (sender as Entry).BackgroundColor = Color.Default;
            }
            catch (Exception)
            {
                (sender as Entry).BackgroundColor = Color.Red;
            }
        }
    }
}
