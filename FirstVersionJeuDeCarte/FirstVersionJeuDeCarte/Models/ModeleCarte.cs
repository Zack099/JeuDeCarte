using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeuDeCarte.Models
{
    public class ModeleCarte
    {
        public int id { get; set; }
        public Boolean success { get; set; }
        public Boolean DejaTire { get; set; }
        public string CardValue { get; set; }
        public String CardCategory { get; set; }
        public int Remaining { get; set; }
        public int Discarded { get; set; } 
        public String LastDiscarded { get; set; } 
        public string Image { get; set; }



    }
}
