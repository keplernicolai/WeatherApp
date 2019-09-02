using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace StefaniniTeste.Utils
{
    public static class ConexaoInternetUtils
    {
        public static bool IsConnectInternet()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                Acr.UserDialogs.UserDialogs.Instance.Alert("Você precisa estar conectado a internet para ter o clima atualizado.");
                return false;
            }

            return true;
        }
    }
}
