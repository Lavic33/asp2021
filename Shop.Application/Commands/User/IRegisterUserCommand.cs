using Shop.Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Commands.User
{
   public interface IRegisterUserCommand : ICommand<UserDTO>
    {
    }
}
