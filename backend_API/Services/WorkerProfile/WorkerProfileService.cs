using backend_API.Data;
using backend_API.Models.WorkerProfile;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_API.Services.WorkerProfile
{
    public class WorkerProfileService : IWorkerProfileService
    {
        private readonly CCGToolsDbContext dbContext;

        public WorkerProfileService(CCGToolsDbContext context)
        {
            dbContext = context;
        }
       
        public async Task<bool> DeleteWorkerProfile(int id)
        {
            var workerProfile = await dbContext.WorkerProfile.FindAsync(id);

            if (workerProfile != null)
            {
                workerProfile.IsActive = false;
                await dbContext.SaveChangesAsync();

                await Task.Delay(1000);
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateWorkerProfile([FromRoute] int id, WorkerProfileRequest _workerProfile)
        {
            var workerProfile = await dbContext.WorkerProfile.FindAsync(id);
            if (workerProfile != null)
            {                
                workerProfile.Name = _workerProfile.Name;
                workerProfile.Code = _workerProfile.Code;
                workerProfile.UpdateBy = 1; // Dps aqui apanho o Id do user em caso ou admin
                workerProfile.UpdatedDate = DateTime.Now;
                
                await dbContext.SaveChangesAsync();

                await Task.Delay(1000);
                return true;
            }

            return false;
        }

        

        public async Task<bool> UpWorkerProfile([FromRoute] int id, WorkerProfileActivationRequest _workerProfile)
        {
            var workerProfile = await dbContext.WorkerProfile.FindAsync(id);
            if (workerProfile != null)
            {
                workerProfile.UpdateBy = 1; // Dps aqui apanho o Id do user em caso ou admin
                workerProfile.UpdatedDate = DateTime.Now;
                workerProfile.IsActive = !workerProfile.IsActive; // reverte o esta

                await dbContext.SaveChangesAsync();

                await Task.Delay(1000);
                return true;
            }

            return false;
        }
        
        public async Task<bool> PostWorkerProfile(WorkerProfilePost _workerProfilePost)
        {
            var workerProfile = new Data.WorkerProfile()
            {
                Name = _workerProfilePost.Name,
                Code = _workerProfilePost.Code,
                CreatedBy = _workerProfilePost.CreatedBy,
                CreatedDate = DateTime.Now,
                UpdateBy = null,
                UpdatedDate = null,
                IsActive = true
            };

            await dbContext.WorkerProfile.AddAsync(workerProfile);
            await dbContext.SaveChangesAsync();

            return true;
        }
        public async Task<WorkerProfileDTO> GetWorkerProfile(int id)
        {
            var workerProfile = await dbContext.WorkerProfile.FindAsync(id);

            if (workerProfile != null)
            {

                var dto = new WorkerProfileDTO()
                {
                    Id = workerProfile.Id,
                    Name = workerProfile.Name,
                    Code = workerProfile.Code,
                    IsActive = workerProfile.IsActive
                };

                return dto;
            }

            return null;
        }

        public async Task<List<WorkerProfileDTOasAdmin>> GetWorkerProfiles()
        {
            var workerProfiles = await dbContext.WorkerProfile.ToListAsync();

            if (workerProfiles != null)
            {
                var dtos = workerProfiles.Select(workerProfile => new WorkerProfileDTOasAdmin
                {
                    Id = workerProfile.Id,
                    Name = workerProfile.Name,
                    Code = workerProfile.Code,
                    CreatedBy = workerProfile.CreatedBy,
                    CreatedDate = workerProfile.CreatedDate,
                    UpdateBy = workerProfile.UpdateBy,
                    UpdatedDate = workerProfile.UpdatedDate,
                    IsActive = workerProfile.IsActive
                }).ToList();

                return dtos;
            }

            return null;
        }

    }
}

