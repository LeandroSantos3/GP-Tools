namespace backend_API.Models.ActivityCategory
{
    public class ActivityCategoryRequestPut
    {
        public string Name { get; set; }
        public int CreatedBy { get; set; } // RH{id}
        public DateTime CreatedDate { get; set; }
        public int? UpdateBy { get; set; }
    }
}
