using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JeuDeCarte.DAL;
using JeuDeCarte.BO;

namespace JeuDeCarte.BP
{
    public class JeuDeCarteService : IJeuDeCarteService
    {
        private readonly CarteContext _context;
        private readonly ICarteService _carteService;
        
        public JeuDeCarteService(CarteContext context, CarteService carteService)
        {
            _carteService = carteService;
            _context = context;
        }



        private static UnJeuDeCarteBO ItemToBO(UnJeuDeCarte todoItem) =>
            new UnJeuDeCarteBO
            {
                id = todoItem.id,
                Name = todoItem.Name,
                NbCarte = todoItem.NbCarte,
                Hand = todoItem.Hand,
                Cards = todoItem.Cards,
                DefaussedCards = todoItem.DefaussedCards
            };

        private static UnJeuDeCarte BOToEntity(UnJeuDeCarteBO todoItem) =>
            new UnJeuDeCarte
            {
                id = todoItem.id,
                Name = todoItem.Name,
                NbCarte = todoItem.NbCarte,
                Hand = todoItem.Hand,
                Cards = todoItem.Cards,
                DefaussedCards = todoItem.DefaussedCards
            };



        public UnJeuDeCarteBO CreateJeuDeCarte(String name,int nbCarte)
        {
            int lastId;
            try
            {
                lastId = _context.UnJeuDeCarte.OrderByDescending(p => p.id).FirstOrDefault().id;
            }
            catch (Exception e)
            {
                lastId = 0;
            }
            var JCarte = new UnJeuDeCarte();
            JCarte.id = lastId + 1;
            JCarte.Name = name;
            JCarte.NbCarte = nbCarte;
            JCarte.Cards = GetAllCartes();
            JCarte.Hand = new List<ModeleCarteBO>();
            JCarte.DefaussedCards = new List<ModeleCarteBO>();
            _context.UnJeuDeCarte.Add(JCarte);
            _context.SaveChanges();
            var JCarteBO = ItemToBO(JCarte);
            return JCarteBO;
        }

        public UnJeuDeCarteBO GetJeuDeCarte(int id)
        {
            var JCarte = _context.UnJeuDeCarte.Where(jeu => jeu.id == id)
                       .Include(b => b.Cards).Include(b => b.Hand).Include(b => b.DefaussedCards)
                       .FirstOrDefault();
            var JCarteBO = ShuffleCartes(ItemToBO(JCarte).id);
            return JCarteBO;
        }



        public  List<ModeleCarteBO> GetSomeCards(int gameId, int NbCartes)
        {
            
            var JCarte = _context.UnJeuDeCarte.Where(jeu => jeu.id == gameId)
                       .Include(b => b.Cards).Include(b => b.Hand).Include(b => b.DefaussedCards)
                       .FirstOrDefault();
            var JCarteBO = ShuffleCartes(ItemToBO(JCarte).id); 
            var cartes = JCarteBO.Cards.GetRange(0,NbCartes);
            
            foreach (ModeleCarteBO carte in cartes)
            {
                JCarteBO.Cards.Remove(carte);
                JCarteBO.Hand.Add(carte);
                //JCarteBO.DefaussedCards.Add(carte);
            }
            JCarte = BOToEntity(JCarteBO);
            _context.SaveChanges();
            return cartes;
        }

        public List<ModeleCarteBO> ThrowSomeCards(int gameId, String throwcartes)
        {

            var JCarte = _context.UnJeuDeCarte.Where(jeu => jeu.id == gameId)
                       .Include(b => b.Cards).Include(b => b.Hand).Include(b => b.DefaussedCards)
                       .FirstOrDefault();
            //?? a voir si ça marche
            var JCarteBO = ItemToBO(JCarte);
            
            var cartes = JCarteBO.Hand;
            var throwcartesSplited = throwcartes.Split('-');

            foreach (ModeleCarteBO carte in cartes.ToList())
            {
                if (throwcartesSplited.Contains(carte.CardValue)){
                    //JCarteBO.Cards.Remove(carte);
                    JCarteBO.DefaussedCards.Add(carte);
                    JCarteBO.Hand.Remove(carte);
                    
                }
                
            }
            JCarte = BOToEntity(JCarteBO);
            _context.SaveChanges();
            return cartes;
        }

        public List<ModeleCarteBO> GetAllCartes()
        {
            var listOfEntity = _context.ModeleCartes.ToList();
            var listCards = new List<ModeleCarteBO>();
            foreach (ModeleCarte entity in listOfEntity)
            {
                listCards.Add(_carteService.ModeleCarteToBO(entity));
            }
            return listCards;
        }

        



        public UnJeuDeCarteBO ShuffleCartes(int gameId)
        {
            var JCarte = _context.UnJeuDeCarte.Where(jeu => jeu.id == gameId)
                       .Include(b => b.Cards).Include(b => b.Hand).Include(b => b.DefaussedCards)
                       .FirstOrDefault();
            var JCarteBO = ItemToBO(JCarte);
            JCarteBO.Cards.Shuffle();
            //gameId.Printme();
            //JCarteBO.Printme();
            JCarte = BOToEntity(JCarteBO);
            //_context.UnJeuDeCarte.Update(JCarte);
            _context.SaveChanges();
            return JCarteBO;
             
        }

        

        //List<Product> products = getproducts()
        //    products.Shuffle();

        //public List<ModeleCarteDTO> GetAllCartes()
        //{
        //    var listOfEntity = _context.ModeleCartes.ToList();
        //    var listCards = new List<ModeleCarteDTO>();
        //    foreach (ModeleCarte entity in listOfEntity)
        //    {
        //        listCards.Add(_carteService.ModeleCarteToDTO(entity));
        //    }
        //    return listCards;
        //}
    }
}

