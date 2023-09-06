using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using backend_API.Data;
using backend_API.Models.WorkerProfile;
using System.Xml.Linq;
using backend_API.Services.WorkerProfile;

namespace backend_API.Controllers
{
    [ApiController]
    [Route("WorkerProfile")]
    public class WorkerProfileController : Controller
    {
        
        private readonly IWorkerProfileService _workerProfileService;

        public WorkerProfileController(IWorkerProfileService workerProfileService)
        {
            _workerProfileService = workerProfileService;
        }

        /// <summary>
        /// Metodo responsavel por carregar todos os user dentro da DB, converter em listas e apresentar ao user.Tipo=Admin
        /// </summary>
        /// <returns>lista de dto's
        /// </returns>
        /// <remarks>
        /// 
        /// Sample 
        /// Get/api/asAdmin
        /// 
        /// </remarks>
        
        [HttpGet]
        [Route("/asAdmin")]
        public async Task<IActionResult> GetWorkerProfiles()
        {
            var result = await _workerProfileService.GetWorkerProfiles();

            if (result != null)
                return Ok(result);
            return NotFound();
        }

        [HttpGet]
        [Route("/{id}")]
        public async Task<IActionResult> GetWorkerProfile([FromRoute] int id)
        {
            var result = await _workerProfileService.GetWorkerProfile(id);

            if (result != null)
                return Ok(result);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> PostWorkerProfile(WorkerProfilePost _workerProfile)
        {
            bool IsSucess = await _workerProfileService.PostWorkerProfile(_workerProfile);

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
        [Route("/profile/{id}")]
        public async Task<IActionResult> UpdateWorkerProfile([FromRoute] int id, WorkerProfileRequest _workerProfile)
        {
            bool IsSucess = await _workerProfileService.UpdateWorkerProfile(id, _workerProfile);

            if (IsSucess)
            {
                return Ok(new DeafultResponse() { Description = "Sucess", Id = id });
            }
            return NotFound();
        }


        [HttpPut]
        [Route("/Activate/{id}")]
        public async Task<IActionResult> UpWorkerProfile([FromRoute] int id, WorkerProfileActivationRequest _workerProfile)
        {
            bool IsSucess = await _workerProfileService.UpWorkerProfile(id, _workerProfile);

            if (IsSucess)
            {
                return Ok(new DeafultResponse() { Description = "Sucess", Id = id });
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("/{id}")]

        public async Task<IActionResult> DeleteWorkerProfile([FromRoute] int id)
        {
            bool IsSucess = await _workerProfileService.DeleteWorkerProfile(id);
            
            if(IsSucess)
            {
                return Ok(new DeafultResponse() { Description = "Sucess", Id = id });
            }
            return NotFound();
        }
    }    
}
