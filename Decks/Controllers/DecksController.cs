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
    [Route("api/deck")]
    public class DecksController : Controller
    {

        [HttpGet("[action]")]
        public IActionResult Get()
        {

            try
            {
                Console.WriteLine("DecksController.GetDecks() fetching decks");

                List<Deck> decks = new List<Deck>();

                using (DecksContext db = new DecksContext())
                {

                    decks = db.Decks.ToList();

                    if (decks == null)
                    {
                        return new ObjectResult("No users to display.");
                    }

                    return new ObjectResult(decks);

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("UsersController.GetItems() got error: " + ex.Message + ", Stack = " + ex.StackTrace);
                return StatusCode(500);
            }
        }

        [HttpPost("[action]")]
        public IActionResult Post([FromBody] Deck newDeck)
        {
            try
            {
                Console.WriteLine("posting new deck");
                using (DecksContext db = new DecksContext())
                {
                    Deck deck = new Deck();
                    deck.Name = newDeck.Name;
                    deck.Description = newDeck.Description;
                    deck.UserId = newDeck.UserId;
                    deck.TagId = newDeck.TagId;
                    db.Decks.Add(deck);
                    db.SaveChanges();
                    return StatusCode(200);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DecksController.Post() got error: " + ex.Message + ", Stack = " + ex.StackTrace);
                return StatusCode(500);
            }
        }

        [HttpGet("[action]/{userId}")]
        public IActionResult GetDecksByUser(long userId)
        {
            try
            {
                Console.WriteLine("UserController.Post() posting a new item");

                using (DecksContext db = new DecksContext())
                {
                    var decks = db.Decks
                        .Where(u => u.UserId == userId)
                        .Select(u => new { Deck = u })
                        .ToList();
                    if (decks == null) return StatusCode(500);
                    return new ObjectResult(decks);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("CustomerController.Post() got error: " + ex.Message + ", Stack = " + ex.StackTrace);
                return StatusCode(500);
            }
        }
        [HttpDelete("[action]")]
        public IActionResult Delete(int deckId)
        {
            try
            {
                Console.WriteLine("ListingController.DeleteListing() deleting listing with ID " + deckId);

                using (DecksContext db = new DecksContext())
                {
                    // Check if listing exists
                    var listing = db.Decks.FirstOrDefault(x => x.DeckId == deckId);
                    if (listing == null)
                    {
                        return NotFound("Listing not found");
                    }

                    // Remove the listing from the database
                    db.Decks.Remove(listing);
                    db.SaveChanges();

                    // Return a confirmation message along with the OK status code
                    string message = "Deck with ID " + deckId + " has been deleted";
                    return new ObjectResult(message) { StatusCode = 200 };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ListingController.DeleteListing() got error: " + ex.Message + ", Stack = " + ex.StackTrace);
                return StatusCode(500);
            }
        }
    }
}
