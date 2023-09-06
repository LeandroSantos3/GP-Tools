using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace backend_API.Models.ActivityCategoryState
{
    public class ActivityCategoryStateRequest
    {
        public string Name { get; set; }
        public bool IsLocked { get; set; }
        public int CreatedBy { get; set; }

        [ForeignKey("ActivityCategory")]
        public int? ActivityCategoryId { get; set; }
    }
}
