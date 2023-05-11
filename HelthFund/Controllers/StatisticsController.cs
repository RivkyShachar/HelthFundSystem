using HelthFundData.DAL;
using HelthFundData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            Response<string> Response = new Response<string>();
            Dal dal = new Dal(_configuration);
            Response = dal.AmountNotVaccinated();
            return Response;
        }

        // GET api/Statistics/AmountOfSickMembersInSpecificDate/{date}
        [HttpGet]
        [Route("AmountOfSickMembersInSpecificDate/{date}")]
        public Response<AmountDate> AmountOfSickMembersInSpecificDate(DateTime date)
        {
            Response<AmountDate> Response = new Response<AmountDate>();
            Dal dal = new Dal(_configuration);
            Response = dal.AmountOfSickMembersInSpecificDate(date);
            return Response;
        }

    }
}
