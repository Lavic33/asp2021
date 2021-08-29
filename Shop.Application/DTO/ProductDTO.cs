using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.DTO
{
   public class ProductDTO
    {
        public int Id { get; set; }

        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int BrendId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CategoryName { get; set; }
    }
}
