using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using backend_API.Data;
using backend_API.Models.Activity;
using backend_API.Models.ActivityCategory;
using backend_API.Services.WorkerProfile;
using backend_API.Services.ActivityCategory;

namespace backend_API.Controllers
{
    [ApiController]
    [Route("/ActivityCategory")]
    public class ActivityCategoryController : Controller
    {
        private readonly IActivityCategoryService _activityCategoryService;

        public ActivityCategoryController(IActivityCategoryService activityCategoryService)
        {
            _activityCategoryService = activityCategoryService;
        }

        /// <summary>
        /// Responsavel por carregar todas as ActivityCategory dentro da DB, converter em listas e apresentar ao user.Tipo=Admin
        /// </summary>
        /// <returns> lista de dto's
        /// </returns>
        /// <remarks> 
        /// Representa as 'Category' no UI   
        /// </remarks>
        [HttpGet]
        [Route("/ActivityCategory")]
        public async Task<IActionResult> GetActivityCategory()
        {
            var result = await _activityCategoryService.GetActivityCategory();

            if (result != null)
                return Ok(result);
            return NotFound();
        }

        /// <summary>
        /// Responsavel por apresentar as categorias, de acordo com o seu ID
        /// </summary>
        /// <returns>Category DTO</returns>
        /// <remarks>
        /// Cada categoria tem um ID unico
        /// </remarks>

        [HttpGet]
        [Route("/ActivityCategory/{id}")]
        public async Task<IActionResult> GetCategory([FromRoute] int id)
        {
            var result = await _activityCategoryService.GetCategory(id);

            if (result != null)
                return Ok(result);
            return NotFound();
        }

        //[HttpPost]
        //[Route("/ActivityCategory")]
        //public async Task<IActionResult> PostActivityCategory(ActivityCategoryPost _activityCategory)
        //{
        //    bool IsSucess = await _activityCategoryService.PostActivityCategory(_activityCategory);

        //    if (IsSucess)
        //    {
        //        return Ok(new DeafultResponse() { Description = "Sucess", Code = Ok) ;
        //        //   return Ok("Acção terminada com " + IsSucess);
        //    }
        //    return NotFound();
        //}


        /// <summary>
        /// Responsavel por criar e inserir uma nova categoria na DB
        /// </summary>
        /// <returns>Defatult response com o tipo de reposta apos acao</returns>
        /// remarks>
        /// Cada categoria tem um ID unico e está associada a um conjunto de estados proprios
        /// </remarks>
       
        [HttpPost]
        [Route("/ActivityCategory")]
        public async Task<IActionResult> PostActivityCategory(ActivityCategoryPost _activityCategory)
        {
            bool IsSuccess = await _activityCategoryService.PostActivityCategory(_activityCategory);

            if (IsSuccess)
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
        [Route("/ActivityCategory/{id}")]
        public async Task<IActionResult> UpdateActivityCategory([FromRoute] int id, ActivityCategoryRequestPut activityCategoryRequestPut)
        {
            bool IsSucess = await _activityCategoryService.UpdateActivityCategory(id, activityCategoryRequestPut);

            if (IsSucess)
            {
                return Ok(new DeafultResponse() { Description = "Sucess", Id = id });
            }
            return NotFound();
        }


        /// <summary>
        /// Responsavel por apagar uma categoria da DB
        /// </summary>
       /// <returns>Default Response para tratamento da frontend</returns>
       
        [HttpDelete]
        [Route("/ActivityCategory/{id}")]

        public async Task<IActionResult> DeleteActivityCategory([FromRoute] int id)
        {
            bool IsSucess = await _activityCategoryService.DeleteActivityCategory(id);

            if (IsSucess)
            {
                return Ok(new DeafultResponse() { Description = "Sucess", Id = id });
            }
            return NotFound();
        }

    }
}

