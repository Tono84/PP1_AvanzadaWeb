using Microsoft.AspNetCore.Mvc;
using PracticaProgramada1_JoseSolorzano.Helper;
using PracticaProgramada1_JoseSolorzano.Models;
using System.Diagnostics;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text;
using System.Net.Http;

namespace PracticaProgramada1_JoseSolorzano.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        RestaurantAPI api = new RestaurantAPI();

        public async Task<IActionResult> Index()
        {
            List<Restaurant> restaurants = new List<Restaurant>();
            HttpClient client = api.Initial();
            HttpResponseMessage response = await client.GetAsync("api/Restaurant");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                restaurants = JsonSerializer.Deserialize<List<Restaurant>>(result);
            }
            return View(restaurants);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Restaurant restaurant)
        {
            try
            {
                string data = JsonSerializer.Serialize(restaurant);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

                HttpClient client = api.Initial();
                HttpResponseMessage response = await client.PostAsync("api/Restaurant", content);

                if (response != null && response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error in API request");
                    return View(restaurant);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error in API request: " + ex.Message);
                return View(restaurant);
            }
        }
        //[HttpPost]
        //public async Task<IActionResult> Create(Restaurant restaurant)
        //{
        //    try

        //    {
        //        if (restaurant == null)
        //            return BadRequest();
        //        string data = JsonSerializer.Serialize(restaurant);
        //        HttpClient client = api.Initial();
        //        HttpResponseMessage response = await client.GetAsync("api/Restaurant");
        //        var createdResaurant = await client.GetAsync(data);

        //        return CreatedAtAction(nameof(GetRestaurant),
        //            new { id = createdEmployee.EmployeeId }, createdEmployee);
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //            "Error creating new employee record");
        //    }

        //    return View(restaurant);
        //}



    }
}