using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacturaWeb.Models
{
    public class FilteredOrder
    {
        public int OrderID { get; set; }
        public Customer Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Active { get; set; }
        public List<OrderDetail> OrderDetail { get; set; }
    }
}