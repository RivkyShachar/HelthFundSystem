using HelthFundData.Models;
using HelthFundData.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelthFundAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly MemberRepository _memberRepository;

        public MembersController(MemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        // GET api/members
        [HttpGet]
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
