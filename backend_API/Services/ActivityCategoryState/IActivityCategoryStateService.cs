using backend_API.Models.ActivityCategoryState;
using Microsoft.AspNetCore.Mvc;

namespace backend_API.Services.ActivityCategoryState
{
    public  interface IActivityCategoryStateService
    {
        Task<ActivityCategoryStateDTO> GetActivityCategoryState(int id);
        Task<List<ActivityCategoryStateDTO>> GetActivityCategoryStates();
        Task<bool> PostActivityCategoryState(ActivityCategoryStateRequest addActivityCategoryState);
        Task<bool> UpdateActivityCategoryState(int id, ActivityCategoryStatePutAll activityCategoryStateRequest);
        Task<bool> UpdateActivityCategoryStateAsActivityCategory(int id, ActivityCategoryStatePutAll activityCategoryStateRequest2);
        Task<bool> DeleteActivityCategoryState([FromRoute] int id);
        Task<List<ActivityCategoryStateDTO>> GetActivityCategoryStatesByCategoryId(int categoryId);





    }
}
