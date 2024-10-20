using System.ComponentModel.DataAnnotations;

namespace Catalog.API.Entities
{
    public class Product
    {
        [Key]
        public string product_id { get; set; } = Guid.NewGuid().ToString("D");
        public string name { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public decimal price { get; set; }
        public DateTime created_at { get; set; } = DateTime.UtcNow;
        public bool status { get; set; } = true;
    }
}
