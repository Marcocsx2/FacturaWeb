namespace FacturaWeb.Models
{
    public class OrderDetail
    {
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public int Quantity { get; set; }
        public int ProductID { get; set; }
        public float Price { get; set; }
        public virtual Product Product { get; set; }
    }
}