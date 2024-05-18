using System.ComponentModel.DataAnnotations;

namespace Auction.Web.Models
{
    public class RegisterModel
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Login { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
    }
}
