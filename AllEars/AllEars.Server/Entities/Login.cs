using Microsoft.AspNetCore.Cors;
using System.ComponentModel.DataAnnotations;



namespace AllEars.Server.Entities
{
    public class Login
    {
      

        [Required(ErrorMessage = "User Name is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

       
    }
}
