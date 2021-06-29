using System;

namespace FacturaWeb.Requests
{
    public class CreateOrderRequest
    {
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
    }
}