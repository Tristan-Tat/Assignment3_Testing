namespace Assignment3_Connection.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        // Kilogram
        public decimal Price { get; set; }
        // CAD price per Kg

        public Product(int id, string name, int weight, decimal price)
        {
            this.Id = id;
            this.Name = name;
            this.Weight = weight;
            this.Price = price;
        }
    }
}
