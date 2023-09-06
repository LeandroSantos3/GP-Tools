using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace backend_API.Models.ActivityCategoryState
{
    public class ActivityCategoryStateRequest2
    {
        public int Id { get; set; }
        
        [ForeignKey("ActivityCategory")]
        public int? ActivityCategoryId { get; set; }

    }
}
