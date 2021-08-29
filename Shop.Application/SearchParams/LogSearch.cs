using Shop.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.SearchParams
{
    public class LogSearch : Pagination
    {
        public int? Id { get; set; }

        public string UseCase { get; set; }
        public string Username { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }




    }

}
