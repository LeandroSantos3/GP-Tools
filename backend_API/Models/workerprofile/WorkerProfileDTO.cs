using System.ComponentModel.DataAnnotations;
using backend_API.Data;

namespace backend_API.Models.WorkerProfile
{
    public class WorkerProfileDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";

        public int Code { get; set; }         
        public bool IsActive { get; set; }
      
    }
    
}
