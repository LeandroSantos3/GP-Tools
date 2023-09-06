namespace backend_API.Models.Activity
{
    public class ActivityDefaultResponse
    {       
            public int Code { get; set; }
            public string Description { get; set; }
            public int Id { get; set; }
            public List<ActivityDTO> Activities { get; set; } // Propriedade para armazenar a lista de atividades
            public List<string> Errors { get; set; }        

    }
}
