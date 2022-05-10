using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace CollectionSite.Models
{
    public class SignInViewModel
    {
        [DataType(DataType.EmailAddress,ErrorMessage = "It's not valid Email")]
        [Display(Name = "Почта")]
        [Required]
        public string? Email { get; set; }

        public bool IsPersistent { get; set; }

        [DataType(DataType.Password, ErrorMessage = "It's not valid Password")]
        [Display(Name = "Пароль")]
        [Required]
        public string? Password { get; set; }
    }
}
