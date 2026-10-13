using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class Category : BaseEntity
    {
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        public List<Product>? Products { get; set; }



    }
}
