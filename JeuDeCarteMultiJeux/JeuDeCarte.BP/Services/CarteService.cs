using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JeuDeCarte.BO;
using JeuDeCarte.DAL;
using JeuDeCarte.DTO;


namespace JeuDeCarte.BP
{
    public class CarteService : ICarteService
    {
        private readonly CarteContext _context;

        public CarteService(CarteContext context)
        {
            _context = context;
        }

        public  ModeleCarteDTO ModeleCarteToDTO(ModeleCarte carte) =>
            new ModeleCarteDTO
            {
                CardCategory = carte.CardCategory,
                CardValue = carte.CardValue,
                Image = carte.Image
            };

        public ModeleCarteBO ModeleCarteToBO(ModeleCarte carte) =>
            new ModeleCarteBO
            {
                CardCategory = carte.CardCategory,
                CardValue = carte.CardValue,
                Image = carte.Image
            };

        public ModeleCarteDTO BOCarteToDTO(ModeleCarteBO carte) =>
            new ModeleCarteDTO
            {
                CardCategory = carte.CardCategory,
                CardValue = carte.CardValue,
                Image = carte.Image
            };

        //public  List<ModeleCarteDTO> GetAllCartes()
        //{
        //    return _context.ModeleCartes.ToList();
        //}

        //public async Task<ActionResult<UnJeuDeCarte>> InitializeJeuDeCarte(UnJeuDeCarte JCarte)
        //{
        //    JCarte.Cards = await _context.ModeleCartes.ToListAsync();

        //    return JCarte;
        //}
        //public ModeleCarteDTO GetACard()
        //{
        //    var carte = _context.ModeleCartes.Where(b => b.DejaTire == false).First();
        //    carte.DejaTire = true;
        //    _context.SaveChanges();
        //    return carte;
        //}

        //public async Task<ActionResult<IEnumerable<ModeleCarteDTO>>> GetSomeCards(int NbCards)
        //{
        //    var cartes = await _context.ModeleCartes.Where(b => b.DejaTire == false).Take(NbCards).ToListAsync();

        //    foreach (ModeleCarteDTO carte in cartes)
        //    {
        //        carte.DejaTire = true;
        //    }

        //    _context.SaveChanges();
        //    return cartes;
        //}

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
