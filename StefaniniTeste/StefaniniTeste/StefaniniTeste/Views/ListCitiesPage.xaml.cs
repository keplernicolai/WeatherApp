using StefaniniTeste.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StefaniniTeste.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListCitiesPage : ContentPage
    {
        public ListCitiesPage()
        {
            InitializeComponent();
            BindingContext = new ListCitiesPageViewModel();
        }
    }
}