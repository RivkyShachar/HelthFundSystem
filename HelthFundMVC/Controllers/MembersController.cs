using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using HelthFundMVC.Models;
using HelthFundData.Models;
using Azure;
using System.Text.Json;
using System.Data;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json.Linq;

namespace HelthFundMVC.Controllers
{
    public class MembersController : Controller
    {
        private readonly ILogger<MembersController> _logger;

        string baseURL = "http://localhost:5227";
        public MembersController(ILogger<MembersController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> GetAllMembers()
        {
            List<Member> members= new List<Member>();
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(baseURL);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = await httpClient.GetAsync("/api/Members/GetAllMembers");

                if (response.IsSuccessStatusCode)
                {
                    String results = await response.Content.ReadAsStringAsync();
                    var json = JObject.Parse(results);
                    var memberList = json["memberList"].ToObject<List<Member>>();
                    members = memberList ?? new List<Member>();
                }
                else
                {
                    Console.WriteLine("Error calling web API");
                }
                ViewData.Model= members;
            }
            return View();
        }
        

    }
}

