using System.ComponentModel.DataAnnotations.Schema;

namespace backend_API.Models.ActivityWorkerProfile
{
    public class ActivityWorkerProfileRequestAsActivity
    {
        public int Id { get; set; }

        [ForeignKey("Activity")]
        public int ActivityId { get; set; }
        
    }
}
