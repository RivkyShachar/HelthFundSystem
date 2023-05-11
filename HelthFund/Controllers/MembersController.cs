using HelthFundData.DAL;
using HelthFundData.Models;
using Microsoft.AspNetCore.Mvc;


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
            Response<Member> memberResponse = new Response<Member>();
            Dal dal = new Dal(_configuration);
            memberResponse = dal.GetAllMembers();
            return memberResponse;
        }

        // GET api/Members/GetMemberById/{id}
        [HttpGet]
        [Route("GetMemberById/{id}")]
        public Response<Member> GetMemberById(int id)
        {
            Response<Member> memberResponse = new Response<Member>();
            Dal dal = new Dal(_configuration);
            memberResponse = dal.GetMemberById(id);
            return memberResponse;
        }

        // POST api/Members/AddMember/{id}
        [HttpPost]
        [Route("AddMember")]
        public Response<Member> AddMember(Member member)
        {
            Response<Member> memberResponse = new Response<Member>();
            Dal dal = new Dal(_configuration);
            memberResponse = dal.AddMember(member);
            return memberResponse;
        }

    }
}
