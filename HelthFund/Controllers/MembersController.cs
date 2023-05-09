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
        public ActionResult<IEnumerable<Member>> GetMembers()
        {
            var members = _memberRepository.GetAllMembers();
            return Ok(members);
        }

        // GET api/members/{id}
        [HttpGet("{id}")]
        public ActionResult<Member> GetMember(int id)
        {
            var member = _memberRepository.GetMemberById(id);
            if (member == null)
            {
                return NotFound();
            }
            return Ok(member);
        }

        // POST api/members
        [HttpPost]
        public ActionResult<Member> AddMember(Member member)
        {
            var addedMember = _memberRepository.AddMember(member);
            return CreatedAtAction(nameof(GetMember), new { id = addedMember.Id }, addedMember);
        }

        // PUT api/members/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateMember(int id, Member member)
        {
            if (id != member.Id)
            {
                return BadRequest();
            }

            var existingMember = _memberRepository.GetMemberById(id);
            if (existingMember == null)
            {
                return NotFound();
            }

            _memberRepository.UpdateMember(member);
            return NoContent();
        }

        // DELETE api/members/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteMember(int id)
        {
            var existingMember = _memberRepository.GetMemberById(id);
            if (existingMember == null)
            {
                return NotFound();
            }

            _memberRepository.DeleteMember(id);
            return NoContent();
        }
    }
}
