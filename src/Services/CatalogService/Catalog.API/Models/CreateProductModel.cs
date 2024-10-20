namespace Catalog.API.Models
{
    public class CreateProductModel
    {
        public string name { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public decimal price { get; set; }
    }
}
