using HelthFundData.DAL;
using HelthFundData.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelthFundAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecoveriesController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public RecoveriesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET api/Recoveries/GetAllRecoveries
        [HttpGet]
        [Route("GetAllRecoveries")]
        public Response<Recovery> GetAllRecoveries()
        {
            Response<Recovery> Response = new Response<Recovery>();
            Dal dal = new Dal(_configuration);
            Response = dal.GetAllRecoveries();
            return Response;
        }

        // GET api/Recoveries/GetRecoveryById/{id}
        [HttpGet]
        [Route("GetRecoveryById/{id}")]
        public Response<Recovery> GetRecoveryById(int id)
        {
            Response<Recovery> Response = new Response<Recovery>();
            Dal dal = new Dal(_configuration);
            Response = dal.GetRecoveryById(id);
            return Response;
        }

        // POST api/Recoveries/AddRecovery/{id}
        [HttpPost]
        [Route("AddRecovery")]
        public Response<Recovery> AddRecovery(Recovery recovery)
        {
            Response<Recovery> Response = new Response<Recovery>();
            Dal dal = new Dal(_configuration);
            Response = dal.AddRecovery(recovery);
            return Response;
        }
    }
}
