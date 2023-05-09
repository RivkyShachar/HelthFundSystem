using HelthFundData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace HelthFundAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccinesController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public VaccinesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET api/Members/GetVaccinesById/{id}
        [HttpGet]
        [Route("GetVaccinesById/{id}")]
        public Response<Vaccine> GetVaccinesById(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection").ToString());
            Response<Vaccine> Response = new Response<Vaccine>();
            DAL dal = new DAL();
            Response = dal.GetVaccinesById(sqlConnection, id);
            return Response;
        }

        // POST api/Vaccines/AddVaccine/{id}
        [HttpPost]
        [Route("AddVaccine")]
        public Response<Vaccine> AddVaccine(Vaccine vaccine)
        {
            SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection").ToString());
            Response<Vaccine> Response = new Response<Vaccine>();
            DAL dal = new DAL();
            Response = dal.AddVaccine(sqlConnection, vaccine);
            return Response;
        }
    }
}
