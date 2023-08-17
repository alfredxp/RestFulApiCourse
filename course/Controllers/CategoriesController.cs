using course.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace course.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private List<Category> categories = new List<Category>()
        {
            new Category()
            {
                Id = 0,
                Name = "Apartment",
                ImageUrl = "appartment.png"
            }
        };
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return categories;
        }


    }
}
