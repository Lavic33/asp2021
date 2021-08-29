using Shop.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.SearchParams
{
   public class OrderSearch :Pagination
    {
        public int? Id { get; set; }

        public string Keyword { get; set; }
        public DateTime? Date { get; set; }
       
    }
}
