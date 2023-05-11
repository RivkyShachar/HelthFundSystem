using HelthFundData.DAL;
using HelthFundData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

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
            SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection").ToString());
            Response<Recovery> Response = new Response<Recovery>();
            Dal dal = new Dal();
            Response = dal.GetAllRecoveries(sqlConnection);
            return Response;
        }

        // GET api/Recoveries/GetRecoveryById/{id}
        [HttpGet]
        [Route("GetRecoveryById/{id}")]
        public Response<Recovery> GetRecoveryById(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection").ToString());
            Response<Recovery> Response = new Response<Recovery>();
            Dal dal = new Dal();
            Response = dal.GetRecoveryById(sqlConnection, id);
            return Response;
        }

        // POST api/Recoveries/AddRecovery/{id}
        [HttpPost]
        [Route("AddRecovery")]
        public Response<Recovery> AddRecovery(Recovery recovery)
        {
            SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection").ToString());
            Response<Recovery> Response = new Response<Recovery>();
            Dal dal = new Dal();
            Response = dal.AddRecovery(sqlConnection, recovery);
            return Response;
        }
    }
}
