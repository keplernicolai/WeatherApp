
using System;
using System.Collections.Generic;
using System.Text;

namespace StefaniniTeste.Models
{
    public class CidadeFavorita : Realms.RealmObject
    {
        [Realms.PrimaryKey]
        public int IdCidade { get; set; }
        public string NomeCidade { get; set; }
        public double Temperatura { get; set; }
        public double TemperaturaMaxima { get; set; }
        public double TemperaturaMinima { get; set; }
        public string StatusClima { get; set; }
        public string Icone { get; set; }
    }
}
