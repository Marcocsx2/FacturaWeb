namespace FacturaWeb.Requests
{
    public class CreateOrderDetailRequest
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
    }
}
