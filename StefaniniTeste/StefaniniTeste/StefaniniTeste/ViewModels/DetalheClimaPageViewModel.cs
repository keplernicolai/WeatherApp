using StefaniniTeste.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace StefaniniTeste.ViewModels
{
    public class DetalheClimaPageViewModel : BaseViewModel
    {
        #region Properties

        private bool isFavoritado = false;
        public bool IsFavoritado
        {
            get { return isFavoritado; }
            set
            {
                isFavoritado = value;
                OnPropertyChanged();
            }
        }

        private CidadeFavorita cidadeFavorita;
        public CidadeFavorita CidadeFavorita
        {
            get { return cidadeFavorita; }
            set
            {
                cidadeFavorita = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        public Command FavoritarCommand { get; set; }
        public Command RemoverFavoritoCommand { get; set; }

        #endregion

        public DetalheClimaPageViewModel(int idCidade)
        {
            //CidadeFavorita = new CidadeFavorita();
            BuscarDetalhesClima(idCidade);

            FavoritarCommand = new Command(SalvarFavorito);
            RemoverFavoritoCommand = new Command(RemoverFavorito);
        }

        private async void BuscarDetalhesClima(int idCidade)
        {
            try
            {
                Acr.UserDialogs.UserDialogs.Instance.ShowLoading("Aguarde...");
                var resultAPI = await Utils.WebServiceBase.RequestAsync(idCidade);

                CidadeFavorita = new CidadeFavorita
                {
                    IdCidade = resultAPI.id,
                    NomeCidade = resultAPI.name,
                    Icone = "sunny.png",
                    StatusClima = resultAPI.weather[0].description,
                    Temperatura = resultAPI.main.temp,
                    TemperaturaMaxima = resultAPI.main.temp_max,
                    TemperaturaMinima = resultAPI.main.temp_min
                };

                SetBotaoVisivel();
                Acr.UserDialogs.UserDialogs.Instance.HideLoading();
            }

            catch (Exception ex)
            {
                Acr.UserDialogs.UserDialogs.Instance.HideLoading();
                Acr.UserDialogs.UserDialogs.Instance.Alert(ex.Message);
            }

        }

        private async void SalvarFavorito()
        {
            try
            {
                Acr.UserDialogs.UserDialogs.Instance.ShowLoading("Aguarde...");
                await Repositories.ClimaRepository.InsertCidadeFavorita(CidadeFavorita);
                Utils.NavigationService.SetRootPage(new MainPage());
                Acr.UserDialogs.UserDialogs.Instance.HideLoading();
            }

            catch (Exception ex)
            {
                Acr.UserDialogs.UserDialogs.Instance.HideLoading();
                Acr.UserDialogs.UserDialogs.Instance.Alert(ex.Message);
            }
        }

        private async void RemoverFavorito()
        {
            try
            {
                Acr.UserDialogs.UserDialogs.Instance.ShowLoading("Aguarde...");
                await Repositories.ClimaRepository.DeleteCidadeFavorita(CidadeFavorita.IdCidade);
                Utils.NavigationService.SetRootPage(new MainPage());
                Acr.UserDialogs.UserDialogs.Instance.HideLoading();
            }

            catch (Exception ex)
            {
                Acr.UserDialogs.UserDialogs.Instance.HideLoading();
                Acr.UserDialogs.UserDialogs.Instance.Alert(ex.Message);
            }
            
        }

        private async void SetBotaoVisivel()
        {
            try
            {
                Acr.UserDialogs.UserDialogs.Instance.ShowLoading("Aguarde...");
                IsFavoritado = await Repositories.ClimaRepository.EncontrarCidadeFavorita(CidadeFavorita.IdCidade);
                Acr.UserDialogs.UserDialogs.Instance.HideLoading();
            }

            catch (Exception ex)
            {
                Acr.UserDialogs.UserDialogs.Instance.HideLoading();
                Acr.UserDialogs.UserDialogs.Instance.Alert(ex.Message);
            }
            
        }

    }
}
