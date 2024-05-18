using System.ComponentModel.DataAnnotations;

namespace Auction.Web.Models
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public string Login { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
    }
}
