using HelthFundData.DAL;
using HelthFundData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace HelthFundAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public StatisticsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET api/Statistics/AmountNotVaccinated
        [HttpGet]
        [Route("AmountNotVaccinated")]
        public Response<string> AmountNotVaccinated()
        {
            SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection").ToString());
            Response<string> Response = new Response<string>();
            Dal dal = new Dal();
            Response = dal.AmountNotVaccinated(sqlConnection);
            return Response;
        }

        // GET api/Statistics/AmountOfSickMembersInSpecificDate/{date}
        [HttpGet]
        [Route("AmountOfSickMembersInSpecificDate/{date}")]
        public Response<AmountDate> AmountOfSickMembersInSpecificDate(DateTime date)
        {
            SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection").ToString());
            Response<AmountDate> Response = new Response<AmountDate>();
            Dal dal = new Dal();
            Response = dal.AmountOfSickMembersInSpecificDate(sqlConnection, date);
            return Response;
        }

    }
}
