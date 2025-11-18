using System.ComponentModel.DataAnnotations;

namespace UserSegment.Models
{
    public class StudentEntryModel
    {
        // 🔹 Personal Information
        [Required, Display(Name = "First Name")]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required, Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required, DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Gender { get; set; }

        public string BloodGroup { get; set; }

        // 🔹 Contact Information
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Phone]
        public string AlternatePhone { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        // 🔹 Academic Information
        [Required, Display(Name = "Student ID")]
        public string StudentId { get; set; }

        [Required, DataType(DataType.Date)]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }

        [Required, Display(Name = "Class/Grade")]
        public int ClassId { get; set; }

        public string Section { get; set; }

        public string RollNumber { get; set; }

        public string PreviousSchool { get; set; }

        // 🔹 Parent/Guardian Information
        [Required, Display(Name = "Father's Name")]
        public string FatherName { get; set; }

        public string FatherOccupation { get; set; }

        [Required, Phone]
        [Display(Name = "Father's Phone")]
        public string FatherPhone { get; set; }

        [Required, Display(Name = "Mother's Name")]
        public string MotherName { get; set; }

        public string MotherOccupation { get; set; }

        [Phone]
        [Display(Name = "Mother's Phone")]
        public string MotherPhone { get; set; }

        [Phone]
        [Display(Name = "Emergency Contact")]
        public string EmergencyContact { get; set; }

        // 🔹 Profile Photo
        [Display(Name = "Profile Photo")]
        public IFormFile? ProfilePhoto { get; set; }

        public string? ProfilePhotoPath { get; set; }
    }
}
