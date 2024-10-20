namespace Product.Contracts.Events
{
    public class ProductCreated
    {
        public string product_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public decimal price { get; set; }
    }
}
