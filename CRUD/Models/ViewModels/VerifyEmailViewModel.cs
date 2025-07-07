using System.ComponentModel.DataAnnotations;

namespace CRUD.Models.ViewModels
{
    public class VerifyEmailViewModel
    {
        [Required(ErrorMessage = "Email message cannot be empty")]
        [EmailAddress]
        public string? Email { get; set; }

    }
}
