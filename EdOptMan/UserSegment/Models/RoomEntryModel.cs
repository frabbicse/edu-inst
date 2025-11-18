using System.ComponentModel.DataAnnotations;

namespace UserSegment.Models
{
    public class RoomEntryModel:BaseModel
    {
        [Required]
        public string RoomNumber { get; set; }

        public string RoomName { get; set; }

        [Required]
        public string RoomType { get; set; }

        [Required]
        public int BuildingId { get; set; }

        [Required]
        public string Floor { get; set; }

        [Required, Range(1, int.MaxValue)]
        public int Capacity { get; set; }

        [Range(0, double.MaxValue)]
        public double? Area { get; set; }

        [Required]
        public string Status { get; set; }

        public List<string> Facilities { get; set; }

        public string Description { get; set; }
    }
}
