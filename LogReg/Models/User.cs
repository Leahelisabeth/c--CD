using System.ComponentModel.DataAnnotations;
namespace LogReg.Models
{
    public class User
    {
        [Required]
        [MinLengthAttribute(2, ErrorMessage = "Nope")]
        public string FirstName { get; set; }

        [Required]
        [MinLengthAttribute(2)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [CompareAttribute("Password", ErrorMessage = "Password and password confirm fields do not match")]
        public string ConfirmPw { get; set; }

    }

}