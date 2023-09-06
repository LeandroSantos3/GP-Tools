using backend_API.Data;
using backend_API.Models.ActivityCategoryState;
using backend_API.Models.WorkerProfile;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_API.Services.ActivityCategoryState
{
    public class ActivityCategoryStateService : IActivityCategoryStateService
    {

        private readonly CCGToolsDbContext dbContext;

        public ActivityCategoryStateService(CCGToolsDbContext context)
        {
            dbContext = context;
        }

        public async Task<bool> DeleteActivityCategoryState([FromRoute] int id)
        {
            var activityCategoryState = await dbContext.ActivityCategoryState.FindAsync(id);

            if (activityCategoryState != null)
            {
                activityCategoryState.IsLocked = !activityCategoryState.IsLocked;
                activityCategoryState.UpdatedDate = DateTime.Now;
                //puchar aqui o perfil do user
                await dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<ActivityCategoryStateDTO> GetActivityCategoryState(int id)
        {
            var categoryState = await dbContext.ActivityCategoryState.FindAsync(id);

            if (categoryState != null)
            {

                var dto = new ActivityCategoryStateDTO()
                {
                    Id = categoryState.Id,
                    Name = categoryState.Name,
                    ActivityCategoryId = categoryState.ActivityCategoryId,
                    CreatedBy = categoryState.CreatedBy,
                    CreatedDate = categoryState.CreatedDate,
                    IsLocked = categoryState.IsLocked,
                    UpdateBy = categoryState.UpdateBy,
                    UpdatedDate = categoryState.UpdatedDate
                };

                return dto;
            }

            return null;
        }

        public async Task<List<ActivityCategoryStateDTO>> GetActivityCategoryStatesByCategoryId(int categoryId)
        {
            var categoryStates = await dbContext.ActivityCategoryState
                .Where(state => state.ActivityCategoryId == categoryId)
                .ToListAsync();

            if (categoryStates != null && categoryStates.Count > 0)
            {
                var dtos = categoryStates.Select(categoryState => new ActivityCategoryStateDTO()
                {
                    Id = categoryState.Id,
                    Name = categoryState.Name,
                    ActivityCategoryId = categoryState.ActivityCategoryId,
                    CreatedBy = categoryState.CreatedBy,
                    CreatedDate = categoryState.CreatedDate,
                    IsLocked = categoryState.IsLocked,
                    UpdateBy = categoryState.UpdateBy,
                    UpdatedDate = categoryState.UpdatedDate
                }).ToList();

                return dtos;
            }

            return null;
        }


        public async Task<List<ActivityCategoryStateDTO>> GetActivityCategoryStates()
        {
            var categoryState = await dbContext.ActivityCategoryState.ToListAsync();

            if(categoryState != null) 
            {
                var dtos = categoryState.Select(categoryState => new ActivityCategoryStateDTO
                {
                    Id = categoryState.Id,
                    Name = categoryState.Name,
                    IsLocked = categoryState.IsLocked,
                    CreatedBy = categoryState.CreatedBy,
                    CreatedDate = categoryState.CreatedDate,
                    UpdateBy = categoryState.UpdateBy,
                    UpdatedDate = categoryState.UpdatedDate,
                    ActivityCategoryId = categoryState.ActivityCategoryId,

                }).ToList();
              
                return dtos;      
            }
            return null;
        }

        public async Task<bool> PostActivityCategoryState(ActivityCategoryStateRequest addActivityCategoryState)
        {
            var activityCategoryState = new Data.ActivityCategoryState()
            {
                
                Name = addActivityCategoryState.Name,
                IsLocked = true,
                CreatedBy = addActivityCategoryState.CreatedBy,
                CreatedDate = DateTime.Now,
                ActivityCategoryId = addActivityCategoryState.ActivityCategoryId
            };

            await dbContext.ActivityCategoryState.AddAsync(activityCategoryState);
            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateActivityCategoryState(int id, ActivityCategoryStatePutAll activityCategoryStateRequest)
        {
            var activitycategorystate = await dbContext.ActivityCategoryState.FindAsync(id);
            if (activitycategorystate != null)
            {
                activitycategorystate.Name = activityCategoryStateRequest.Name;
                activitycategorystate.IsLocked = activityCategoryStateRequest.IsLocked;
                activitycategorystate.CreatedBy = activityCategoryStateRequest.CreatedBy;
                activitycategorystate.UpdateBy = activityCategoryStateRequest.UpdateBy;
                activitycategorystate.UpdatedDate = DateTime.Now;
                activitycategorystate.ActivityCategoryId = activityCategoryStateRequest.ActivityCategoryId;

                await dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public Task<bool> UpdateActivityCategoryStateAsActivityCategory(int id, ActivityCategoryStatePutAll activityCategoryStateRequest2)
        {
            //Nao será necessario, prq o PUT no UI faz isso...
            throw new NotImplementedException();
        }
    }
}

