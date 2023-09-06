using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using backend_API.Data;
using backend_API.Models.Activity;
using backend_API.Models.ActivityWorkerProfile;
using backend_API.Services.ActivityWorkerProfile;

namespace backend_API.Controllers
{
    [ApiController]
    [Route("/ActivityWorkerProfile")]
    public class ActivityWorkerProfileController : Controller
    {
        private readonly IActivityWorkerProfileService activityWorkerProfileService;

        public ActivityWorkerProfileController(IActivityWorkerProfileService _activityWorkerProfileService)
        {
            activityWorkerProfileService = _activityWorkerProfileService;
        }

        [HttpGet]
        [Route("/ActivityWorkerProfile")]
        public async Task<IActionResult> GetActivityWorkerProfiles()
        {
            var result = await activityWorkerProfileService.GetActivityWorkerProfiles();

            if (result != null)
                return Ok(result);
            return NotFound();
        }

        //[HttpGet]
        //[Route("/ActivityWorkerProfile/Worker/{id}")]
        //public async Task<IActionResult> GetActivityWorkerProfile([FromRoute] int id)
        //{
        //    var workerProfile = await dbContext.ActivityWorkerProfile.FindAsync(id);

        //    if (workerProfile != null)
        //    {
        //        // Obter as atividades associadas ao perfil do trabalhador
        //        var activities = await dbContext.ActivityWorkerProfile
        //            .Where(aw => aw.WorkerProfileId == id)
        //            .Select(aw => aw.ActivityId)
        //            .ToListAsync();
               

        //        return Ok(activities);
        //    }

        //    return NotFound();
        //}

        [HttpGet]
        [Route("/ActivityWorkerProfile/{id}")]
        public async Task<IActionResult> GetActivityWorkerProfileInfo([FromRoute] int id)
        {
            var result = await activityWorkerProfileService.GetActivityWorkerProfile(id);

            if (result != null)
                return Ok(result);
            return NotFound();
        }

        [HttpPost]
        [Route("/ActivityWorkerProfile")]
        public async Task<IActionResult> PostActivityWorkerProfile(ActivityWorkerProfileRequest addActivityWorkerProfile)
        {
            bool IsSucess = await activityWorkerProfileService.PostActivityWorkerProfile(addActivityWorkerProfile);

            if (IsSucess)
            {
                var response = new DeafultResponse
                {
                    Description = "Success",
                };

                return Ok(response);
            }

            return NotFound();
        }

        [HttpPut]
        [Route("/ActivityWorkerProfile/allt/{id}")]
        public async Task<IActionResult> UpdateActivityWorkerProfile([FromRoute] int id, ActivityWorkerProfileRequestPut putActivityWorkerProfile)
        {
            bool IsSucess = await activityWorkerProfileService.UpdateActivityWorkerProfile(id, putActivityWorkerProfile);

            if (IsSucess)
            {
                return Ok(new DeafultResponse() { Description = "Sucess", Id = id });
            }
            return NotFound();

        }

        //[HttpPut]
        //[Route("ActivityWorkerProfile/Activity/{id}")]
        //public async Task<IActionResult> UpdateActivityWorkerProfileAsActivity([FromRoute] int id, ActivityWorkerProfileRequestAsActivity putActivityWorkerProfile)
        //{
        //    var activityWorkerProfile = await dbContext.ActivityWorkerProfile.FindAsync(id);
        //    if (activityWorkerProfile != null)
        //    {
        //        activityWorkerProfile.Id = putActivityWorkerProfile.Id;
        //        activityWorkerProfile.ActivityId = putActivityWorkerProfile.ActivityId;

        //        await dbContext.SaveChangesAsync();
        //        return Ok(activityWorkerProfile);
        //    }

        //    return NotFound(); //code status 404

        //}

        //[HttpPut]
        //[Route("ActivityWorkerProfile/WorkerProfile/{id}")]
        //public async Task<IActionResult> UpdateActivityWorkerProfileAsWorkerProfile([FromRoute] int id, ActivityWorkerProfileRequestAsWorkerProfile putActivityWorkerProfile)
        //{
        //    var activityWorkerProfile = await dbContext.ActivityWorkerProfile.FindAsync(id);
        //    if (activityWorkerProfile != null)
        //    {
        //        activityWorkerProfile.Id = putActivityWorkerProfile.Id;
        //        activityWorkerProfile.WorkerProfileId = putActivityWorkerProfile.WorkerProfileId;

        //        await dbContext.SaveChangesAsync();
        //        return Ok(activityWorkerProfile);
        //    }

        //    return NotFound(); //code status 404

        //}

        [HttpPut]
        [Route("ActivityWorkerProfile/Hours/{id}")]
        public async Task<IActionResult> UpdateActivityWorkerProfileHours([FromRoute] int id, ActivityWorkerProfileRequestHours putActivityWorkerProfile)
        {
            bool IsSucess = await activityWorkerProfileService.UpdateActivityWorkerProfileHours(id, putActivityWorkerProfile);

            if (IsSucess)
            {
                return Ok(new DeafultResponse() { Description = "Sucess", Id = id });
            }
            return NotFound();

        }

        //[HttpPut]
        //[Route("ActivityWorkerProfile/UpdateInfo/{id}")]
        //public async Task<IActionResult> UpdateActivityWorkerProfileUpdateInfo([FromRoute] int id, ActivityWorkerProfileRequestUpdateInfo putActivityWorkerProfile)
        //{
        //    var activityWorkerProfile = await dbContext.ActivityWorkerProfile.FindAsync(id);
        //    if (activityWorkerProfile != null)
        //    {
        //        activityWorkerProfile.Id = putActivityWorkerProfile.Id;
        //        activityWorkerProfile.UpdateBy = putActivityWorkerProfile.UpdateBy;
        //        activityWorkerProfile.UpdatedDate = putActivityWorkerProfile.UpdatedDate;

        //        await dbContext.SaveChangesAsync();
        //        return Ok(activityWorkerProfile);
        //    }

        //    return NotFound(); //code status 404

        //}

        [HttpDelete]
        [Route("/ActivityWorkerProfile/del/{id}")]

        public async Task<IActionResult> DeleteActivityWorkerProfile([FromRoute] int id)
        {
            bool IsSucess = await activityWorkerProfileService.DeleteActivityWorkerProfile(id);

            if (IsSucess)
            {
                return Ok(new DeafultResponse() { Description = "Sucess", Id = id });
            }
            return NotFound();
        }
    }
}
