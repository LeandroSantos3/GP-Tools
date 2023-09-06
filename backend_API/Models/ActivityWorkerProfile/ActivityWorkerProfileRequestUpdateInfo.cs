using System.ComponentModel.DataAnnotations.Schema;

namespace backend_API.Models.ActivityWorkerProfile
{
    public class ActivityWorkerProfileRequestUpdateInfo
    {
        public int Id { get; set; }       
        public int? UpdateBy { get; set; } // RH{id}
        public DateTime? UpdatedDate { get; set; }
    }
}
