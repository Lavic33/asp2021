using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain
{
   public class Product : Entity
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int BrendId { get; set; }

        public Brend Brend { get; set; }
        public Brend Category { get; set; }

        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();

    }
}
