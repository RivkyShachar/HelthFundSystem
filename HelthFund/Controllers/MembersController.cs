using HelthFundData.Models;
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

        // GET api/Members/GetAllMembers
        [HttpGet]
        [Route("GetAllMembers")]
        public Response<Member> GetAllMembers()
        {
            SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection").ToString());
            Response<Member> memberResponse = new Response<Member>();
            DAL dal= new DAL();
            memberResponse = dal.GetAllMembers(sqlConnection);
            return memberResponse;
        }

        // GET api/Members/GetMemberById/{id}
        [HttpGet]
        [Route("GetMemberById/{id}")]
        public Response<Member> GetMemberById(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection").ToString());
            Response<Member> memberResponse = new Response<Member>();
            DAL dal = new DAL();
            memberResponse = dal.GetMemberById(sqlConnection, id);
            return memberResponse;
        }

        // POST api/Members/AddMember/{id}
        [HttpPost]
        [Route("AddMember")]
        public Response<Member> AddMember(Member member)
        {
            SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection").ToString());
            Response<Member> memberResponse = new Response<Member>();
            DAL dal = new DAL();
            memberResponse = dal.AddMember(sqlConnection, member);
            return memberResponse;
        }

    }
}
