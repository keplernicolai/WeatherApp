
using StefaniniTeste.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StefaniniTeste.Repositories
{
    public static class ClimaRepository
    {
        public static async Task InsertCidadeFavorita(CidadeFavorita cidadeFavorita)
        {
            Realms.Realm RealmDb = await Realms.Realm.GetInstanceAsync();

            RealmDb.Write(() =>
            {
                RealmDb.Add(cidadeFavorita);
            });
        }

        public static async Task UpdateCidadeFavorita(CidadeFavorita cidadeFavorita, RespostaAPI respostaAPI)
        {
            Realms.Realm RealmDb = await Realms.Realm.GetInstanceAsync();

            var cidade = new CidadeFavorita
            {
                IdCidade = cidadeFavorita.IdCidade,
                NomeCidade = cidadeFavorita.NomeCidade,
                StatusClima = respostaAPI.weather[0].description,
                Temperatura = respostaAPI.main.temp,
                TemperaturaMaxima = respostaAPI.main.temp_max,
                TemperaturaMinima = respostaAPI.main.temp_min,
                Icone = respostaAPI.weather[0].icon
            };

            RealmDb.Write(() =>
            {
                RealmDb.Add(cidade, true);
            });
        }

        public static async Task DeleteCidadeFavorita(int idCidade)
        {
            Realms.Realm RealmDb = await Realms.Realm.GetInstanceAsync();

            var cidade = await SelectCidadeFavoritaById(idCidade);

            using (var trans = RealmDb.BeginWrite())
            {
                RealmDb.Remove(cidade);
                trans.Commit();
            }
        }

        public static async Task<CidadeFavorita> SelectCidadeFavoritaById(int idCidade)
        {
            Realms.Realm RealmDb = await Realms.Realm.GetInstanceAsync();

            return RealmDb.All<CidadeFavorita>().FirstOrDefault(c => c.IdCidade == idCidade);        
        }

        public static List<CidadeFavorita> SelectCidadesFavoritas()
        {
            Realms.Realm RealmDb = Realms.Realm.GetInstance();

            var cidades = RealmDb.All<CidadeFavorita>().ToList();
            return cidades;
        }

        public static async Task<bool> EncontrarCidadeFavorita(int idCidade)
        {
            Realms.Realm RealmDb = await Realms.Realm.GetInstanceAsync();

            return RealmDb.All<CidadeFavorita>().Any(c => c.IdCidade == idCidade);
        }

    }
}
