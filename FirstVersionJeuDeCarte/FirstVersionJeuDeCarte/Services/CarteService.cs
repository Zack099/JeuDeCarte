using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JeuDeCarte.Models;

namespace JeuDeCarte.Services
{
    public class CarteService
    {
        private readonly CarteContext _context;

        public CarteService(CarteContext context)
        {
            _context = context;
        }
        public  List<ModeleCarteDTO> GetAllCartes()
        {
            return _context.ModeleCartes.ToList();
        }

        public async Task<ActionResult<UnJeuDeCarte>> InitializeJeuDeCarte(UnJeuDeCarte JCarte)
        {
            JCarte.Cards = await _context.ModeleCartes.ToListAsync();
            
            return JCarte;
        }
        public  ModeleCarteDTO  GetACard()
        {
            var carte = _context.ModeleCartes.Where(b => b.DejaTire == false).First();
            carte.DejaTire = true;
            _context.SaveChanges();
            return carte;
        }

        public async Task<ActionResult<IEnumerable<ModeleCarteDTO>>> GetSomeCards(int NbCards)
        {
            var cartes = await _context.ModeleCartes.Where(b => b.DejaTire == false).Take(NbCards).ToListAsync();
            
            foreach (ModeleCarteDTO carte in cartes)
            {
                carte.DejaTire = true;
            }
            
            _context.SaveChanges();
            return cartes;
        }

        //public async Task<ActionResult<IEnumerable<ModeleCarteDTO>>> ShuffleCards()
        //{
        //    var cartes = await _context.ModeleCartes.Where(b => b.DejaTire == false).ToListAsync();
        //    Random rnd = new Random();
        //    foreach (ModeleCarteDTO carte in cartes)
        //    {   
        //        rndId=
        //        if 
        //        carte.id = rnd.Next(1, 52);
        //    }

        //    _context.SaveChanges();
        //    return cartes;
        //}
    }
}
