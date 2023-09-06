using backend_API.Models.ActivityWorkerProfile;
using Microsoft.AspNetCore.Mvc;

namespace backend_API.Services.ActivityWorkerProfile
{
    public interface IActivityWorkerProfileService
    {
        Task<List<ActivityWorkerProfileDTO>> GetActivityWorkerProfiles();
        Task<ActivityWorkerProfileDTO> GetActivityWorkerProfile(int id);
        Task<ActivityWorkerProfileDTO> GetActivityWorkerProfileInfo(int id);
        Task<bool> PostActivityWorkerProfile(ActivityWorkerProfileRequest addActivityWorkerProfile);
        Task<bool> UpdateActivityWorkerProfile(int id, ActivityWorkerProfileRequestPut putActivityWorkerProfile);
        Task<bool> UpdateActivityWorkerProfileHours(int id, ActivityWorkerProfileRequestHours putActivityWorkerProfile);
        Task<bool> DeleteActivityWorkerProfile(int id);

    }
}
