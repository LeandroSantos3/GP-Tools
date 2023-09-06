using backend_API.Models.ActivityCategory;
using Microsoft.AspNetCore.Mvc;

namespace backend_API.Services.ActivityCategory
{
    public interface IActivityCategoryService
    {
        Task<ActivityCategoryRequest> GetCategory(int id);
        Task<List<ActivityCategoryRequest>> GetActivityCategory();
        Task<bool> PostActivityCategory(ActivityCategoryPost _activityCategory);
        Task<bool> UpdateActivityCategory(int id, ActivityCategoryRequestPut _activityCategoryRequestPut);
        Task<bool> DeleteActivityCategory(int id);
    }
}
