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

        [HttpGet("PropertyList")]
        [Authorize]
        public IActionResult GetProperties(int categoryId)
        {
            var propertiesResult = _db.Properties.Where(c => c.CategoryId == categoryId);
            if(propertiesResult==null){
                return NotFound(); }

            return Ok(propertiesResult);
        }

        [HttpGet("PropertyDetail")]
        [Authorize]
        public IActionResult GetPropertyDetail(int id)
        {
            var propertiesResult = _db.Properties.FirstOrDefault(c => c.Id == id);
            if (propertiesResult == null)
            {
                return NotFound();
            }

            return Ok(propertiesResult);
        }


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
                if (user == null)
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
                if (propertyResult.UserId == user.Id)
                {
                    propertyResult.Name = property.Name;
                    propertyResult.Detail = property.Detail;
                    propertyResult.Price = property.Price;
                    propertyResult.Address = property.Address;
                    property.IsTrending = false;
                    property.UserId = user.Id;
                    _db.SaveChanges();
                    return new ObjectResult(property) { StatusCode = StatusCodes.Status200OK };
                }
                return BadRequest();
            }


        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            var propertyResult = _db.Properties.FirstOrDefault(p => p.Id == id);
            if (propertyResult == null)
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
                if (propertyResult.UserId == user.Id)
                {
                   _db.Properties.Remove(propertyResult);
                    _db.SaveChanges();
                    return new ObjectResult("") { StatusCode = StatusCodes.Status200OK };
                }
                return BadRequest();
            }


        }


    }
}
