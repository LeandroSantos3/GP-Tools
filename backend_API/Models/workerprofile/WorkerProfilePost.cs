using System.ComponentModel.DataAnnotations;

namespace backend_API.Models.WorkerProfile
{
    public class WorkerProfilePost
    {
        public string Name { get; set; } = "";
        public int Code { get; set; } // username ? 
        public int CreatedBy { get; set; } // RH{id}
        //public DateTime CreatedDate { get; set; } = DateTime.Now;
        //public int? UpdateBy { get; set; } = null;
        //public DateTime? UpdatedDate { get; set; } = null;
        //public bool IsActive { get; set; } = true;

        
    }
}
