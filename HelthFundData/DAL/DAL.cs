using HelthFundData.Models;
using Microsoft.Data.SqlClient;
using System.Data;


namespace HelthFundData.DAL
{
    public class Dal
    {
        public Response<Member> GetAllMembers(SqlConnection sqlConnection)
        {
            Response<Member> Response = new Response<Member>();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM MEMBERS", sqlConnection);
            DataTable dt = new DataTable();
            List<Member> lstMembers = new List<Member>();
            dataAdapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
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
            if (lstMembers.Count > 0)
            {
                Response.StatusCode = 200;
                Response.StatusMessage = "Data found";
                Response.SingleList = lstMembers;
            }
            else
            {
                Response.StatusCode = 100;
                Response.StatusMessage = "Data not found";
                Response.SingleList = null;
            }
            return Response;
        }
        public Models.Response<Vaccine> GetAllVaccines(SqlConnection sqlConnection)
        {
            Response<Vaccine> Response = new Response<Vaccine>();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Vaccines", sqlConnection);
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
        public Response<Recovery> GetAllRecoveries(SqlConnection sqlConnection)
        {
            Response<Recovery> Response = new Response<Recovery>();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM RECOVERY", sqlConnection);
            DataTable dt = new DataTable();
            List<Recovery> lstRecoveries = new List<Recovery>();
            dataAdapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Recovery recovery = new Recovery();
                    recovery.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                    recovery.PositiveDate = Convert.ToDateTime(dt.Rows[i]["PositiveDate"]);
                    recovery.RecoveryDate = Convert.ToDateTime(dt.Rows[i]["RecoveryDate"]);
                    lstRecoveries.Add(recovery);
                }
            }
            if (lstRecoveries.Count > 0)
            {

                Response.StatusCode = 200;
                Response.StatusMessage = "Data found";
                Response.SingleList = lstRecoveries;
            }
            else
            {
                Response.StatusCode = 100;
                Response.StatusMessage = "Data not found";
                Response.SingleList = null;
            }
            return Response;
        }


        public Response<Member> GetMemberById(SqlConnection sqlConnection, int id)
        {
            Response<Member> memberResponse = new Response<Member>();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM MEMBERS WHERE ID = " + id, sqlConnection);
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
        public Response<Vaccine> GetVaccinesById(SqlConnection sqlConnection, int id)
        {
            Response<Vaccine> Response = new Response<Vaccine>();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM VACCINES WHERE MemberId = " + id, sqlConnection);
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

        public Response<Member> AddMember(SqlConnection sqlConnection, Member member)
        {
            Response<Member> Response = new Response<Member>();
            DateTime today = DateTime.Today;
            //chech if birth date is before today
            if (member.BirthDate > today)
            {
                Response.StatusCode = 100;
                Response.StatusMessage = "No data inserted - birthDate error";
                return Response;
            }
            //check if member already exists
            Response<Member> getMemById = new Response<Member>();
            getMemById = GetMemberById(sqlConnection, member.Id);
            if (getMemById != null && getMemById.StatusMessage == "Data found")
            {
                Response.StatusCode = 405;
                Response.StatusMessage = "This id is already exist, no data inserted";
                return Response;
            }
            //set default image
            if (member.ImageUrl == null || member.ImageUrl == "")
            {
                member.ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR7RbuAj7zoRZSIDcV_nz2LyZZjwiOETmn7kg&usqp=CAU";
            }
            SqlCommand cmd = new SqlCommand("INSERT INTO  MEMBERS(Id, FirstName, LastName, Address, PhoneNumber, MobileNumber, BirthDate, ImageUrl) " + "VALUES(" + member.Id + ", '" + member.FirstName + "', '" + member.LastName + "', '" + member.Address + "', '" + member.PhoneNumber +
                "', '" + member.MobileNumber + "', '" + member.BirthDate.Date.ToString("yyyy-MM-dd") + "', '" + member.ImageUrl + "')", sqlConnection);
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
        public Response<Vaccine> AddVaccine(SqlConnection sqlConnection, Vaccine vaccine)
        {
            Response<Vaccine> Response = new Response<Vaccine>();
            Response<Member> getMemById = new Response<Member>();
            Response<Vaccine> getVacById = new Response<Vaccine>();
            getMemById = GetMemberById(sqlConnection, vaccine.MemberId);
            getVacById = GetVaccinesById(sqlConnection, vaccine.Id);
            //check if the member id is correct
            if (getMemById == null && getMemById.StatusCode != 200)
            {
                Response.StatusCode = 100;
                Response.StatusMessage = "No member with this id exists, no data inserted";
                return Response;
            }
            //check if id already exists
            if (getVacById.StatusCode == 200)
            {
                Response.StatusCode = 100;
                Response.StatusMessage = "This id is already exists, no data inserted";
                return Response;
            }

            // Check the number of vaccines associated with the member
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM VACCINES WHERE MemberId = " + vaccine.MemberId, sqlConnection);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);

            if (dt.Rows.Count >= 4)
            {
                Response.StatusCode = 100;
                Response.StatusMessage = "Maximum number of vaccines reached for the member";
                return Response;
            }
            SqlCommand cmd = new SqlCommand("INSERT INTO  VACCINES(MemberId, VaccineDate, VaccineManufacturer) " +
                "VALUES(" + vaccine.MemberId + ", '" + vaccine.VaccineDate.Date.ToString("yyyy-MM-dd") + "', '" + vaccine.VaccineManufacturer + "');", sqlConnection);
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
            DateTime today = DateTime.Now;
            Response<Recovery> Response = new Response<Recovery>();
            Response<Member> getMemById = new Response<Member>();
            getMemById = GetMemberById(sqlConnection, recovery.Id);
            //chech if positive date is before recovery
            if (recovery.RecoveryDate < recovery.PositiveDate || recovery.PositiveDate > today)
            {
                Response.StatusCode = 100;
                Response.StatusMessage = "dates error, no data inserted";
                return Response;
            }
            //check if the member id is correct
            if (getMemById == null && getMemById.StatusCode != 200)
            {
                Response.StatusCode = 100;
                Response.StatusMessage = "No member with this id exists, no data inserted";
                return Response;
            }
            // Check the number already has recovery date
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM RECOVERY WHERE Id = " + recovery.Id, sqlConnection);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Response.StatusCode = 100;
                Response.StatusMessage = "Member has recovery date";
                return Response;
            }

            SqlCommand cmd = new SqlCommand("INSERT INTO  RECOVERY(Id, PositiveDate, RecoveryDate) " + "VALUES(" + recovery.Id + ", '" + recovery.PositiveDate.Date.ToString("yyyy-MM-dd") + "', '" + recovery.RecoveryDate.Date.ToString("yyyy-MM-dd") + "')", sqlConnection);
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
                Response.Single = "" + NotVaccinated + "/" + TotalMembers + " of the members are not vaccinated at all";
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