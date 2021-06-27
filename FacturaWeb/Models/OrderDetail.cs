namespace FacturaWeb.Models
{
    public class OrderDetail
    {
        public int ProductID { get; set; }
        public int OrderID { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public virtual Product Products { get; set; }
        public virtual Order Orders { get; set; }
    }
}