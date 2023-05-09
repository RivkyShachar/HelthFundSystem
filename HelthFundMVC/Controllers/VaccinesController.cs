using HelthFundData.Models;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddVaccineGet()
        {
            return View();
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
