using System.Windows.Input;
using Xamarin.Forms;
using XFPage = Xamarin.Forms.Page;

namespace XFIntro.Behavior
{
    public class TapWarningBehavior : Behavior<View>
    {
        public static readonly BindableProperty PageProperty =
            BindableProperty.Create(nameof(Page),
                                    typeof(XFPage),
                                    typeof(TapWarningBehavior));
        public XFPage Page
        {
            get { return (XFPage)GetValue(PageProperty); }
            set { SetValue(PageProperty, value); }
        }

        public static readonly BindableProperty MessageProperty =
            BindableProperty.Create(nameof(Message),
                                    typeof(string),
                                    typeof(TapWarningBehavior),
                                    "I said do not tap this..");
        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        protected override void OnAttachedTo(View bindable)
        {
            bindable.GestureRecognizers.Add(WarningGestureRecognizer);
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(View bindable)
        {
            base.OnDetachingFrom(bindable);
        }

        TapGestureRecognizer WarningGestureRecognizer => new TapGestureRecognizer
        {
            Command = WarnUser
        };

        ICommand WarnUser => new Command(() =>
        {
            Page?.DisplayAlert("Come on!", Message, "My bad!");
        });
    }
}
