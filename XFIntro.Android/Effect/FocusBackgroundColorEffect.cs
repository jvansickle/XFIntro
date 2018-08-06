using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName(XFIntro.Effect.FocusBackgroundColorEffect.FocusBackgroundColorEffectGroupName)]
[assembly: ExportEffect(typeof(XFIntro.Droid.Effect.FocusBackgroundColorEffect), XFIntro.Effect.FocusBackgroundColorEffect.FocusBackgroundColorEffectName)]
namespace XFIntro.Droid.Effect
{
    public class FocusBackgroundColorEffect : PlatformEffect
    {
        Color originalColor;

        protected override void OnAttached()
        {
            originalColor = (Element as VisualElement).BackgroundColor;
        }

        protected override void OnDetached()
        {
            // Nothing to cleanup here
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);

            if (args.PropertyName == VisualElement.IsFocusedProperty.PropertyName)
            {
                if ((Element as VisualElement).IsFocused)
                    Control.SetBackgroundColor(Android.Graphics.Color.BlueViolet);
                else
                    Control.SetBackgroundColor(originalColor.ToAndroid());
            }
        }
    }
}
