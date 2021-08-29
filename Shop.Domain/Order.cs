using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain
{
    public class Order : Entity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int OrderStatusId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string Note { get; set; }
        public ICollection<Product> Orders { get; set; } = new HashSet<Product>();

    }
}
