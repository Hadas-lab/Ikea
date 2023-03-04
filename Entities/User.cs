using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class User
    {
        public int Id { get;set;}

        [EmailAddress(ErrorMessage = "Email not valid")]
        public string Email { get; set; }

        [StringLength(20, ErrorMessage = "Password length must be between 8 to 20", MinimumLength = 8)]
        public string Password { get; set; }
        
        public string? FirstName { get; set; }
        
        public string? LastName { get; set; }

    }


}
