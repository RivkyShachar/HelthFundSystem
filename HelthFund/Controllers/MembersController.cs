using HelthFundData.Models;
using HelthFundData.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HelthFundAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public MembersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET api/members
        [HttpGet]
        [Route("GetAllMembers")]
        public MemberResponse GetAllMembers()
        {
            SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("CoronaData").ToString());
            MemberResponse memberResponse = new MemberResponse();
            DAL dal= new DAL();
            memberResponse = dal.GetAllMembers(sqlConnection);
            return memberResponse;
        }
        
    }
}
