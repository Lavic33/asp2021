using Shop.Application.DTO;
using Shop.Application.SearchParams;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Queries
{
    interface IGetUsers : IQuery<UserSearch,UserDTO>
    {
    }
}
