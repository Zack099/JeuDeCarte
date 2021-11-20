﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JeuDeCarte.Models;

namespace JeuDeCarte.Services
{
    public class JeuDeCarteService
    {
        private readonly CarteContext _context;
        private readonly CarteService _carteService;

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
                Cards = todoItem.Cards,
                DefaussedCards = todoItem.DefaussedCards
            };
        private static UnJeuDeCarte BOToEntity(UnJeuDeCarteBO todoItem) =>
            new UnJeuDeCarte
            {
                id = todoItem.id,
                Name = todoItem.Name,
                NbCarte = todoItem.NbCarte,
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
            _context.UnJeuDeCarte.Add(JCarte);
            _context.SaveChanges();
            var JCarteBO = ItemToBO(JCarte);
            return JCarteBO;
        }

        public UnJeuDeCarteBO GetJeuDeCarte(int id)
        {
            var JCarte = _context.UnJeuDeCarte.Where(jeu => jeu.id == id)
                       .Include(b => b.Cards).Include(b => b.DefaussedCards)
                       .FirstOrDefault();
            var JCarteBO = ItemToBO(JCarte);
            return JCarteBO;
        }



        public  List<ModeleCarteBO> GetSomeCards(int gameId, int NbCartes)
        {
            
            var JCarte = _context.UnJeuDeCarte.Where(jeu => jeu.id == gameId)
                       .Include(b => b.Cards).Include(b => b.DefaussedCards)
                       .FirstOrDefault();
            var JCarteBO = ItemToBO(JCarte); 
            var cartes = JCarteBO.Cards.GetRange(0,NbCartes);
            
            foreach (ModeleCarteBO carte in cartes)
            {
                JCarteBO.Cards.Remove(carte);
                JCarteBO.DefaussedCards.Add(carte);
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
