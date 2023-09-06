using MessagePack;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_API.Models.Activity
{
    public class ActivityDTO
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; } // RH{id}
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string Name { get; set; } = "";
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalHours { get; set; }

        [ForeignKey("Parent")]
        public int? ParentId { get; set; }

        [ForeignKey("ActivityCategory")]
        public int ActivityCategoryId { get; set; }

        [ForeignKey("ActivityCategoryState")]
        public int ActivityCategoryStateId { get; set; }
        public bool IsActive { get; set; }
        public List<ActivityDTO> Children { get; set; }
    }
}
