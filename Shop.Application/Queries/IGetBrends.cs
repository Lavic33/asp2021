using Shop.Application.DTO;
using Shop.Application.SearchParams;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Queries
{
   public interface IGetBrends : IQuery<BrendSearch, PagedResponse<BrendDTO>>
    {
    }
  
}
