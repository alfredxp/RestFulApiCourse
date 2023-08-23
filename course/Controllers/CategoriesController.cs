using Microsoft.AspNetCore.Mvc;
using course.Data;
using course.Models;

namespace course.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ApiDbContext _db = new ApiDbContext();
        // GET: api/<CategoriesController>
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _db.Categories;
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            var category = _db.Categories.FirstOrDefault(c => c.Id == id);
            return category;
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public void Post([FromBody] Category category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();

        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Category categorys)
        {
            var category = _db.Categories.Find(id);
            category.Name = categorys.Name;
            category.ImageUrl = categorys.ImageUrl;
            _db.SaveChanges();
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var category = _db.Categories.Find(id);
            _db.Categories.Remove(category);
            _db.SaveChanges();
        }
    }
}
