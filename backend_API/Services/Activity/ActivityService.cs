using backend_API.Data;
using backend_API.Models.Activity;
using backend_API.Models.WorkerProfile;
using Microsoft.EntityFrameworkCore;

namespace backend_API.Services.Activity
{
    public class ActivityService : IActivityService
    {
        private readonly CCGToolsDbContext dbContext;

        public ActivityService(CCGToolsDbContext context)
        {
            this.dbContext = context;
        }
      
        public async Task<List<ActivityDTO>> GetActivities()
        {
            var activities = await dbContext.Activity.ToListAsync();

            if (activities != null)
            {
                var dtos = activities.Select(activity => new ActivityDTO
                {
                   Id = activity.Id,
                   Name = activity.Name,
                   Description = activity.Description,
                   CreatedBy = activity.CreatedBy,
                   CreatedDate = activity.CreatedDate,
                   ParentId = activity.ParentId,
                   ActivityCategoryId = activity.ActivityCategoryId,
                   ActivityCategoryStateId = activity.ActivityCategoryStateId,
                   StartDate = activity.StartDate,
                   EndDate = activity.EndDate,
                   TotalHours = activity.TotalHours,
                   UpdatedBy = activity.UpdatedBy,
                   UpdateDate = activity.UpdateDate,
                   IsActive = activity.IsActive,

                }).ToList();

                return dtos;
            }

            return null;
        }

        public async Task<bool> DeleteActivity(int id)
        {
            var activity = await dbContext.Activity.FindAsync(id);

            if (activity != null)
            {
                activity.IsActive = !activity.IsActive;
                activity.UpdateDate = DateTime.Now;

                await dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<ActivityDTO> GetActivity(int id)
        {
            var activity = await dbContext.Activity.FindAsync(id);

            if (activity != null)
            {
                var dto = new ActivityDTO
                {
                    Id = activity.Id,
                    Name = activity.Name,
                    Description = activity.Description,
                    CreatedBy = activity.CreatedBy,
                    CreatedDate = activity.CreatedDate,
                    ParentId = activity.ParentId,
                    ActivityCategoryId = activity.ActivityCategoryId,
                    ActivityCategoryStateId = activity.ActivityCategoryStateId,
                    StartDate = activity.StartDate,
                    EndDate = activity.EndDate,
                    TotalHours = activity.TotalHours,
                    UpdatedBy = activity.UpdatedBy,
                    UpdateDate = activity.UpdateDate,
                    IsActive = activity.IsActive,
                    //Children = children.Select(child => new ActivityDTO
                    //{
                    //    Id = child.Id,
                    //    Name = child.Name,
                    //    Description = child.Description,
                    //    CreatedBy = child.CreatedBy,
                    //    CreatedDate = child.CreatedDate,
                    //    ParentId = child.ParentId,
                    //    ActivityCategoryId = child.ActivityCategoryId,
                    //    ActivityCategoryStateId = child.ActivityCategoryStateId,
                    //    StartDate = child.StartDate,
                    //    EndDate = child.EndDate,
                    //    TotalHours = child.TotalHours,
                    //    UpdatedBy = child.UpdatedBy,
                    //    UpdateDate = child.UpdateDate,
                    //    IsActive = child.IsActive,
                    //}).ToList()


                };

                return dto;
            }

            return null;
        }

        public async Task<ActivityChildDTO> GetActivityChild(int id)
        {
            var activity = await dbContext.Activity.FindAsync(id);

            if (activity != null)
            {
                // Obter os filhos associados à atividade
                var children = await dbContext.Activity.Where(a => a.ParentId == id).ToListAsync();

                // Mappear a atividade para o DTO
                var dto = new ActivityChildDTO
                {
                    Id = activity.Id,
                    Name = activity.Name,
                    Description = activity.Description,
                    CreatedBy = activity.CreatedBy,
                    CreatedDate = activity.CreatedDate,
                    ParentId = activity.ParentId,
                    ActivityCategoryId = activity.ActivityCategoryId,
                    ActivityCategoryStateId = activity.ActivityCategoryStateId,
                    StartDate = activity.StartDate,
                    EndDate = activity.EndDate,
                    TotalHours = activity.TotalHours,
                    UpdatedBy = activity.UpdatedBy,
                    UpdateDate = activity.UpdateDate,
                    IsActive = activity.IsActive,
                    Children = children.Select(child => new ActivityDTO
                    {
                        Id = child.Id,
                        Name = child.Name,
                        Description = child.Description,
                        CreatedBy = child.CreatedBy,
                        CreatedDate = child.CreatedDate,
                        ParentId = child.ParentId,
                        ActivityCategoryId = child.ActivityCategoryId,
                        ActivityCategoryStateId = child.ActivityCategoryStateId,
                        StartDate = child.StartDate,
                        EndDate = child.EndDate,
                        TotalHours = child.TotalHours,
                        UpdatedBy = child.UpdatedBy,
                        UpdateDate = child.UpdateDate,
                        IsActive = child.IsActive,
                        Children = null, // o filho do filho nao entra aqui
                    }).ToList()
                };

                return dto;
            }

            return null;
        }




        public async Task<bool> PostActivity(ActivityRequest addActivity)
        {
            var activity = new Data.Activity()
            { 
                Name = addActivity.Name,
                Description = addActivity.Description,
                CreatedBy = addActivity.CreatedBy,
                CreatedDate = DateTime.Now,               
                StartDate = addActivity.StartDate,
                EndDate = addActivity.EndDate,
                TotalHours = addActivity.TotalHours,
                ParentId = addActivity.ParentId,
                ActivityCategoryId = addActivity.ActivityCategoryId,
                ActivityCategoryStateId = addActivity.ActivityCategoryStateId,
                IsActive = true,
            };

            await dbContext.Activity.AddAsync(activity);
            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateActivity(int id, ActivityRequestPut putActivity)
        {
            var activity = await dbContext.Activity.FindAsync(id);
            if (activity != null)
            {
                activity.CreatedBy = putActivity.CreatedBy;
                activity.UpdatedBy = putActivity.UpdatedBy;
                activity.UpdateDate = DateTime.Now;
                activity.Name = putActivity.Name;
                activity.Description = putActivity.Description;
                activity.StartDate = putActivity.StartDate;
                activity.EndDate = putActivity.EndDate;
                activity.TotalHours = putActivity.TotalHours;
                activity.ParentId = putActivity.ParentId;
                activity.ActivityCategoryId = putActivity.ActivityCategoryId;
                activity.ActivityCategoryStateId = putActivity.ActivityCategoryStateId;


                await dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateActivityRow(int id, ActivityRowMove rowMove)
        {
            var activity = await dbContext.Activity.FindAsync(id);
            if (activity == null)
            {
                return false;
            }

            // Update the activity row based on the provided information
            activity.ParentId = rowMove.ParentId;
            activity.PreviousId = rowMove.PreviousId;
            activity.NextId = rowMove.NextId;

            // Save the changes to the database
            await dbContext.SaveChangesAsync();

            return true;
        }
    }
}
