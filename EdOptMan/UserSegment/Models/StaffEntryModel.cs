using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserSegment.Models
{
    public class StaffEntryModel : BaseModel
    {
        // 🔹 Personal Information
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

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

        public string BloodGroup { get; set; }

        // 🔹 Contact Information
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Phone]
        [Display(Name = "Emergency Contact")]
        public string EmergencyContact { get; set; }

        [Required]
        public string Address { get; set; }

        // 🔹 Employment Information
        [Required]
        [Display(Name = "Staff ID")]
        public string StaffId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Join Date")]
        public DateTime JoinDate { get; set; }

        [Required]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        [Required]
        public string Designation { get; set; }

        [Required]
        [Display(Name = "Employment Type")]
        public string EmploymentType { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive value")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Salary { get; set; }
    }
}
