using System.ComponentModel.DataAnnotations;

namespace UserSegment.Models
{
    public class TeacherEntryModel
    {
        // 🧍 Personal Info
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required, DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }

        // ☎️ Contact Info
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, Phone]
        public string PhoneNumber { get; set; }
        public string AlternatePhone { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string ZipCode { get; set; }

        // 🎓 Professional Info
        [Required]
        public string TeacherId { get; set; }
        [Required, DataType(DataType.Date)]
        public DateTime JoinDate { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        public string Designation { get; set; }
        [Required]
        public string Qualification { get; set; }
        [Required]
        public int ExperienceYears { get; set; }
        public string Specialization { get; set; }
        [Required]
        public string[] Subjects { get; set; }

        // 💰 Salary & Benefits
        [Required]
        public decimal BasicSalary { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }

        // 🩸 Additional Info
        public string EmergencyContactName { get; set; }
        public string EmergencyContactNumber { get; set; }
        public string BloodGroup { get; set; }
        public string Notes { get; set; }

        // 📷 Profile Photo
        public IFormFile ProfilePhoto { get; set; }
    }
}
