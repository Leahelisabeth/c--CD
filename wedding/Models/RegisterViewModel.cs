using System.ComponentModel.DataAnnotations;
namespace wedding.Models
{
    public class RegisterViewModel : BaseEntity
    {
        [Required]
        [MinLength(2, ErrorMessage="First Name field must be minimum of two characters")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage="First Name cannnot contain numerical or special characters")]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage="Last Name cannnot contain numerical or special characters")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", ErrorMessage="Email address must be valid")]

        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=(.*[a-zA-Z].*){2,})(?=.*\d.*)(?=.*\W.*)[a-zA-Z0-9\S]{8,15}$",  ErrorMessage="Password must contain at least two letters, one special charcter, one number and no spaces")]
        //Strong passwords with min 8 - max 15 character length, 
        //at least two letters (not case sensitive), one number, 
        //one special character (all, not just defined), space is not allowed.
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password and confirmation must match.")]
        public string pwc { get; set; }
    }
}