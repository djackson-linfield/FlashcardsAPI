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
                    Card card = new Card();
                    card.Front = newCard.Front;
                    card.Back = newCard.Back;
                    card.DeckId = newCard.DeckId;
                    card.TimesStudied = newCard.TimesStudied;
                    db.Cards.Add(card);
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

        [HttpGet("[action]/{deckId}")]
        public IActionResult GetCardsByDeck(long deckId)
        {
            try
            {
                Console.WriteLine("UserController.Post() posting a new item");

                using (DecksContext db = new DecksContext())
                {
                    var cards = db.Cards
                        .Where(u => u.DeckId == deckId)
                        .Select(u => new { Deck = u })
                        .ToList();
                    if (cards == null) return StatusCode(500);
                    return new ObjectResult(cards);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("CustomerController.Post() got error: " + ex.Message + ", Stack = " + ex.StackTrace);
                return StatusCode(500);
            }
        }

        [HttpPut("[action]")]
        public IActionResult Put([FromBody] Card value)
        {

            using (DecksContext db = new DecksContext())
            {
                var card = db.Cards
                        .Where(p => p.CardId == value.CardId)
                        .Select(p => new { Card = p })
                        .FirstOrDefault();
                if (card == null) return StatusCode(500);
                card.Card.TimesStudied = value.TimesStudied;
                card.Card.Front = value.Front;
                card.Card.Back = value.Back;
                db.SaveChanges();
                return Ok();
            }
        }


    }
}
