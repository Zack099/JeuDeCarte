using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JeuDeCarte.Models;
using JeuDeCarte.Services;

namespace JeuDeCarte.Controllers
{
    [ApiController]
    [Route("api/JeuDeCarte")]
    public class JeuDeCarteController : ControllerBase
    {
        private readonly CarteContext _context;
        private readonly CarteService _carteService;
        private readonly JeuDeCarteService _JeuDeCarteService;
        private  UnJeuDeCarteBO _jeuDeCarte;

        public JeuDeCarteController(CarteService carteService, JeuDeCarteService JeuDeCarteService)
        {
            _carteService = carteService;
            _JeuDeCarteService = JeuDeCarteService;
        }



        [HttpGet("{Name}/{NbCarte}")]
        public UnJeuDeCarteBO StartGame(String name, int nbCarte)
        {
            _jeuDeCarte = _JeuDeCarteService.CreateJeuDeCarte(name, nbCarte);

            return _jeuDeCarte;
        }

        [HttpGet("GetCards/{gameId}/{NbCarte}")]
        public List<ModeleCarteDTO> GetSomeCards(int gameId ,int nbCarte)
        {
            return ListBOToDTO(_JeuDeCarteService.GetSomeCards(gameId, nbCarte));
        }

        [HttpGet("GetGame/{gameId}")]
        public UnJeuDeCarteBO GetJeuDeCarte(int gameId)
        {
            return _JeuDeCarteService.GetJeuDeCarte(gameId);
        }

        [HttpGet("Shuffle/{gameId}")]
        public void  ShuffleCarte(int gameId)
        {
            _JeuDeCarteService.ShuffleCartes(gameId);
        }
        public List<ModeleCarteDTO> ListBOToDTO(List<ModeleCarteBO> listOfBO)
        {
            var listCards = new List<ModeleCarteDTO>();
            foreach (ModeleCarteBO bo in listOfBO)
            {
                listCards.Add(_carteService.BOCarteToDTO(bo));
            }
            return listCards;
        }
        //    private static JeuDeCarteDTO ItemToDTO(ModeleCarte carte) =>
        //new ModeleCarteDTO
        //{
        //    CardCategory = carte.CardCategory,
        //    CardValue = carte.CardValue,
        //    Image = carte.Image
        //};
    }
}
