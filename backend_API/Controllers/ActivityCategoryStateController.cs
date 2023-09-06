using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using backend_API.Data;
using backend_API.Models.ActivityCategoryState;
using backend_API.Services.WorkerProfile;
using backend_API.Services.ActivityCategoryState;

namespace backend_API.Controllers
{
    [ApiController]
    [Route("ActivityCategoryState")]
    public class ActivityCategoryStateController : Controller
    {
        private readonly IActivityCategoryStateService _activityCategoryStateService;

        public ActivityCategoryStateController(IActivityCategoryStateService activityCategoryStateService)
        {
            _activityCategoryStateService = activityCategoryStateService;
        }


        [HttpGet]
        [Route("/ActivityCategoryState")]
        public async Task<IActionResult> GetActivityCategoryStates()
        {
            var result = await _activityCategoryStateService.GetActivityCategoryStates();

            if(result != null) 
                  return Ok(result);
            return NotFound();
        }

        [HttpGet]
        [Route("/ActivityCategoryState/{id}")]
        public async Task<IActionResult> GetActivityCategoryState([FromRoute] int id)
        {
            var result = await _activityCategoryStateService.GetActivityCategoryState(id);

            if (result != null)
                return Ok(result);
            return NotFound();
        }

        [HttpGet]
        [Route("/ActivityCategoryStateByCategoryId/{id}")]
        public async Task<IActionResult> GetActivityCategoryStatesByCategoryId([FromRoute] int id)
        {
            var categoryStates = await _activityCategoryStateService.GetActivityCategoryStatesByCategoryId(id);

            if (categoryStates != null && categoryStates.Count > 0)
                return Ok(categoryStates);

            return NotFound();
        }



        [HttpPost]
        [Route("/ActivityCategoryState")]
        public async Task<IActionResult> PostActivityCategoryState(ActivityCategoryStateRequest _addActivityCategoryState)
        {
            bool IsSucess = await _activityCategoryStateService.PostActivityCategoryState(_addActivityCategoryState);

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
        [Route("/ActivityCategoryState/all/{id}")]
        public async Task<IActionResult> UpdateActivityCategoryState([FromRoute] int id, ActivityCategoryStatePutAll activityCategoryStateRequest)
        {
            bool IsSucess = await _activityCategoryStateService.UpdateActivityCategoryState(id, activityCategoryStateRequest);

            if (IsSucess)
            {
                return Ok(new DeafultResponse() { Description = "Sucess", Id = id });
            }
            return NotFound();

        }

        [HttpDelete]
        [Route("/ActivityCategoryState/del/{id}")]

        public async Task<IActionResult> DeleteActivityCategoryState([FromRoute] int id)
        {
            bool IsSucess = await _activityCategoryStateService.DeleteActivityCategoryState(id);

            if (IsSucess)
            {
                return Ok(new DeafultResponse() { Description = "Sucess", Id = id });
            }
            return NotFound();
        }

    }
}
