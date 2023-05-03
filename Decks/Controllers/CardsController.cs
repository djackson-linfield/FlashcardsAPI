using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Decks.Data;
using Decks.Models;

namespace Decks.Controllers
{
    [ApiController]
    [Route("api/cards")]
    public class CardsController : Controller
    {

        [HttpGet("[action]")]
        public IActionResult Get()
        {

            try
            {
                Console.WriteLine("DecksController.GetDecks() fetching decks");

                List<Card> cards = new List<Card>();

                using (DecksContext db = new DecksContext())
                {

                    cards = db.Cards.ToList();

                    if (cards == null)
                    {
                        return new ObjectResult("No users to display.");
                    }

                    return new ObjectResult(cards);

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("UsersController.GetItems() got error: " + ex.Message + ", Stack = " + ex.StackTrace);
                return StatusCode(500);
            }
        }

        [HttpPost("[action]")]
        public IActionResult Post([FromBody]Card newCard)
        {
            try
            {
                Console.WriteLine("posting new card");
                using(DecksContext db = new DecksContext())
                {
                    db.Cards.Add(newCard);
                    db.SaveChanges();
                    return StatusCode(200);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("TourneyController.Post() got error: " + ex.Message + ", Stack = " + ex.StackTrace);
                return StatusCode(500);
            }
        }


    }
}
