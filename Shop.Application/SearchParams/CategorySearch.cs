using Shop.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.SearchParams
{
    public class CategorySearch : Pagination
    {
        public int? Id { get; set; }
        public string CategoryName { get; set; }
    }
}
