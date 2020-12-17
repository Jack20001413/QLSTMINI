using System.ComponentModel.DataAnnotations;

namespace Supermarket.ViewModel
{
    public class ChangePasswordViewModel
    {   
        public int Id { get; set; }
        
        [Required]
        public string OldPassword { get; set; }

        [Required]
        public string NewPassword { get; set; }

        [Required]
        public string ConfirmNewPassword { get; set; }
    }
}