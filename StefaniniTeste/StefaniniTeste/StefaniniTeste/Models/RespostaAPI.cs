using System;
using System.Collections.Generic;
using System.Text;

namespace StefaniniTeste.Models
{
    public class RespostaAPI
    {
        public Coord coord { get; set; }
        public List<Weather> weather { get; set; }
        public Main main { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }
    //public class Coord
    //{
    //    public double lon { get; set; }
    //    public double lat { get; set; }
    //}

    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class Main
    {
        public double temp { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
    }
}
