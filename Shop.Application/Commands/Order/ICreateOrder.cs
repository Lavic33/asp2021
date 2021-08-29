using Shop.Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Commands.Order
{
   public interface ICreateOrderCommand : ICommand<OrderDTO>
    {
    }
}
