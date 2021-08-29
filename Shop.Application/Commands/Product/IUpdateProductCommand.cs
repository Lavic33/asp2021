using Shop.Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Commands.Product
{
   public interface IUpdateProductCommand : ICommand<ProductDTO>
    {
    }
}
