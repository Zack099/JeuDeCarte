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
        private readonly CarteService _CarteService;
        private readonly JeuDeCarteService _JeuDeCarteService;
        private  UnJeuDeCarteBO _jeuDeCarte;
        public JeuDeCarteController(CarteService carteService, JeuDeCarteService JeuDeCarteService)
        {
            _CarteService = carteService;
            _JeuDeCarteService = JeuDeCarteService;
        }



        [HttpGet("{Name}/{NbCarte}")]
        public UnJeuDeCarteBO StartGame(String name, int nbCarte)
        {
            _jeuDeCarte = _JeuDeCarteService.CreateJeuDeCarte(name, nbCarte);



            return _jeuDeCarte;
        }

        [HttpGet("GetCards/{gameId}/{NbCarte}")]
        public List<ModeleCarteBO> GetSomeCards(int gameId ,int nbCarte)
        {
            return _JeuDeCarteService.GetSomeCards(gameId, nbCarte);
        }

        [HttpGet("GetGame/{gameId}")]
        public UnJeuDeCarteBO GetJeuDeCarte(int gameId)
        {
            return _JeuDeCarteService.GetJeuDeCarte(gameId);
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
