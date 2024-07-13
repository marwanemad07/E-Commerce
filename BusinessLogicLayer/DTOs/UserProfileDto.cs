using System.ComponentModel.DataAnnotations;

namespace E_Commerce.BLL.DTOs
{
    public class UserProfileDto
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string DisplayName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string City { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Region { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string ZipCode { get; set; }
    }
}
