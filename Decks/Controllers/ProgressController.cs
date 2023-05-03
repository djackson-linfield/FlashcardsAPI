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
    [Route("api/progress")]
    public class ProgressController : Controller
    {
        [HttpGet("[action]")]
        public IActionResult Get()
        {

            try
            {
                Console.WriteLine("DecksController.GetDecks() fetching decks");

                List<Progress> progress = new List<Progress>();

                using (DecksContext db = new DecksContext())
                {

                    progress = db.Progresses.ToList();

                    if (progress == null)
                    {
                        return new ObjectResult("No users to display.");
                    }

                    return new ObjectResult(progress);

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("UsersController.GetItems() got error: " + ex.Message + ", Stack = " + ex.StackTrace);
                return StatusCode(500);
            }
        }

        [HttpPut("[action]")]
        public IActionResult Put([FromBody] Progress value)
        {

            using (DecksContext db = new DecksContext())
            {
                var progress = db.Progresses
                        .Where(p => p.ProgressId == value.ProgressId)
                        .Select(p => new { Progress = p })
                        .FirstOrDefault();
                if (progress == null) return StatusCode(500);
                progress.Progress.CardsStudied = value.CardsStudied;
                progress.Progress.CardsMastered = value.CardsMastered;
                db.SaveChanges();
                return Ok();
            }
        }
    }
}
