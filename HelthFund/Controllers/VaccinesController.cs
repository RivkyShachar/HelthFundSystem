using HelthFundData.DAL;
using HelthFundData.Models;
using Microsoft.AspNetCore.Mvc;

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

        // GET api/Vaccines/GetAllVaccines
        [HttpGet]
        [Route("GetAllVaccines")]
        public Response<Vaccine> GetAllVaccines()
        {
            Response<Vaccine> Response = new Response<Vaccine>();
            Dal dal = new Dal(_configuration);
            Response = dal.GetAllVaccines();
            return Response;
        }

        // GET api/Vaccines/GetVaccinesById/{id}
        [HttpGet]
        [Route("GetVaccinesById/{id}")]
        public Response<Vaccine> GetVaccinesById(int id)
        {
            Response<Vaccine> Response = new Response<Vaccine>();
            Dal dal = new Dal(_configuration);
            Response = dal.GetVaccinesById(id);
            return Response;
        }

        // POST api/Vaccines/AddVaccine/{id}
        [HttpPost]
        [Route("AddVaccine")]
        public Response<Vaccine> AddVaccine(Vaccine vaccine)
        {
            Response<Vaccine> Response = new Response<Vaccine>();
            Dal dal = new Dal(_configuration);
            Response = dal.AddVaccine(vaccine);
            return Response;
        }
    }
}
