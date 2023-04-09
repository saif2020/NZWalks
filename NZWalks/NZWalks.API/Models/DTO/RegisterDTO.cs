using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "Person Name can not be blank")]
        public string PersonName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Email can not be blank")]
        [EmailAddress(ErrorMessage = "Email should be in a proper email address format")]
        [Remote(action: "IsEmailAlreadyRegistered", controller: "Account", ErrorMessage = "Email is already used")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email can not be blank")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone number should contain digits only")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password can not be blank")]
        public string Password { get; set; } = string.Empty;
        [Required(ErrorMessage = "Confirm password can not be blank")]
        [Compare("Password", ErrorMessage = "Confirm password can not be blank")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
