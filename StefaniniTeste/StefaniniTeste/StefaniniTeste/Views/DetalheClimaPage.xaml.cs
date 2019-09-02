using StefaniniTeste.Models;
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
    public partial class DetalheClimaPage : ContentPage
    {
        public DetalheClimaPage(int idCidade)
        {
            InitializeComponent();
            BindingContext = new DetalheClimaPageViewModel(idCidade);
        }
    }
}