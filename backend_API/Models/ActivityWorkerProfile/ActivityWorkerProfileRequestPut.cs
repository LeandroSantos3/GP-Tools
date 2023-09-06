using System.ComponentModel.DataAnnotations.Schema;

namespace backend_API.Models.ActivityWorkerProfile
{
    public class ActivityWorkerProfileRequestPut
    {
        [ForeignKey("Activity")]
        public int ActivityId { get; set; }
        [ForeignKey("WorkerProfile")]
        public int WorkerProfileId { get; set; }
        public int UpdateBy { get; set; }
        public int? totalHours { get; set; }
    }
}

