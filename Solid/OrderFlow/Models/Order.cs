namespace OrderFlow.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string Product { get; set; }

        public decimal Price { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}