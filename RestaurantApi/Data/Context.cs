using Microsoft.EntityFrameworkCore;
using RestaurantApi.Models;

namespace RestaurantApi.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) 
        { 

        }

        public DbSet<Restaurant> Restaurantes { get; set; }
    }
}
