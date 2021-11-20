using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeuDeCarte.Models
{
    public class UnJeuDeCarteBO
    {
        public int id { get; set; }
        public String Name { get; set; }
        public int NbCarte { get; set; }
        public List<ModeleCarteBO> Cards { get; set; }
        public List<ModeleCarteBO> DefaussedCards { get; set; }
    }
}
