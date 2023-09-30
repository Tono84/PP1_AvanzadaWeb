using System.ComponentModel.DataAnnotations;

namespace RestaurantApi.Models
{
    public class Restaurant
    {
        [Key]
        public int ID { get; set; }

        public string nombre { get; set; }

        public string dueño { get; set; }

        public string provincia { get; set;}

        public string cantón { get; set; }

        public string distrito { get; set; }

        public string dirección_exacta { get; set; }
    }
}
