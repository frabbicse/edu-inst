using System.ComponentModel.DataAnnotations;

namespace UserSegment.Models
{
    public class RegisterModel
    {
        // Personal Information
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Gender { get; set; }

        [Display(Name = "Blood Group")]
        public string BloodGroup { get; set; }

        // Contact Information
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Phone]
        [Display(Name = "Alternate Phone")]
        public string AlternatePhone { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        // Account Information
        [Required]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Role")]
        public string UserRole { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        // Profile Photo
        [Display(Name = "Profile Photo")]
        public IFormFile ProfilePhoto { get; set; }

        // Terms Agreement
        [Required]
        [Display(Name = "Agree to Terms")]
        public bool AgreeToTerms { get; set; }
    }
}