using course.Data;
using course.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace course.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        ApiDbContext _db = new ApiDbContext();

        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] Property property)
        {
            if (property == null)
            {
                return NoContent();
            }
            else
            {
                var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
                var user = _db.Users.First(i => i.Email == userEmail);
                if(user == null)
                {
                    return NotFound();
                }
                property.IsTrending = false;
                property.UserId = user.Id;
                _db.Properties.Add(property);
                _db.SaveChanges();
                return new ObjectResult(property) { StatusCode = StatusCodes.Status201Created };
            }


        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] Property property)
        {
            var propertyResult = _db.Properties.FirstOrDefault(p => p.Id == id);
            if (property == null)
            {
                return NoContent();
            }
            else
            {
                var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
                var user = _db.Users.First(i => i.Email == userEmail);
                if (user == null)
                {
                    return NotFound();
                }
                propertyResult.Name = property.Name;
                propertyResult.Detail = property.Detail;
                propertyResult.Price = property.Price;
                propertyResult.Address = property.Address;
                property.IsTrending = false;
                property.UserId = user.Id;
                _db.SaveChanges();
                return new ObjectResult(property) { StatusCode = StatusCodes.Status200OK };
            }


        }



    }
}
