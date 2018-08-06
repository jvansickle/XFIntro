using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFIntro.Page;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XFIntro
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var tabbedPage = new TabbedPage();

            tabbedPage.Children.Add(
                new NavigationPage(new MainPage())
                {
                    Title = "Contacts",
                    Icon = "contactIcon"
                }
            );

            tabbedPage.Children.Add(new Xamarin.Forms.Page { Title = "Second Page" });

            tabbedPage.Children.Add(new EmailPage());

            MainPage = tabbedPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
