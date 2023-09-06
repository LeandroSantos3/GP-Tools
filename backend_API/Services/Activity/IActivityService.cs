using backend_API.Models.Activity;
using Microsoft.AspNetCore.Mvc;

namespace backend_API.Services.Activity
{
    public interface IActivityService
    {
        Task<ActivityDTO> GetActivity(int id);
        Task<List<ActivityDTO>> GetActivities();
        Task<ActivityChildDTO> GetActivityChild(int id);
        Task<bool> PostActivity(ActivityRequest addActivity);
        Task<bool> UpdateActivity(int id, ActivityRequestPut putActivity);
        Task<bool> DeleteActivity(int id);
        Task<bool> UpdateActivityRow(int id, ActivityRowMove rowMove);



    }
}
