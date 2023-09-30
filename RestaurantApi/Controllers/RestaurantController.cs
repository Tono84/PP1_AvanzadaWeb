using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantApi.Data;
using RestaurantApi.Models;

namespace RestaurantApi.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly Context _context;

        public RestaurantController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Restaurant> Get()
        {

            var restaurantes = _context.Restaurantes.ToList();

            return restaurantes;

        }

        [HttpPost]
        public ActionResult <Restaurant> Post(Restaurant restaurant)
        {
            _context.Restaurantes.Add(restaurant);
            _context.SaveChanges();
            return Ok(restaurant);
        }
    }
}
