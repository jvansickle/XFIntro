using Xamarin.Forms;

namespace XFIntro.Element
{
    public class LongTapButton : Button
    {
        public static readonly BindableProperty DurationRequirementProperty =
            BindableProperty.Create(nameof(DurationRequirement),
                                    typeof(long),
                                    typeof(LongTapButton),
                                    default(long));
        public long DurationRequirement
        {
            get { return (long)GetValue(DurationRequirementProperty); }
            set { SetValue(DurationRequirementProperty, value); }
        }
    }
}
