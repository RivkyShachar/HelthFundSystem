using HelthFundData.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Reflection.PortableExecutable;

namespace HelthFundMVC.Controllers
{
    public class VaccinesController : Controller
    {
        private readonly ILogger<VaccinesController> _logger;

        string baseURL = "http://localhost:5227";
        public VaccinesController(ILogger<VaccinesController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> GetAllVaccinesGet()
        {
            List<Vaccine> vaccines = new List<Vaccine>();
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(baseURL);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = await httpClient.GetAsync("/api/Vaccines/GetAllVaccines");

                if (response.IsSuccessStatusCode)
                {
                    String results = await response.Content.ReadAsStringAsync();
                    var json = JObject.Parse(results);
                    var vaccineList = json["singleList"].ToObject<List<Vaccine>>();
                    vaccines = vaccineList ?? new List<Vaccine>();
                }
                else
                {
                    Console.WriteLine("Error calling web API");
                }
                ViewData.Model = vaccines;
            }
            return View();
        }

        public async Task<IActionResult> GetVaccinesByIdGet(int id)
        {
            List<Vaccine> vaccines = new List<Vaccine>();
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(baseURL);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = await httpClient.GetAsync("/api/Vaccines/GetVaccinesById/" + id);

                if (response.IsSuccessStatusCode)
                {
                    String results = await response.Content.ReadAsStringAsync();
                    var json = JObject.Parse(results);
                    var vaccineList = json["singleList"].ToObject<List<Vaccine>>();
                    vaccines = vaccineList ?? new List<Vaccine>();
                }
                else
                {
                    Console.WriteLine("Error calling web API");
                }
                ViewData.Model = vaccines;

            }
            return View();
        }

        public IActionResult AddVaccineGet(int id)
        {
            var vaccin = new Vaccine();
            vaccin.MemberId = id;
            return View(vaccin);
        }
        public async Task<IActionResult> AddVaccinePost(Vaccine vaccine)
        {
            Vaccine obj = new Vaccine()
            {
                Id = vaccine.Id,
                MemberId = vaccine.MemberId,
                VaccineDate = vaccine.VaccineDate,
                VaccineManufacturer = vaccine.VaccineManufacturer,
            };
            if (vaccine.Id != null)
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(baseURL);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var response = await httpClient.PostAsJsonAsync<Vaccine>("/api/Vaccines/AddVaccine", obj);

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
