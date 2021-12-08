using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace JeuDeCarte.DTO
{
    public class UnJeuDeCarteDTO
    {
        public List<ModeleCarteDTO> Hand { get; set; }
        public int id { get; set; }
        public String Name { get; set; }
        public int NbCarte { get; set; }
        public List<ModeleCarteDTO> Cards { get; set; }
        public List<ModeleCarteDTO> DefaussedCards { get; set; }
    }
    

    
    
}
