using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ecommerce.Models
{
    public class UsersViewModel
    {
        [HiddenInput]
        public int? Id { get; set; }
        [Required(ErrorMessage = "Name is missing!")]
        public string Name { get; set; }
        public string Surname { get; set; }
        [RegularExpression(pattern: ".+\\@.+\\.[a-z]{2,3}", ErrorMessage = "Incorrect email format!")]
        [Required(ErrorMessage = "Email is missing or incorrect!")]
        public string Email { get; set; }
        [MinLength(length: 8, ErrorMessage = "Index number too short!")]
        [MaxLength(length: 10, ErrorMessage = "Index number too long!")]
        [Required(ErrorMessage = "Index number is missing!")]
        public string PhoneNumber { get; set; }
        public DateTime? Birth { get; set; }
    }
}
