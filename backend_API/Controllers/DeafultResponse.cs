using Newtonsoft.Json;
using System.Net;

namespace backend_API.Controllers
{
    public class DeafultResponse
    {

        /// <summary>

        /// Response Code

        /// </summary>

        public HttpStatusCode Code { get; set; } = HttpStatusCode.OK;



        /// <summary>

        /// Response Data 

        /// </summary>

        public string Description { get; set; }



        /// <summary>

        /// Response Data 

        /// </summary>

        public int Id { get; set; }





        /// <summary>

        /// Response Error Data if exist 

        /// </summary>
        

        public string Errors { get; set; }





    }
}