using System.ComponentModel;
using System.Timers;
using Android.Content;
using Android.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XFIntro.Droid.Renderer;
using XFIntro.Element;

[assembly: ExportRenderer(typeof(LongTapButton), typeof(LongTapButtonRenderer))]
namespace XFIntro.Droid.Renderer
{
    public class LongTapButtonRenderer : ButtonRenderer
    {
        LongTapButton AElement => Element as LongTapButton;
        bool timerElapsed;
        Timer timer;

        public LongTapButtonRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            if (e.NewElement != null)
            {
                if (Control == null)
                {
                    var button = new Android.Widget.Button(Context);

                    button.Touch += OnTouch;

                    SetNativeControl(button);

                    timer = new Timer(AElement.DurationRequirement);
                    timer.Elapsed += OnTimerElapsed;
                }
            }

            base.OnElementChanged(e);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == LongTapButton.DurationRequirementProperty.PropertyName)
            {
                UpdateDuration();
            }
        }

        void UpdateDuration()
        {
            timer.Interval = AElement.DurationRequirement;
        }

        void OnTouch(object sender, TouchEventArgs e)
        {
            if (e.Event.Action == MotionEventActions.Down)
            {
                timerElapsed = false;
                timer.Start();
            }
            else if (e.Event.Action == MotionEventActions.Up)
            {
                timer.Stop();

                if (timerElapsed)
                    Element.Command?.Execute(Element.CommandParameter);
            }
            else if (e.Event.Action == MotionEventActions.Outside)
            {
                timer.Stop();
                timerElapsed = false;
            }
        }

        void OnTimerElapsed(object sender, ElapsedEventArgs args)
        {
            timerElapsed = true;
        }
    }
}
