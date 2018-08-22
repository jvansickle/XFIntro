using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace XFIntro.ViewModel
{
    public class CustomRendererViewModel : BaseViewModel
    {
        public event Action Elapsed;

        public ICommand ElapsedCommand => new Command(OnElapsedCommand);

        void OnElapsedCommand(object parameter)
        {
            Elapsed?.Invoke();
        }
    }
}
