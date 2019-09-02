using Newtonsoft.Json;
using StefaniniTeste.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StefaniniTeste.Utils
{
    public static class WebServiceBase
    {
        public static async Task<RespostaAPI> RequestAsync(int idCidade)
        {
            RespostaAPI objetoRetorno = new RespostaAPI();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var URL = string.Format("http://api.openweathermap.org/data/2.5/weather?id={0}&appid=2bac87e0cb16557bff7d4ebcbaa89d2f&lang=pt&units=metric", idCidade);

                    var response = await client.GetStringAsync(URL);

                    objetoRetorno = Newtonsoft.Json.JsonConvert.DeserializeObject<RespostaAPI>(response);

                }

                return objetoRetorno;
            }

            catch (Newtonsoft.Json.JsonException jx)
            {
                throw jx;
            }
            catch (Exception x)
            {
                throw x;
            }
        }
    }
}
