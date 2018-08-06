using System;
using System.ComponentModel;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName(XFIntro.Effect.FocusBackgroundColorEffect.FocusBackgroundColorEffectGroupName)]
[assembly: ExportEffect(typeof(XFIntro.iOS.Effect.FocusBackgroundColorEffect), XFIntro.Effect.FocusBackgroundColorEffect.FocusBackgroundColorEffectName)]
namespace XFIntro.iOS.Effect
{
    public class FocusBackgroundColorEffect : PlatformEffect
    {
        readonly UIColor focusedBackgroundColor = UIColor.Blue;

        Color originalColor;

        protected override void OnAttached()
        {
            // Ensure background color can be whatever it is set in xaml
            originalColor = (Element as VisualElement).BackgroundColor;
        }

        protected override void OnDetached()
        {
            // We don't have to do any cleanup here
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);

            if (args.PropertyName == VisualElement.IsFocusedProperty.PropertyName)
            {
                if ((Element as VisualElement).IsFocused)
                    Control.BackgroundColor = focusedBackgroundColor;
                else
                    Control.BackgroundColor = originalColor.ToUIColor();
            }
        }
    }
}
