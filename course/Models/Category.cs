using System.ComponentModel.DataAnnotations;

namespace course.Models
{
    public class Category
    {

        public int Id { get; set; }
        [Required(ErrorMessage ="Name cant be null")]
        public string Name { get; set; }
        [Required]
        public string ImageUrl { get; set; }

        public ICollection<Property> Properties{ get; set; }
    }
}
