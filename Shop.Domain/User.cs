using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain
{
   public   class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }

        public ICollection<UserUseCase> UserUseCases { get; set; } = new HashSet<UserUseCase>();
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();




    }
}
