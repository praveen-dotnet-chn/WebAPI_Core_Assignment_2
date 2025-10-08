using System.ComponentModel.DataAnnotations;

namespace WebAPI_Core_Assignment_2.Models
{

    public class Employee
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 30 characters.")]
        public string Name { get; set; }

        public string Department { get; set; }

        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Mobile number must be exactly 10 digits.")]
        public string MobileNo { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
    }

}

