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

        // GET api/Members/GetRecoveryById/{id}
        [HttpGet]
        [Route("GetRecoveryById/{id}")]
        public Response<Recovery> GetRecoveryById(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection").ToString());
            Response<Recovery> Response = new Response<Recovery>();
            DAL dal = new DAL();
            Response = dal.GetRecoveryById(sqlConnection, id);
            return Response;
        }

        // GET api/Members/GetVaccinesById/{id}
        [HttpGet]
        [Route("GetVaccinesById/{id}")]
        public Response<Vaccine> GetVaccinesById(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection").ToString());
            Response<Vaccine> Response = new Response<Vaccine>();
            DAL dal = new DAL();
            Response = dal.GetVaccinesById(sqlConnection, id);
            return Response;
        }

    }
}
