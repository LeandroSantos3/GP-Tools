using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace backend_API.Models.Activity
{
    public class ActivityRequest
    {
        public int CreatedBy { get; set; } // RH{id}
        public DateTime CreatedDate { get; set; }
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
    }
}
