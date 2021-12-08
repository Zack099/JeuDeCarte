using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JeuDeCarte.BO;

namespace JeuDeCarte.DAL
{
    public class UnJeuDeCarte
    {
        public int id { get; set; }
        public String Name { get; set; }
        public int NbCarte { get; set; }
        public List<ModeleCarteBO> Hand { get; set; }
        public List<ModeleCarteBO> Cards { get; set; }

        public List<ModeleCarteBO> DefaussedCards { get; set; }

    }
}
