namespace AspNetBasicApplication.Model
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        public string Currency { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }

    public class Order
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Value { get; set; }
        public int CustomerID { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
