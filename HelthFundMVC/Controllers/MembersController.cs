using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using HelthFundMVC.Models;
using HelthFundData.Models;

namespace HelthFundMVC.Controllers
{
    public class MembersController : Controller
    {
        private readonly HttpClient _httpClient;

        public MembersController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5000/api/members"); // API base URL
        }

        // GET: Members
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("");
            response.EnsureSuccessStatusCode();

            var membersJson = await response.Content.ReadAsStringAsync();
            var members = JsonConvert.DeserializeObject<IEnumerable<Member>>(membersJson);

            return View(members);
        }

        // GET: Members/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var response = await _httpClient.GetAsync($"{id}");
            if (response.IsSuccessStatusCode)
            {
                var memberJson = await response.Content.ReadAsStringAsync();
                var member = JsonConvert.DeserializeObject<Member>(memberJson);
                return View(member);
            }

            return NotFound();
        }

        // GET: Members/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Member member)
        {
            if (ModelState.IsValid)
            {
                var memberJson = JsonConvert.SerializeObject(member);
                var content = new StringContent(memberJson, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("", content);
                response.EnsureSuccessStatusCode();

                return RedirectToAction(nameof(Index));
            }

            return View(member);
        }

        // GET: Members/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _httpClient.GetAsync($"{id}");
            if (response.IsSuccessStatusCode)
            {
                var memberJson = await response.Content.ReadAsStringAsync();
                var member = JsonConvert.DeserializeObject<Member>(memberJson);
                return View(member);
            }

            return NotFound();
        }

        // POST: Members/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Member member)
        {
            if (id != member.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var memberJson = JsonConvert.SerializeObject(member);
                var content = new StringContent(memberJson, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"{id}", content);
                response.EnsureSuccessStatusCode();

                return RedirectToAction(nameof(Index));
            }

            return View(member);
        }

        // GET: Members/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _httpClient.GetAsync($"{id}");
            if (response.IsSuccessStatusCode)
            {
                var memberJson = await response.Content.ReadAsStringAsync();
                var member = JsonConvert.DeserializeObject<Member>(memberJson);
                return View(member);
            }

            return NotFound();
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _httpClient.DeleteAsync($"{id}");
            response.EnsureSuccessStatusCode();

            return RedirectToAction(nameof(Index));
        }
    }
}

