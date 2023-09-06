using System.ComponentModel.DataAnnotations.Schema;

namespace backend_API.Models.ActivityCategoryState
{
    public class ActivityCategoryStateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsLocked { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        [ForeignKey("ActivityCategory")]
        public int? ActivityCategoryId { get; set; }
    }
}
