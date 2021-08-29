using Shop.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.SearchParams
{
   public class UserSearch : Pagination
    {
        public int? Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
