using System.ComponentModel.DataAnnotations;

namespace UserSegment.Models
{
    public class CourseEntryModel: BaseModel
    {
        [Required]
        [Display(Name = "Course Code")]
        public string CourseCode { get; set; }

        [Required]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        [Required]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        [Required]
        [Display(Name = "Course Type")]
        public string CourseType { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Credits must be at least 1")]
        public int Credits { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Duration must be at least 1 hour")]
        public int DurationHours { get; set; }

        [Required]
        [Display(Name = "Instructor")]
        public int InstructorId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Max students must be positive")]
        public int? MaxStudents { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public string Prerequisites { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public string Description { get; set; }

        public string LearningObjectives { get; set; }
    }
}
