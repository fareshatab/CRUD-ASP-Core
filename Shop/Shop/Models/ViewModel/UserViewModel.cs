using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models.ViewModel
{
    public class UserViewModel
    {
        public String Id { get; set; }
        [Required]
        [EmailAddress]
        public String Email { get; set; }

        [PasswordPropertyText]
        public String Password { get; set; }
    }
}
