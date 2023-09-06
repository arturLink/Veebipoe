namespace Veebipoe.Models
{
    public class CartProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ICollection<Product> Product { get; set; }
        public int OrderId { get; set; }
        public ICollection<Order> Order { get; set; }
        public int Quantity { get; set; }
    }
}
