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

        public MemberResponse GetMemberById(SqlConnection sqlConnection, int id)
        {
            MemberResponse memberResponse = new MemberResponse();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM MEMBERS WHERE ID = "+id, sqlConnection);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Member member = new Member();
                member.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                member.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
                member.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
                member.Address = Convert.ToString(dt.Rows[0]["Address"]);
                member.PhoneNumber = Convert.ToString(dt.Rows[0]["PhoneNumber"]);
                member.MobileNumber = Convert.ToString(dt.Rows[0]["MobileNumber"]);
                member.BirthDate = Convert.ToDateTime(dt.Rows[0]["BirthDate"]);
                member.ImageUrl = Convert.ToString(dt.Rows[0]["ImageUrl"]);
                memberResponse.StatusCode = 200;
                memberResponse.StatusMessage = "Data found";
                memberResponse.Member = member;
            }
            else
            {
                memberResponse.StatusCode = 100;
                memberResponse.StatusMessage = "Data not found";
                memberResponse.Member = null;
            }
            return memberResponse;
        }

        public MemberResponse AddMember(SqlConnection sqlConnection, Member member)
        {
            MemberResponse memberResponse = new MemberResponse();
            SqlCommand cmd = new SqlCommand("INSERT INTO  MEMBERS(Id, FirstName, LastName, Address, PhoneNumber, MobileNumber, BirthDate, ImageUrl) " + "VALUES(" + member.Id + ", '" + member.FirstName + "', '" + member.LastName + "', '" + member.Address + "', '" + member.PhoneNumber +
                "', '" + member.MobileNumber + "', '" + member.BirthDate + "', '" + member.ImageUrl + "')", sqlConnection);
            sqlConnection.Open();
            int i = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            if (i > 0)
            {
                memberResponse.StatusCode = 200;
                memberResponse.StatusMessage = "Member added";
            }
            else
            {
                memberResponse.StatusCode = 100;
                memberResponse.StatusMessage = "No data inserted";;
            }
            return memberResponse;
        }

    }
}
