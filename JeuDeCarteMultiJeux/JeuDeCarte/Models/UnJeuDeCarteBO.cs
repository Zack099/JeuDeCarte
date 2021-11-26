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
    public static class ListExtenion
    {
        private static Random rng = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

    }
    
}
