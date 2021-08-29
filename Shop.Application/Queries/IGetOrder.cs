using Shop.Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Queries
{
    public interface IGetOrder : IQuery<int, OrderDTO>
    {
    }
}
