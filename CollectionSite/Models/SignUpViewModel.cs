using System.ComponentModel.DataAnnotations;

namespace CollectionSite.Models
{
    public class SignUpViewModel
    {
        [DataType(DataType.Text)]
        [Display(Name = "Имя")]
        [Required]
        public string? Name { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "It's not valid Email")]
        [Display(Name = "Почта")]
        [Required]
        public string? Email { get; set; }

        [DataType(DataType.Password, ErrorMessage = "It's not valid Password")]
        [Display(Name = "Пароль")]
        [Required]
        public string? Password { get; set; }

        [DataType(DataType.Password, ErrorMessage = "It's not valid Password")]
        [Display(Name = "Пароль")]
        [Required]
        [Compare(nameof(Password), ErrorMessage = "Your passwords must be the same")]
        public string? ConfirmPassword { get; set; }

       
    }
}
