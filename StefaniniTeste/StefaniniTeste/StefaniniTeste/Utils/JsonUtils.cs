using Newtonsoft.Json;
using StefaniniTeste.Models;
using StefaniniTeste.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Text;

namespace StefaniniTeste.Utils
{
    public static class JsonUtils
    {
        public static DadosCidades DeserializeCitiesFile()
        {
            try
            {
                string jsonFileName = "EmbeddedResources.cities.json";
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(ListCitiesPage)).Assembly;
                Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonFileName}");

                using (var reader = new System.IO.StreamReader(stream))
                {
                    var jsonString = reader.ReadToEnd();

                    return JsonConvert.DeserializeObject<DadosCidades>(jsonString);
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
