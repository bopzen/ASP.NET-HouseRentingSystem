using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Data.DataConstraints.Category;

namespace HouseRentingSystem.Data.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(CategoryNameMaxLength)]
        public string Name { get; set; } = null!;

        public IEnumerable<House> Houses { get; set; } = new List<House>();
    }
}
