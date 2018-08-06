using Xamarin.Forms;

namespace XFIntro.Effect
{
    public class FocusBackgroundColorEffect : RoutingEffect
    {
        public const string FocusBackgroundColorEffectGroupName = "JohnVanSickle";
        public const string FocusBackgroundColorEffectName = "FocusBackgroundColorEffect";
        public static readonly string FocusBackgroundColorEffectId = $"{FocusBackgroundColorEffectGroupName}.{FocusBackgroundColorEffectName}";

        public FocusBackgroundColorEffect() : base(FocusBackgroundColorEffectId)
        {
        }
    }
}
