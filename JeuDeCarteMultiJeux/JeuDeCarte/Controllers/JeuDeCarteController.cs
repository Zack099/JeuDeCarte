using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using JeuDeCarte.DAL;
using JeuDeCarte.BP;
using JeuDeCarte.BO;
using JeuDeCarte.DTO;

namespace JeuDeCarte.Controllers
{
    [ApiController]
    [Route("api/JeuDeCarte")]
    public class JeuDeCarteController : ControllerBase
    {
        private readonly CarteContext _context;
        private readonly ICarteService _carteService;
        private readonly IJeuDeCarteService _JeuDeCarteService;
        private  UnJeuDeCarteBO _jeuDeCarte;

        public JeuDeCarteController(CarteService carteService, JeuDeCarteService JeuDeCarteService)
        {
            _carteService = carteService;
            _JeuDeCarteService = JeuDeCarteService;
        }



        [HttpGet("{name}/{nbCarte}")]
        public UnJeuDeCarteDTO StartGame(String name, int nbCarte)
        {
            _jeuDeCarte = _JeuDeCarteService.CreateJeuDeCarte(name, nbCarte);

            return BOToDTO(_jeuDeCarte);
        }

        [HttpGet("GetCards/{gameId}/{nbCarte}")]
        public List<ModeleCarteDTO> GetSomeCards(int gameId ,int nbCarte)
        {
            return ListBOToDTO(_JeuDeCarteService.GetSomeCards(gameId, nbCarte));
        }

        // Seperate the throwcartes with <-> if you want to throw more then one card
        [HttpGet("ThrowCards/{gameId}/{throwcartes}")]
        public List<ModeleCarteDTO> ThrowSomeCards(int gameId, String throwcartes)
        {
            return ListBOToDTO(_JeuDeCarteService.ThrowSomeCards(gameId, throwcartes));
        }

        [HttpGet("FromDefausseToCards/{gameId}/{nbCarte}")]
        public List<ModeleCarteDTO> FromDefausseToCards(int gameId, int nbCarte)
        {
            return ListBOToDTO(_JeuDeCarteService.FromDefausseToCards(gameId, nbCarte));
        }

        [HttpGet("GetGame/{gameId}")]
        public UnJeuDeCarteDTO GetJeuDeCarte(int gameId)
        {
            return BOToDTO(_JeuDeCarteService.GetJeuDeCarte(gameId));
        }

        [HttpGet("Shuffle/{gameId}")]
        public void  ShuffleCarte(int gameId)
        {
            _JeuDeCarteService.ShuffleCartes(gameId);
        }
        [HttpGet()]
        public List<ModeleCarteDTO> ListBOToDTO(List<ModeleCarteBO> listOfBO)
        {
            var listCards = new List<ModeleCarteDTO>();
            foreach (ModeleCarteBO bo in listOfBO)
            {
                listCards.Add(_carteService.BOCarteToDTO(bo));
            }
            return listCards;
        }
        [HttpGet()]
        private UnJeuDeCarteDTO BOToDTO(UnJeuDeCarteBO todoItem) =>
            new UnJeuDeCarteDTO
            {
                id = todoItem.id,
                Name = todoItem.Name,
                NbCarte = todoItem.NbCarte,
                Hand = ListBOToDTO(todoItem.Hand),
                Cards = ListBOToDTO(todoItem.Cards),
                DefaussedCards = ListBOToDTO(todoItem.DefaussedCards)
            };
        //    private static JeuDeCarteDTO ItemToDTO(ModeleCarte carte) =>
        //new ModeleCarteDTO
        //{
        //    CardCategory = carte.CardCategory,
        //    CardValue = carte.CardValue,
        //    Image = carte.Image
        //};
    }
}
