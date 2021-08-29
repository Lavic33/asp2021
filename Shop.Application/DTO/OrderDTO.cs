using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.DTO
{
   public class OrderDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string User { get; set; }
        public int OrderStatusId { get; set; }
        public string OrderStatus { get; set; }
        public string Note { get; set; }
    }
}
