using StefaniniTeste.Models;
using StefaniniTeste.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace StefaniniTeste.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {

        #region Properties

        private ObservableCollection<CidadeFavorita> cidadesFavoritas;
        public ObservableCollection<CidadeFavorita> CidadesFavoritas
        {
            get { return cidadesFavoritas; }
            set
            {
                cidadesFavoritas = value;
                OnPropertyChanged();
            }
        }

        private CidadeFavorita cidadeSelecionada;
        public CidadeFavorita CidadeSelecionada
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

        #region Commands

        public Command ProcurarCidadeCommand { get; set; }
        public Command RemoverFavoritoCommand { get; set; }

        #endregion

        public MainPageViewModel() 
        {
            BuscarCidadesFavoritasAtualizadas();

            ProcurarCidadeCommand = new Command(ProcurarCidades);
        }

       
        private async void BuscarCidadesFavoritasAtualizadas()
        {
            try
            {
                Acr.UserDialogs.UserDialogs.Instance.ShowLoading("Aguarde...");
                var cidades = Repositories.ClimaRepository.SelectCidadesFavoritas();

                if (cidades.Count > 0)
                {
                    if (Utils.ConexaoInternetUtils.IsConnectInternet())
                    {
                        foreach (var cidade in cidades)
                        {
                            var resultAPI = await Utils.WebServiceBase.RequestAsync(cidade.IdCidade);
                            await Repositories.ClimaRepository.UpdateCidadeFavorita(cidade, resultAPI);
                        }
                    }

                    CidadesFavoritas = new ObservableCollection<CidadeFavorita>(cidades);
                }

                else
                    Acr.UserDialogs.UserDialogs.Instance.Alert("Você não possui cidades favoritas.");

                Acr.UserDialogs.UserDialogs.Instance.HideLoading();
            }

            catch (Exception ex)
            {
                Acr.UserDialogs.UserDialogs.Instance.HideLoading();
                Acr.UserDialogs.UserDialogs.Instance.Alert(ex.Message);
            }

            
        }

        private async void ProcurarCidades()
        {
            await Utils.NavigationService.PushAsync(new ListCitiesPage());
        }

        private async void IrDetalhesCidade()
        {
            if (Utils.ConexaoInternetUtils.IsConnectInternet())
            {
                await Utils.NavigationService.PushAsync(new DetalheClimaPage(CidadeSelecionada.IdCidade));
            }
        }
    }
}
