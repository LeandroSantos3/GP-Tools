using backend_API.Data;
using backend_API.Models.ActivityWorkerProfile;
using backend_API.Models.WorkerProfile;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_API.Services.ActivityWorkerProfile
{
    public class ActivityWorkerProfileService : IActivityWorkerProfileService
    {
        private readonly CCGToolsDbContext dbContext;

        public ActivityWorkerProfileService(CCGToolsDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public async Task<bool> DeleteActivityWorkerProfile(int id)
        {
            var activityWorkerProfile = await dbContext.ActivityWorkerProfile.FindAsync(id);

            if (activityWorkerProfile != null)
            {
                activityWorkerProfile.isAssociated = !activityWorkerProfile.isAssociated;
                activityWorkerProfile.UpdatedDate = DateTime.Now;
                //preciso da info do user para saber quem fez isso?

                await dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> PostActivityWorkerProfile(ActivityWorkerProfileRequest addActivityWorkerProfile)
        {
            var activityWorkerProfile = new Data.ActivityWorkerProfile()
            {

                ActivityId = addActivityWorkerProfile.ActivityId,
                WorkerProfileId = addActivityWorkerProfile.WorkerProfileId,
                CreatedBy = addActivityWorkerProfile.CreatedBy,
                CreatedDate = DateTime.Now,
                totalHours = addActivityWorkerProfile.totalHours,
                isAssociated = true,
            };

            await dbContext.ActivityWorkerProfile.AddAsync(activityWorkerProfile);
            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateActivityWorkerProfileHours(int id, ActivityWorkerProfileRequestHours putActivityWorkerProfile)
        {
            var activityWorkerProfile = await dbContext.ActivityWorkerProfile.FindAsync(id);
            if (activityWorkerProfile != null)
            {
                activityWorkerProfile.totalHours = putActivityWorkerProfile.totalHours;
                //buscar info do user e colocar aqui
                activityWorkerProfile.UpdatedDate = DateTime.Now;


                await dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<ActivityWorkerProfileDTO> GetActivityWorkerProfile(int id)
        {
            var activityWorkerProfile = await dbContext.ActivityWorkerProfile.FindAsync(id);

            if (activityWorkerProfile != null)
            {
                var dto = new ActivityWorkerProfileDTO
                {
                    Id = activityWorkerProfile.Id,
                    ActivityId = activityWorkerProfile.ActivityId,
                    WorkerProfileId = activityWorkerProfile.WorkerProfileId,
                    CreatedBy = activityWorkerProfile.CreatedBy,                    
                    CreatedDate = activityWorkerProfile.CreatedDate,
                    totalHours = activityWorkerProfile.totalHours,
                    UpdateBy = activityWorkerProfile.UpdateBy,
                    UpdatedDate = activityWorkerProfile.UpdatedDate,
                    isAssociated = activityWorkerProfile.isAssociated,
                    
                };

                return dto;
            }

            return null;
        }

        public Task<ActivityWorkerProfileDTO> GetActivityWorkerProfileInfo(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ActivityWorkerProfileDTO>> GetActivityWorkerProfiles()
        {
            var activityWorkerProfiles = await dbContext.ActivityWorkerProfile.ToListAsync();

            if (activityWorkerProfiles != null)
            {
                var dtos = activityWorkerProfiles.Select(workerProfile => new ActivityWorkerProfileDTO
                {
                    Id = workerProfile.Id,
                    WorkerProfileId = workerProfile.WorkerProfileId,
                    ActivityId = workerProfile.ActivityId,
                    CreatedBy = workerProfile.CreatedBy,
                    CreatedDate = workerProfile.CreatedDate,
                    totalHours= workerProfile.totalHours,
                    UpdateBy = workerProfile.UpdateBy,
                    UpdatedDate = workerProfile.UpdatedDate,
                    isAssociated = workerProfile.isAssociated,
                    
                }).ToList();

                return dtos;
            }

            return null;
        }
               
        public async Task<bool> UpdateActivityWorkerProfile(int id, ActivityWorkerProfileRequestPut putActivityWorkerProfile)
        {
            var activityWorkerProfile = await dbContext.ActivityWorkerProfile.FindAsync(id);
            if (activityWorkerProfile != null)
            {
                activityWorkerProfile.ActivityId = putActivityWorkerProfile.ActivityId;
                activityWorkerProfile.WorkerProfileId = putActivityWorkerProfile.WorkerProfileId;
                activityWorkerProfile.totalHours = putActivityWorkerProfile.totalHours;
                activityWorkerProfile.UpdateBy = putActivityWorkerProfile.UpdateBy;
                activityWorkerProfile.UpdatedDate = DateTime.Now;

                await dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

       
    }
}
