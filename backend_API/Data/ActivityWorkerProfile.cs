using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace backend_API.Data
{
    public class ActivityWorkerProfile
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


//Apenas usar a propriedade de navegação "public WorkerProfile WorkerProfile { get; set; }"
//    é suficiente para mapear a relação n-n entre as entidades. Isso ocorre porque o Entity Framework 
//        é capaz de inferir a chave estrangeira a partir do nome da propriedade de navegação.
