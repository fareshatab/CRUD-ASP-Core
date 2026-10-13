namespace Shop.Models.ViewModel
{
    public class UpdateProductViewModel
    {
        public int Id { get; set; }
        public String Describtion { get; set; }
        public String Name { get; set; }
        public int Price { get; set; }
        public String ImgURL { get; set; }
        public int CategoryId { get; set; }

    }
}
