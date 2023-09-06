using System.ComponentModel.DataAnnotations;
using backend_API.Data;

namespace backend_API.Models.WorkerProfile
{
    public class WorkerProfileDTOasAdmin
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int Code { get; set; } 
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdateBy { get; set; } 
        public DateTime? UpdatedDate { get; set; }
        public bool IsActive { get; set; }

    }

}
