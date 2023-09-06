using backend_API.Data;
using backend_API.Models.Activity;
using backend_API.Services.Activity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_API.Controllers
{
    [ApiController]
    [Route("Activity")]
    public class ActivityController : Controller
    {
        private readonly IActivityService _activityService; 
        public ActivityController(IActivityService activityService)
        {
            this._activityService = activityService;
        }


        [HttpGet]
        [Route("/Activity/all")]
        public async Task<IActionResult> GetActivities()
        {
            var result = await _activityService.GetActivities();

            if (result != null)
                return Ok(result);
            return NotFound();
        }

        //[HttpGet]
        //[Route("/Activity/child/{id}")]
        //public async Task<IActionResult> GetActivityChild([FromRoute] int id)
        //{
        //    var result = await _activityService.GetActivity(id);

        //    if (result != null)
        //        return Ok(result);
        //    return NotFound();

        //}

        [HttpGet]
        [Route("/Activity/child/{id}")]
        public async Task<IActionResult> GetActivityChild([FromRoute] int id)
        {
            var result = await _activityService.GetActivityChild(id);

            if (result != null)
                return Ok(result);
            return NotFound();

        }

        [HttpGet]
        [Route("/Activity/{id}")]
        public async Task<IActionResult> GetActivity([FromRoute] int id)
        {
            var result = await _activityService.GetActivity(id);

            if (result != null)
                return Ok(result);
            return NotFound();
        }

        [HttpPost]
        [Route("/Activity")]
        public async Task<IActionResult> PostActivity(ActivityRequest addActivity)
        {
            
            var result = await _activityService.PostActivity(addActivity);

            if (result != null)
                // crio um obj para devolver a reposta já padronizada para o front poder ler e tratar caso seja necessario
                return Ok(new DeafultResponse() { Description = "Sucess" });
            return NotFound();

        }

        [HttpPut]
        [Route("/Activity/{id}")]
        public async Task<IActionResult> UpdateActivity([FromRoute] int id, ActivityRequestPut putActivity)
        {
            bool IsSucess = await _activityService.UpdateActivity(id, putActivity);

            if (IsSucess)
            {
                // crio um obj para devolver a reposta já padronizada para o front poder ler e tratar caso seja necessario
                return Ok(new DeafultResponse() { Description = "Sucess" , Id = id }) ;
            }
            return NotFound();

        }

        [HttpPut]
        [Route("/Activity/row/{id}")]
        public async Task<IActionResult> UpdateActivityRow([FromRoute] int id, [FromBody] ActivityRowMove putActivity)
        {
            bool isSuccess = await _activityService.UpdateActivityRow(id, putActivity);

            if (isSuccess)
            {
                // Create an object to return a standardized response that can be easily read and handled by the front-end
                return Ok(new DeafultResponse() { Description = "Success", Id = id });
            }

            return NotFound();
        }


        [HttpDelete]
        [Route("/Activity/{id}")]

        public async Task<IActionResult> DeleteActivity([FromRoute] int id)
        {
            bool IsSucess = await _activityService.DeleteActivity(id);

            if (IsSucess)
            {
                // criar um viwemodel com o novo obj e retornar o obj dentro do OK()
                return Ok(new DeafultResponse() { Description = "Sucess", Id = id }); // receber e enviar o JSON
            }
            return NotFound();
        }

    }
}