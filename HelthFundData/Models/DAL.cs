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
        public Response<Member> GetAllMembers(SqlConnection sqlConnection)
        {
            Response<Member> memberResponse = new Response<Member>();
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
                memberResponse.SingleList = lstMembers;
            }
            else
            {
                memberResponse.StatusCode = 100;
                memberResponse.StatusMessage = "Data not found";
                memberResponse.SingleList = null;
            }
            return memberResponse; 
        }

        public Response<Member> GetMemberById(SqlConnection sqlConnection, int id)
        {
            Response<Member> memberResponse = new Response<Member>();
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
                memberResponse.Single = member;
            }
            else
            {
                memberResponse.StatusCode = 100;
                memberResponse.StatusMessage = "Data not found";
                memberResponse.Single = null;
            }
            return memberResponse;
        }

        public Response<Member> AddMember(SqlConnection sqlConnection, Member member)
        {
            Response<Member> memberResponse = new Response<Member>();
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

        public Response<Recovery> GetRecoveryById(SqlConnection sqlConnection, int id)
        {
            Response<Recovery> Response = new Response<Recovery>();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM RECOVERY WHERE ID = " + id, sqlConnection);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Recovery recovery = new Recovery();
                recovery.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                recovery.PositiveDate = Convert.ToDateTime(dt.Rows[0]["PositiveDate"]);
                Response.StatusCode = 200;
                Response.StatusMessage = "Data found";
                Response.Single = recovery;
            }
            else
            {
                Response.StatusCode = 100;
                Response.StatusMessage = "Data not found";
                Response.Single = null;
            }
            return Response;
        }

        public Response<Vaccine> GetVaccinesById(SqlConnection sqlConnection, int id)
        {
            Response<Vaccine> Response = new Response<Vaccine>();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM VACCINES WHERE MemberId = "+id, sqlConnection);
            DataTable dt = new DataTable();
            List<Vaccine> lstVaccines = new List<Vaccine>();
            dataAdapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Vaccine vaccine = new Vaccine();
                    vaccine.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                    vaccine.MemberId = Convert.ToInt32(dt.Rows[i]["MemberId"]);
                    vaccine.VaccineDate = Convert.ToDateTime(dt.Rows[i]["VaccineDate"]);
                    vaccine.VaccineManufacturer = Convert.ToString(dt.Rows[i]["VaccineManufacturer"]);
                    lstVaccines.Add(vaccine);
                }
            }
            if (lstVaccines.Count > 0)
            {
                Response.StatusCode = 200;
                Response.StatusMessage = "Data found";
                Response.SingleList = lstVaccines;
            }
            else
            {
                Response.StatusCode = 100;
                Response.StatusMessage = "Data not found";
                Response.SingleList = null;
            }
            return Response;
        }

        public Response<Vaccine> AddVaccine(SqlConnection sqlConnection, Vaccine vaccine)
        {
            Response<Vaccine> Response = new Response<Vaccine>();
            SqlCommand cmd = new SqlCommand("SET IDENTITY_INSERT Vaccines ON; INSERT INTO  VACCINES(Id, MemberId, VaccineDate, VaccineManufacturer) " + 
                "VALUES(" + vaccine.Id + ", " + vaccine.MemberId + ", '" + vaccine.VaccineDate + "', '" + vaccine.VaccineManufacturer + "'); SET IDENTITY_INSERT Vaccines OFF;", sqlConnection);
            sqlConnection.Open();
            int i = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            if (i > 0)
            {
                Response.StatusCode = 200;
                Response.StatusMessage = "Vaccine added";
            }
            else
            {
                Response.StatusCode = 100;
                Response.StatusMessage = "No data inserted"; ;
            }
            return Response;
        }

        public Response<Recovery> AddRecovery(SqlConnection sqlConnection, Recovery recovery)
        {
            Response<Recovery> Response = new Response<Recovery>();
            SqlCommand cmd = new SqlCommand("INSERT INTO  RECOVERY(Id, PositiveDate, RecoveryDate) " + "VALUES(" + recovery.Id + ", '" + recovery.PositiveDate + "', '" + recovery.RecoveryDate + "')", sqlConnection);
            sqlConnection.Open();
            int i = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            if (i > 0)
            {
                Response.StatusCode = 200;
                Response.StatusMessage = "Recovery added";
            }
            else
            {
                Response.StatusCode = 100;
                Response.StatusMessage = "No data inserted"; ;
            }
            return Response;
        }
    }
}
