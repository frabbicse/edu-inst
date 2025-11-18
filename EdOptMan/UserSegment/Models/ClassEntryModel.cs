using System.ComponentModel.DataAnnotations;

namespace UserSegment.Models
{
    public class ClassEntryModel: BaseModel
    {
        [Required]
        [Display(Name = "Class Name")]
        public string ClassName { get; set; }

        [Required]
        public string Section { get; set; }

        [Required]
        [Display(Name = "Class Teacher")]
        public int ClassTeacherId { get; set; }

        [Required]
        [Display(Name = "Room Number")]
        public int RoomId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Capacity must be at least 1")]
        public int Capacity { get; set; }

        [Required]
        [Display(Name = "Academic Year")]
        public string AcademicYear { get; set; }

        public string Schedule { get; set; }

        public string Description { get; set; }
    }
}
