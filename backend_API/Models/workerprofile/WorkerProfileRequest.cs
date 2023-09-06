using System.ComponentModel.DataAnnotations;

namespace backend_API.Models.WorkerProfile
{
    public class WorkerProfileRequest
    {
        //[Key]
        //public int Id { get; set; }
        public string Name { get; set; } = "";

        public int Code { get; set; } // username ? 

        //public int CreatedBy { get; set; } // RH{id}

        //public DateTime CreatedDate { get; set; }

        //public int? UpdateBy { get; set; }
        //public DateTime? UpdatedDate { get; set; }
        //public bool IsActive { get; set; }

    }
}
