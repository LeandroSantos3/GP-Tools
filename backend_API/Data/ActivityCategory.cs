using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace backend_API.Data
{
    public class ActivityCategory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int CreatedBy { get; set; } // RH{id}
        public DateTime CreatedDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        
        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<ActivityCategoryState> ActivityCategoryStates { get; set; } // faz a ligação do lado 1
    }
}
