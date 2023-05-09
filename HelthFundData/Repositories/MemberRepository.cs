using HelthFundData.DbContext;
using HelthFundData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelthFundData.Models;
using HelthFundData.DbContext;

namespace HelthFundData.Repositories
{
    public class MemberRepository
    {
        private readonly HelthFundDbContext _dbContext;

        public MemberRepository(HelthFundDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Member> GetAllMembers()
        {
            return _dbContext.Members.ToList();
        }

        public Member GetMemberById(int id)
        {
            return _dbContext.Members.Find(id);
        }

        public Member AddMember(Member member)
        {
            _dbContext.Members.Add(member);
            _dbContext.SaveChanges();
            return member;
        }

        public void UpdateMember(Member member)
        {
            _dbContext.Members.Update(member);
            _dbContext.SaveChanges();
        }

        public void DeleteMember(int id)
        {
            var member = _dbContext.Members.Find(id);
            if (member != null)
            {
                _dbContext.Members.Remove(member);
                _dbContext.SaveChanges();
            }
        }
    }
}


