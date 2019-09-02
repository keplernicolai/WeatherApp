using StefaniniTeste.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StefaniniTeste
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            Utils.NavigationService.SetRootPage(new MainPage(), true);
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
