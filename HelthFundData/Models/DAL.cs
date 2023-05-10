﻿using Azure;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
            Response<Member> Response = new Response<Member>();
            Response<Member> getMemById = new Response<Member>();
            getMemById = GetMemberById(sqlConnection, member.Id);
            if(getMemById != null && getMemById.StatusMessage == "Data found")
            {
                Response.StatusCode = 400;
                Response.StatusMessage = "This id is already exist, no data inserted";
                return Response;
            }
            if (member.ImageUrl == null || member.ImageUrl == "")
            {
                member.ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR7RbuAj7zoRZSIDcV_nz2LyZZjwiOETmn7kg&usqp=CAU";
            }
            SqlCommand cmd = new SqlCommand("INSERT INTO  MEMBERS(Id, FirstName, LastName, Address, PhoneNumber, MobileNumber, BirthDate, ImageUrl) " + "VALUES(" + member.Id + ", '" + member.FirstName + "', '" + member.LastName + "', '" + member.Address + "', '" + member.PhoneNumber +
                "', '" + member.MobileNumber + "', '" + member.BirthDate + "', '" + member.ImageUrl + "')", sqlConnection);
            sqlConnection.Open();
            int i = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            if (i > 0)
            {
                Response.StatusCode = 200;
                Response.StatusMessage = "Member added";
            }
            else
            {
                Response.StatusCode = 100;
                Response.StatusMessage = "No data inserted";
            }
            return Response;
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

            // Check the number of vaccines associated with the member
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM VACCINES WHERE MemberId = " + vaccine.MemberId, sqlConnection);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);

            if (dt.Rows.Count >= 4)
            {
                Response.StatusCode = 300;
                Response.StatusMessage = "Maximum number of vaccines reached for the member";
                return Response;
            }
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

            // Check the number already has recovery date
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM RECOVERY WHERE Id = " + recovery.Id, sqlConnection);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Response.StatusCode = 300;
                Response.StatusMessage = "Member has recovery date";
                return Response;
            }

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

        public Response<string> AmountNotVaccinated(SqlConnection sqlConnection)
        {
            Response<string> Response = new Response<string>();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT (SELECT COUNT(*) FROM Members) AS TotalMembers, (SELECT COUNT(*) FROM Members WHERE Id NOT IN (SELECT DISTINCT MemberId FROM Vaccines)) AS NotVaccinated", sqlConnection);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                string TotalMembers = Convert.ToString(dt.Rows[0]["TotalMembers"]);
                string NotVaccinated = Convert.ToString(dt.Rows[0]["NotVaccinated"]);
                Response.StatusCode = 200;
                Response.StatusMessage = "Data found";
                Response.Single = ""+ NotVaccinated + "/" + TotalMembers + " of the members are not vaccinated at all";
            }
            else
            {
                // Handle the case when no data is returned
                Response.StatusCode = 100;
                Response.StatusMessage = "No data found";
                Response.Single = null;
            }
            return Response;
        }

        public Response<AmountDate> AmountOfSickMembersInSpecificDate(SqlConnection sqlConnection, DateTime date)
        {
            Response<AmountDate> Response = new Response<AmountDate>();
            AmountDate amountDate = new AmountDate();
            amountDate.Date = date;
            SqlCommand command = new SqlCommand(@"SELECT COUNT(*) AS AmountOfSickMembers
                                         FROM Members m
                                         INNER JOIN Recovery r ON m.Id = r.Id
                                         WHERE r.RecoveryDate > @date AND r.PositiveDate <= @date", sqlConnection);
            command.Parameters.AddWithValue("@date", date);
            sqlConnection.Open();
            amountDate.Amount = (int)command.ExecuteScalar();
            Response.StatusCode = 200;
            Response.StatusMessage = "Data found";
            Response.Single = amountDate;
            return Response;
        }
    }
}