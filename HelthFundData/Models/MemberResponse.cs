using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelthFundData.Models
{
    public class MemberResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public Member Member { get; set; }
        public List<Member> MemberList { get; set;}

    }
}
