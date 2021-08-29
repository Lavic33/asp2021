using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Queries
{
   public class Pagination
    {
        public int PerPage { get; set; } = 15;
        public int StartPage { get; set; } = 1;
    }
    public class PagedResponse<T> where T : class
    {
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public IEnumerable<T> Items { get; set; }

        public int PagesCount => (int)Math.Ceiling((float)TotalPages / ItemsPerPage);
    }
}
