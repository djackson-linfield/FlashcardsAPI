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
    [Route("api/tag")]
    public class TagController : Controller
    {
        [HttpGet("[action]")]
        public IActionResult Get()
        {

            try
            {
                Console.WriteLine("DecksController.GetDecks() fetching decks");

                List<Tag> tags = new List<Tag>();

                using (DecksContext db = new DecksContext())
                {

                    tags = db.Tags.ToList();

                    if (tags == null)
                    {
                        return new ObjectResult("No users to display.");
                    }

                    return new ObjectResult(tags);

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("UsersController.GetItems() got error: " + ex.Message + ", Stack = " + ex.StackTrace);
                return StatusCode(500);
            }
        }
        [HttpPost("[action]")]
        public IActionResult Post([FromBody] Tag newTag)
        {
            try
            {
                Console.WriteLine("posting new deck");
                using (DecksContext db = new DecksContext())
                {
                    Tag tag = new Tag();
                    tag.Name = newTag.Name;
                    db.Tags.Add(tag);
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
