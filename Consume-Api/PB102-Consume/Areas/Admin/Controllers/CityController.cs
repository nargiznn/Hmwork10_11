using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using PB102_Consume.Areas.Admin.ViewModels;
using PB102_Consume.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PB102_Consume.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CityController : Controller
    {
        private readonly string BaseURl = "https://localhost:7001";
        public async Task<IActionResult> Index()
        {
            IEnumerable<CityVM> cities = null;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{BaseURl}/api/city/getall"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    cities = JsonConvert.DeserializeObject<IEnumerable<CityVM>>(apiResponse);
                }
            }
            return View(cities); 
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            IEnumerable<Country> countries = null;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{BaseURl}/api/country/getall"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    countries = JsonConvert.DeserializeObject<IEnumerable<Country>>(apiResponse);
                }
            }

            ViewBag.Countries = new SelectList(countries, "Id", "Name");

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CityCreateVM request)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync($"{BaseURl}/api/city/create", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync($"{BaseURl}/api/city/delete/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            CityVM city = null;
            IEnumerable<Country> countries = null;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{BaseURl}/api/city/getbyid/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    city = JsonConvert.DeserializeObject<CityVM>(apiResponse);
                }
            }

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{BaseURl}/api/country/getall"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    countries = JsonConvert.DeserializeObject<IEnumerable<Country>>(apiResponse);
                }
            }
            ViewBag.Countries = new SelectList(countries, "Id", "Name");

            return View(new CityEditVM
            {
                Id = city.Id,
                Name = city.Name,
                CountryId = city.CountryId
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CityEditVM request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            CityVM cityToUpdate = null;

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{BaseURl}/api/city/getbyid/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    cityToUpdate = JsonConvert.DeserializeObject<CityVM>(apiResponse);
                }
            }

            string newName = !string.IsNullOrEmpty(request.Name) ? request.Name : cityToUpdate.Name;
            int? newCountryId = request.CountryId.HasValue ? request.CountryId : cityToUpdate.CountryId;
            CityEditVM updatedCity = new CityEditVM
            {
                Id = id,
                Name = newName,
                CountryId = newCountryId
            };

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(updatedCity), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PutAsync($"{BaseURl}/api/city/edit/{id}", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            CityVM city = null;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{BaseURl}/api/city/getbyid/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    city = JsonConvert.DeserializeObject<CityVM>(apiResponse);
                }

            }

            return View(city);
        }
        [HttpGet]
        public async Task<IActionResult> Search(CityVM request)
        {
            IEnumerable<CityVM> cities = null;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{BaseURl}/api/city/search/" + request.Name))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    cities = JsonConvert.DeserializeObject<IEnumerable<CityVM>>(apiResponse);
                }
            }
            return View(cities);

        }
    }
}

