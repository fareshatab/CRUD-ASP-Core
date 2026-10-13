using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class Product : BaseEntity
    {
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        public String Describtion { get; set; }
        public int Price { get; set; }
        [Required]
        public String ImgURL { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }


    }
}
