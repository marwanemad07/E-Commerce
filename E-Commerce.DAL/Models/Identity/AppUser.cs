
namespace E_Commerce.DAL.Models.Identity
{
    public class AppUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string DisplayName { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Region { get; set; }
        [Required]
        public string ZipCode { get; set; }
    }
}
