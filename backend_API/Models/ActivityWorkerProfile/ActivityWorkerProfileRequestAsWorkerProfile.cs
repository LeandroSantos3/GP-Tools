using System.ComponentModel.DataAnnotations.Schema;

namespace backend_API.Models.ActivityWorkerProfile
{
    public class ActivityWorkerProfileRequestAsWorkerProfile
    {
        public int Id { get; set; }

        [ForeignKey("WorkerProfile")]
        public int WorkerProfileId { get; set; }

    }
}
