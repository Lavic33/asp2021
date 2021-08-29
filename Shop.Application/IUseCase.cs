using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application
{
    public interface IUseCase
    {
        int Id { get; }
        string Name { get; }
    }
}
