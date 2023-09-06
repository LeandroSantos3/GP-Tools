namespace backend_API.Models.ActivityCategory
{
    public class ActivityCategoryRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CreatedBy { get; set; } // RH{id}
        public DateTime CreatedDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
