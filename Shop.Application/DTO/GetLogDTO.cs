using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.DTO
{
  public  class GetLogDTO
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public string UseCase { get; set; }

        public UserDTO User { get; set; }



        public DateTime CreatedAt { get; set; }

    }
}
