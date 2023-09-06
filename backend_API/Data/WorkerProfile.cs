using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace backend_API.Data
{
    public class WorkerProfile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; } // role ?

        public int Code { get; set; } // username ? 

        public int CreatedBy { get; set; } // RH{id}

        public DateTime CreatedDate { get; set; }

        public int? UpdateBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsActive { get; set; } = true;
        public virtual ICollection<ActivityWorkerProfile> ActivityWorkers { get; set; }


    }
}
