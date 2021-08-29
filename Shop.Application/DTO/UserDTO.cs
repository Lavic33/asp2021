using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.DTO
{
   public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
    }
}
