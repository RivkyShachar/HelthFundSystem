using HelthFundData.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace HelthFundMVC.Controllers
{
    public class RecoveriesController : Controller
    {
        private readonly ILogger<RecoveriesController> _logger;

        string baseURL = "http://localhost:5227";
        public RecoveriesController(ILogger<RecoveriesController> logger)
        {
            _logger = logger;
        }
        public async Task<IActionResult> GetAllRecoveriesGet()
        {
            List<Recovery> recoveries = new List<Recovery>();
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(baseURL);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = await httpClient.GetAsync("/api/Recoveries/GetAllRecoveries");

                if (response.IsSuccessStatusCode)
                {
                    String results = await response.Content.ReadAsStringAsync();
                    var json = JObject.Parse(results);
                    var recoveryList = json["singleList"].ToObject<List<Recovery>>();
                    recoveries = recoveryList ?? new List<Recovery>();
                }
                else
                {
                    Console.WriteLine("Error calling web API");
                }
                ViewData.Model = recoveries;
            }
            return View();
        }

        public async Task<IActionResult> GetRecoveryByIdGet(int id)
        {
            
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(baseURL);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = await httpClient.GetAsync("/api/Recoveries/GetRecoveryById/" + id);

                if (response.IsSuccessStatusCode)
                {
                    Recovery recovery = new Recovery();
                    String results = await response.Content.ReadAsStringAsync();
                    var json = JObject.Parse(results);
                    var recoveryGet = json["single"].ToObject<Recovery>();
                    recovery = recoveryGet ?? new Recovery();
                    ViewData.Model = recovery;
                }
                else
                {
                    Console.WriteLine("Error calling web API");
                }
                
            }
            return View();
        }
        public IActionResult AddRecoveryGet(int id)
        {
            var recovery = new Recovery();
            recovery.Id = id;
            return View(recovery);
        }
        public async Task<IActionResult> AddRecoveryPost(Recovery recovery)
        {
            Recovery obj = new Recovery()
            {
                Id = recovery.Id,
                PositiveDate = recovery.PositiveDate,
                RecoveryDate = recovery.PositiveDate.AddDays(14),
            };
            if (recovery.Id != null)
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(baseURL);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var response = await httpClient.PostAsJsonAsync<Recovery>("/api/Recoveries/AddRecovery", obj);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("GetAllMembersGet", "Members");
                    }
                    else
                    {
                        Console.WriteLine("Error calling web API");
                    }
                }
            }
            return View();
        }
    }
}
