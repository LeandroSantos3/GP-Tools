using System.ComponentModel.DataAnnotations.Schema;

namespace backend_API.Models.ActivityWorkerProfile
{
    public class ActivityWorkerProfileDTO
    {
        public int Id { get; set; }

        [ForeignKey("Activity")]
        public int ActivityId { get; set; }
        
        [ForeignKey("WorkerProfile")]
        public int WorkerProfileId { get; set; }

        public int CreatedBy { get; set; } // RH{id}

        public DateTime CreatedDate { get; set; }

        public int? totalHours { get; set; }

        public int? UpdateBy { get; set; } // RH{id}
        public DateTime? UpdatedDate { get; set; }

        public bool isAssociated {get; set; }

    }
}
