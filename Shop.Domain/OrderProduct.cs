﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain
{
   public class OrderProduct
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int quantity { get; set; }
    }
}
