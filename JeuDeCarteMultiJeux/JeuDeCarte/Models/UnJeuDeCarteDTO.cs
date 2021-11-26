using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeuDeCarte.Models
{
    public class UnJeuDeCarteDTO
    {
        public int id { get; set; }
        public String Name { get; set; }
        public int NbCarte { get; set; }
        public List<ModeleCarteDTO> Cards { get; set; }
        public List<ModeleCarteDTO> DefaussedCards { get; set; }
    }
    

    
    
}
