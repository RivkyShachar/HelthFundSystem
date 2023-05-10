using HelthFundData.Models;
using HelthFundMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace HelthFundMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        string baseURL = "http://localhost:5227";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> Statistics()
        {
            List<AmountDate> amountDates = new List<AmountDate>();
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(baseURL);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response1 = await httpClient.GetAsync("/api/Statistics/AmountNotVaccinated");
                HttpResponseMessage response2;
                if (response1.IsSuccessStatusCode)
                {
                    String results1 = await response1.Content.ReadAsStringAsync();
                    var json = JObject.Parse(results1);
                    var vaccineStatistics = json["single"].ToObject<string>();
                    ViewBag.VaccineStatistics = vaccineStatistics;
                }
                else
                {
                    Console.WriteLine("Error calling web API");
                }

                DateTime endDate = DateTime.Today; // Current date
                DateTime startDate = endDate.AddDays(-30); // 30 days ago
                AmountDate ad = new AmountDate();
                var allDates = Enumerable.Range(0, 31)
                    .Select(offset => startDate.AddDays(offset).Date)
                .ToList();

                foreach(var d in allDates)
                {
                    response2 = await httpClient.GetAsync("/api/Statistics/AmountOfSickMembersInSpecificDate/" + d.Date.ToString("yyyy-MM-dd"));
                    if (response2.IsSuccessStatusCode)
                    {
                        String results2 = await response2.Content.ReadAsStringAsync();
                        var json = JObject.Parse(results2);
                        var dateStatistics = json["single"].ToObject<AmountDate>();
                        ad = dateStatistics ?? new AmountDate();
                        amountDates.Add(ad);
                    }
                }
                var graphData = allDates
                .Select(date => new { Date = date, Count = amountDates.FirstOrDefault(ad => ad.Date == date)?.Amount ?? 0 })
                .OrderBy(d => d.Date)
                .ToList();

                // Prepare the data for the graph
                var dates = graphData.Select(d => d.Date.ToString("yyyy-MM-dd")).ToList();
                var counts = graphData.Select(d => d.Count).ToList();

                // Pass the data to the view
                ViewBag.Dates = dates;
                ViewBag.Counts = counts;              
                ViewData.Model = amountDates;
            }
            return View();
        }
        


    }
}