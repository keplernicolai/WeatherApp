using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace StefaniniTeste.Models
{
    public class DadosCidades
    {
        public ObservableCollection<InfoCidade> data { get; set; }
    }

    public class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    public class InfoCidade
    {
        public int id { get; set; }
        public Coord coord { get; set; }
        public string country { get; set; }
        public string name { get; set; }
        public int zoom { get; set; }
    } 
}
