using Decks.Data;
using Decks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Decks.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {

        [HttpPost("[action]")]
        public IActionResult Post([FromBody] User value)
        {
            try
            {
                Console.WriteLine("UserController.Post() posting a new item");

                using (DecksContext db = new DecksContext()) // Used for creating a new user
                {
                    if (String.IsNullOrWhiteSpace(value.Name))
                    {
                        return BadRequest("Missing username");
                    }
                    if (String.IsNullOrWhiteSpace(value.Password))
                    {
                        return BadRequest("Missing password");
                    }
                    if (db.Users.FirstOrDefault(x => x.Name == value.Name && x.Password == value.Password) == null)
                    {
                        return NotFound("Invalid username or password");
                    }

                    return new OkResult();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("CustomerController.Post() got error: " + ex.Message + ", Stack = " + ex.StackTrace);
                return StatusCode(500);
            }
        }
        [HttpGet("[action]")]
        public IActionResult GetUsers()
        {

            try
            {
                Console.WriteLine("UserController.GetItems() fetching user");

                List<User> users = new List<User>();

                using (DecksContext db = new DecksContext())
                {

                    users = db.Users.ToList();

                    if (users == null)
                    {
                        return new ObjectResult("No users to display.");
                    }

                    return new ObjectResult(users);

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("UsersController.GetItems() got error: " + ex.Message + ", Stack = " + ex.StackTrace);
                return StatusCode(500);
            }
        }
    }
}
