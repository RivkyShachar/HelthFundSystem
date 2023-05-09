using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelthFundData.Models
{
    public class DAL
    {
        public MemberResponse GetAllMembers(SqlConnection sqlConnection)
        {
            MemberResponse memberResponse= new MemberResponse();
            SqlDataAdapter dataAdapter= new SqlDataAdapter("SELECT * FROM MEMBERS",sqlConnection);
            DataTable dt = new DataTable();
            List<Member> lstMembers= new List<Member>();
            dataAdapter.Fill(dt);
            if(dt.Rows.Count>0)
            {
                for(int i=0; i<dt.Rows.Count; i++)
                {
                    Member member = new Member();
                    member.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                    member.FirstName = Convert.ToString(dt.Rows[i]["FirstName"]);
                    member.LastName = Convert.ToString(dt.Rows[i]["LastName"]);
                    member.Address = Convert.ToString(dt.Rows[i]["Address"]);
                    member.PhoneNumber = Convert.ToString(dt.Rows[i]["PhoneNumber"]);
                    member.MobileNumber = Convert.ToString(dt.Rows[i]["MobileNumber"]);
                    member.BirthDate = Convert.ToDateTime(dt.Rows[i]["BirthDate"]);
                    member.ImageUrl = Convert.ToString(dt.Rows[i]["ImageUrl"]);
                    lstMembers.Add(member);
                }
            }
            if(lstMembers.Count>0) 
            { 
                memberResponse.StatusCode= 200;
                memberResponse.StatusMessage = "Data found";
                memberResponse.MemberList = lstMembers;
            }
            else
            {
                memberResponse.StatusCode = 100;
                memberResponse.StatusMessage = "Data not found";
                memberResponse.MemberList = null;
            }
            return memberResponse; 
        }
    } 
}
