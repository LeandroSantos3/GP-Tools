using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace backend_API.Data
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }
        public int CreatedBy { get; set; } // RH{id}
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalHours { get; set; }

        [ForeignKey("Parent")]
        public int? ParentId { get; set; }
        public virtual Activity Parent { get; set; }
        public virtual ICollection<Activity> Child { get; set; }
        public virtual ICollection<ActivityWorkerProfile> TimesheetId { get; set; }

        [ForeignKey("ActivityCategory")]
        public int ActivityCategoryId { get; set; }

        [ForeignKey("ActivityCategoryState")]
        public int ActivityCategoryStateId { get; set; }

        //soft delete
        public bool IsActive { get; set; }
        public int? PreviousId { get; set; }

        [ForeignKey("Next")]
        public int? NextId { get; set; }
    }
}
