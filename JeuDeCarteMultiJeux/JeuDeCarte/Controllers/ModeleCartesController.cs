//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using JeuDeCarte.Models;
//using JeuDeCarte.Services;

//namespace JeuDeCarte.Controllers
//{
//    [Route("api/ModeleCartes")]
//    [ApiController]
//    public class ModeleCartesController : ControllerBase
//    {
//        private readonly CarteContext _context;
//        private readonly CarteService _CarteService;
//        private readonly JeuDeCarteService _JeuDeCarteService;
//        public ModeleCartesController(CarteService carteService, JeuDeCarteService JeuDeCarteService)
//        {
//            _CarteService = carteService;
//            _JeuDeCarteService = JeuDeCarteService;
//        }

//        // GET: api/ModeleCartes
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<ModeleCarteDTO>>> GetModeleCartes()
//        {
//            return await _CarteService.GetAllCartes();
//        }

//        // GET: api/ModeleCartes/CreateJeuDeCarte/DeckOfCards
//        [HttpGet("CreateJeuDeCarte/{name}")]
//        public Task<ActionResult<UnJeuDeCarte>> CreateJeuDeCarte(String name)
//        {
//            var JCarte = _JeuDeCarteService.CreateJeuDeCarte(name);
           

//            return _CarteService.InitializeJeuDeCarte(JCarte);
//        }


//        // GET: api/ModeleCartes/GetACard
//        [HttpGet("{GetACard}")]
//        public  ActionResult<ModeleCarteDTO> GetModeleCarte()
//        {
//            var modeleCarte = _CarteService.GetACard();

//            if (modeleCarte == null)
//            {
//                return NotFound();
//            }

//            return modeleCarte;
//        }


//        // GET: api/ModeleCartes/3
//        [HttpGet("GetSomeCards/{NbCards}")]
//        public Task<ActionResult<IEnumerable<ModeleCarteDTO>>> GetSomeCards(int NbCards)
//        {
//            var modeleCartes = _CarteService.GetSomeCards(NbCards);

//            return modeleCartes;
//        }

//        // PUT: api/ModeleCartes/5
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutModeleCarte(int id, ModeleCarteDTO modeleCarte)
//        {
//            if (id != modeleCarte.id)
//            {
//                return BadRequest();
//            }

//            _context.Entry(modeleCarte).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!ModeleCarteExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/ModeleCartes
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPost]
//        public async Task<ActionResult<ModeleCarteDTO>> PostModeleCarte(ModeleCarteDTO modeleCarte)
//        {
//            _context.ModeleCartes.Add(modeleCarte);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction(nameof(GetModeleCarte), new { id = modeleCarte.id }, modeleCarte);
//        }

//        // DELETE: api/ModeleCartes/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteModeleCarte(int id)
//        {
//            var modeleCarte = await _context.ModeleCartes.FindAsync(id);
//            if (modeleCarte == null)
//            {
//                return NotFound();
//            }

//            _context.ModeleCartes.Remove(modeleCarte);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        private bool ModeleCarteExists(int id)
//        {
//            return _context.ModeleCartes.Any(e => e.id == id);
//        }

//        private static ModeleCarteDTO ItemToDTO(ModeleCarte carte) =>
//    new ModeleCarteDTO
//    {
//        CardCategory = carte.CardCategory,
//        CardValue = carte.CardValue,
//        Image = carte.Image
//    };
//    }
//}
