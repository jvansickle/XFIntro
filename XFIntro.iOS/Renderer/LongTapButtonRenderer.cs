using System;
using System.ComponentModel;
using System.Timers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XFIntro.Element;
using XFIntro.iOS.Renderer;

[assembly: ExportRenderer(typeof(LongTapButton), typeof(LongTapButtonRenderer))]
namespace XFIntro.iOS.Renderer
{
    public class LongTapButtonRenderer : ButtonRenderer
    {
        LongTapButton AElement => Element as LongTapButton;

        Timer timer = new Timer();
        bool timerElapsed;

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            if (e.NewElement != null)
            {
                if (Control == null)
                {
                    var uiButton = new UIButton(UIButtonType.System);

                    uiButton.TouchDown += UIButtonTouchDown;
                    uiButton.TouchUpInside += UIButtonTouchUpInside;
                    uiButton.TouchUpOutside += UIButtonTouchUpOutside;

                    SetNativeControl(uiButton);

                    timer = new Timer(AElement.DurationRequirement);
                    timer.Elapsed += OnTimerElapsed;
                }
            }

            base.OnElementChanged(e);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == Button.TextProperty.PropertyName)
                UpdateText();
            else if (e.PropertyName == LongTapButton.DurationRequirementProperty.PropertyName)
                UpdateDuration();
        }

        void UpdateText()
        {
            Control.SetTitle(Element.Text, UIControlState.Normal);
        }

        void UpdateDuration()
        {
            timer.Interval = AElement.DurationRequirement;
        }

        void UIButtonTouchDown(object sender, EventArgs args)
        {
            timerElapsed = false;
            timer.Start();
        }

        void UIButtonTouchUpInside(object sender, EventArgs args)
        {
            timer.Stop();

            if(timerElapsed)
                Element.Command?.Execute(Element.CommandParameter);
        }

        void UIButtonTouchUpOutside(object sender, EventArgs args)
        {
            timer.Stop();
            timerElapsed = false;
        }

        void OnTimerElapsed(object sender, ElapsedEventArgs args)
        {
            timerElapsed = true;
        }
    }
}
