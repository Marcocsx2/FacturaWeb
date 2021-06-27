﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacturaWeb.Models
{
    public class SpecificOrder
    {

        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }


    }
}