using Shop.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.SearchParams
{
  public  class ProductSearch :Pagination
    {
        public int? Id { get; set; }

        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
