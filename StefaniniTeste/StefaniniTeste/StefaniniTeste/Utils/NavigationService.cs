using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StefaniniTeste.Utils
{
    public static class NavigationService
    {
        static INavigation Navigation => Application.Current.MainPage.Navigation;

        public static async Task PopAsync()
        {
            await Navigation.PopAsync();
        }

        public static async Task PopToRootAsync()
        {
            await Navigation.PopToRootAsync();
        }

        public static void SetRootPage(Page view, bool wrapInNavigation = true)
        {
            Application.Current.MainPage = wrapInNavigation ? new NavigationPage(view) : view;
        }

        public static async Task PushAsync(Page page)
        {
            await Navigation.PushAsync(page);
        }
    }
}
