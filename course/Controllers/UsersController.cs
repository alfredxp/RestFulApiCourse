using course.Data;
using course.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace course.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        ApiDbContext _db = new ApiDbContext();

        [HttpPost("[action]")]
        public IActionResult Register([FromBody] User user)
        {
            var userExists = _db.Users.FirstOrDefault(x => x.Email == user.Email);
            if(userExists!=null)
            {
                return BadRequest("User with same email already exists");
            }    
            _db.Users.Add(user);
            _db.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);


        }


    }
}
