using backend_API.Models.WorkerProfile;
using Microsoft.AspNetCore.Mvc;

namespace backend_API.Services.WorkerProfile
{
    public interface IWorkerProfileService
    {
        Task<WorkerProfileDTO> GetWorkerProfile(int id);
        Task<List<WorkerProfileDTOasAdmin>> GetWorkerProfiles();
        Task<bool> PostWorkerProfile(WorkerProfilePost _workerProfilePost);
        Task<bool> UpWorkerProfile(int id, WorkerProfileActivationRequest _workerProfileRequest);
        Task<bool> UpdateWorkerProfile(int id, WorkerProfileRequest _workerProfileRequest);
        Task<bool> DeleteWorkerProfile(int id);

    }
}
