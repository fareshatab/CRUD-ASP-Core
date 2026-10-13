namespace Shop.Models
{
    public class BaseEntity
    {
        public String? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public String? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDelete { get; set; }


    }
}
