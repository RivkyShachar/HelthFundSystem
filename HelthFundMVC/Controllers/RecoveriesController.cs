﻿using HelthFundData.Models;
using Microsoft.AspNetCore.Mvc;

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
