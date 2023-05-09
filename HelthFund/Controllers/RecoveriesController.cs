﻿using HelthFundData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace HelthFundAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecoveriesController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public RecoveriesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET api/Recoveries/GetRecoveryById/{id}
        [HttpGet]
        [Route("GetRecoveryById/{id}")]
        public Response<Recovery> GetRecoveryById(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection").ToString());
            Response<Recovery> Response = new Response<Recovery>();
            DAL dal = new DAL();
            Response = dal.GetRecoveryById(sqlConnection, id);
            return Response;
        }

        // POST api/Recoveries/AddRecovery/{id}
        [HttpPost]
        [Route("AddRecovery")]
        public Response<Recovery> AddRecovery(Recovery recovery)
        {
            SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection").ToString());
            Response<Recovery> Response = new Response<Recovery>();
            DAL dal = new DAL();
            Response = dal.AddRecovery(sqlConnection, recovery);
            return Response;
        }
    }
}