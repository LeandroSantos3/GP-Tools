using backend_API.Data;
using backend_API.Models.ActivityCategory;
using backend_API.Models.WorkerProfile;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_API.Services.ActivityCategory
{
    public class ActivityCategoryService : IActivityCategoryService
    {
        private readonly CCGToolsDbContext dbContext;
        public ActivityCategoryService(CCGToolsDbContext context)
        {
            dbContext = context;
        }
        public async Task<bool> DeleteActivityCategory(int id)
        {
            
            var activityCategory = await dbContext.ActivityCategory.FindAsync(id);

            if (activityCategory != null)
            {
                dbContext.Remove(activityCategory);
                await dbContext.SaveChangesAsync();

                return true;
            }

            return false;
            
        }

        public async Task<List<ActivityCategoryRequest>> GetActivityCategory()
        {
            var activityCategories = await dbContext.ActivityCategory.ToListAsync();

            if(activityCategories != null)
            {
                var dtos = activityCategories.Select(activityCategory => new ActivityCategoryRequest 
                {
                    Id = activityCategory.Id,
                    Name = activityCategory.Name,
                    CreatedBy = activityCategory.CreatedBy,
                    CreatedDate = activityCategory.CreatedDate,
                    UpdateBy = activityCategory.UpdateBy,
                    UpdatedDate = activityCategory.UpdatedDate

                }).ToList();
                
                return dtos;
            }
            return null;
        }

        public async Task<ActivityCategoryRequest> GetCategory(int id)
        {
            var category = await dbContext.ActivityCategory.FindAsync(id);

            if (category != null)
            {

                var dto = new ActivityCategoryRequest()
                {
                    Id = category.Id,
                    Name = category.Name,
                    CreatedBy= category.CreatedBy,
                    CreatedDate = category.CreatedDate,
                    UpdateBy = category.UpdateBy,
                    UpdatedDate = category.UpdatedDate

                };

                return dto;
            }

            return null;
        }

        public async Task<bool> PostActivityCategory(ActivityCategoryPost _activityCategory)
        {
            var activityCategory = new Data.ActivityCategory()
            {
                Name = _activityCategory.Name,
                CreatedBy = _activityCategory.CreatedBy,
                CreatedDate = DateTime.Now,
                UpdateBy = null,
                UpdatedDate = null,

            };

            await dbContext.ActivityCategory.AddAsync(activityCategory);
            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateActivityCategory(int id, ActivityCategoryRequestPut _activityCategoryRequestPut)
        {
            var activitycategory = await dbContext.ActivityCategory.FindAsync(id);
           
            if (activitycategory != null)
            {
                activitycategory.Name = _activityCategoryRequestPut.Name;
                activitycategory.CreatedBy = _activityCategoryRequestPut.CreatedBy;
                activitycategory.CreatedDate = _activityCategoryRequestPut.CreatedDate;
                activitycategory.UpdateBy = _activityCategoryRequestPut.UpdateBy;
                activitycategory.UpdatedDate = DateTime.Now;

                await dbContext.SaveChangesAsync();
                return true;
            }

            return false; //code status 404
        }
    }
}
