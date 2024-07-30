namespace E_Commerce.BLL.DTOs
{
    public class ChangePasswordDto
    {
        [Required]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\W).{8,}$")]
        public string OldPassword { get; set; }
        [Required]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\W).{8,}$")]
        public string NewPassword { get; set; }
    }
}
