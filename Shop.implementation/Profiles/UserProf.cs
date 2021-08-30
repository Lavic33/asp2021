using AutoMapper;
using Shop.Application.DTO;
using Shop.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Implementation.Profiles
{
    
    public class UserProf : Profile
    {
        public UserProf()
        {
            CreateMap<User, UserDTO>().
                    ForMember(d => d.Id, opt => opt.MapFrom(u => u.Id)).
                    ForMember(d => d.FirstName, opt => opt.MapFrom(u => u.FirstName)).
                    ForMember(d => d.LastName, opt => opt.MapFrom(u => u.LastName)).
                    ForMember(d => d.City, opt => opt.MapFrom(u => u.City)).
                    ForMember(d => d.Adress, opt => opt.MapFrom(u => u.Adress)).
                    ForMember(d => d.Email, opt => opt.MapFrom(u => u.Email)).
          
        }
    }
}
