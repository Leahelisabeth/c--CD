using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace TheWall.Models
{
    public class User : BaseEntity
    {
        [Key]
        public int id { get; set; }

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
        public ICollection<Message> messages { get; set; }
        public List<Comment> comments { get; set; }

        [Required]
        [CompareAttribute("Password", ErrorMessage = "Password and password confirm fields do not match")]
        public string ConfirmPw { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

    }

}