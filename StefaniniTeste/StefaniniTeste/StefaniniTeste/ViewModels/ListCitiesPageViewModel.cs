using StefaniniTeste.Models;
using StefaniniTeste.Utils;
using StefaniniTeste.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace StefaniniTeste.ViewModels
{
    public class ListCitiesPageViewModel : BaseViewModel
    {
        #region Properties

        public ObservableCollection<InfoCidade> Cidades { get; set; }

        private InfoCidade cidadeSelecionada;
        public InfoCidade CidadeSelecionada
        {
            get { return cidadeSelecionada; }
            set
            {
                cidadeSelecionada = value;
                OnPropertyChanged();
                IrDetalhesCidade();
            }
        }

        #endregion

        public ListCitiesPageViewModel()
        {
            PreencherListaCidades();
        }

        private void PreencherListaCidades()
        {
            try
            {
                var obj = Utils.JsonUtils.DeserializeCitiesFile();
                Cidades = new ObservableCollection<InfoCidade>(obj.data);
            }

            catch (Exception ex)
            {
                Acr.UserDialogs.UserDialogs.Instance.Alert(ex.Message);
            }
        }

        private async void IrDetalhesCidade()
        {
            if (Utils.ConexaoInternetUtils.IsConnectInternet())
            {
                await NavigationService.PushAsync(new DetalheClimaPage(CidadeSelecionada.id));
            }
        }
    }
}
