namespace backend_API.Models.Activity
{
    public class ActivityRowMove
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public int? PreviousId { get; set; }
        public int? NextId { get; set; }

    }
}
