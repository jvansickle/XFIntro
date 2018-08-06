using Xamarin.Forms;

namespace XFIntro.Behavior
{
    public static class NumericValidation
    {
        public static readonly BindableProperty AttachBehaviorProperty =
            BindableProperty.Create("AttachBehavior",
                                    typeof(bool),
                                    typeof(NumericValidation),
                                    false,
                                    propertyChanged: OnAttachBehaviorChanged);

        public static bool GetAttachBehavior(BindableObject view)
        {
            return (bool)view.GetValue(AttachBehaviorProperty);
        }

        public static void SetAttachBehavior(BindableObject view, bool value)
        {
            view.SetValue(AttachBehaviorProperty, value);
        }

        static void OnAttachBehaviorChanged(BindableObject view, object oldValue, object newValue)
        {
            var entry = view as Entry;
            if (entry == null)
                return;

            bool attachBehavior = (bool)newValue;
            if (attachBehavior)
                entry.TextChanged += OnEntryTextChanged;
            else
                entry.TextChanged -= OnEntryTextChanged;
        }

        static void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            bool isValid = double.TryParse(args.NewTextValue, out var result);
            (sender as Entry).BackgroundColor = isValid ? Color.Default : Color.Red;
        }
    }
}
