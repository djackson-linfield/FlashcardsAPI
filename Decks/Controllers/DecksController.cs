﻿using System;
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
                    db.Decks.Add(newDeck);
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
    }
}
