using System.ComponentModel.DataAnnotations;

namespace WebAPI_Core_Assignment_2.Models
{

    public class Employee
    {
        //Giving Data Annotation, so this field cannot be skipped at the client side while posting the details
        [Required]
        public int Id { get; set; }

        [Required]
        
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 30 characters.")]
        public string Name { get; set; }

        public string Department { get; set; }

        [Required]
        //Then entered mobile number must be a digit, so Regex will help us to achive that
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Mobile number must be exactly 10 digits.")]
        public string MobileNo { get; set; }

        [Required]
        //This dataAnnotation enable the user to enter the proper email address
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
    }

}

