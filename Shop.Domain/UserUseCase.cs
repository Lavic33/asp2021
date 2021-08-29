using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain
{
    public class UserUseCase : Entity
    {
        public int UserId { get; set; }
        public int UseCaseId { get; set; }

        public User User { get; set; }



    }
}
