using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace UserSegment.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }        
        public DateTime CreateDate { get; set; } = DateTime.Now;        
        public string CreateBy { get; set; }
        
        public DateTime? UpdateDate { get; set; } = DateTime.Now;        
        public string? UpdateBy { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsPromoted { get; set; } = false;
    }
}
