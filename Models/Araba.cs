using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcDenemeHello.Models
{
    public class Araba
    {
        public int Arabaid { get; set; }
        public string Marka { get; set; }
        public int Model { get; set; }
        public int Teker { get; set; }

        public Araba() { }
        public Araba(int arabaid,string marka,int model, int teker)
        {
            this.Arabaid = arabaid;
            this.Marka = marka;
            this.Model = model;
            this.Teker = teker;
        }
    }
}
