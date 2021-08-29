using AutoMapper;
using Shop.Application.DTO;
using Shop.DataAccess;
using Shop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Implementation.Profiles
{
  public  class LogProf : Profile
    {
        public LogProf(ShopContext context)
        {
            CreateMap<Log, GetLogDTO>()
                .ForMember(d => d.Id, opt => opt.MapFrom(c => c.Id))
                .ForMember(d => d.CreatedAt, opt => opt.MapFrom(c => c.CreatedAt))
                .ForMember(d => d.UseCase, opt => opt.MapFrom(c => c.UseCaseName))
                .ForMember(d => d.Data, opt => opt.MapFrom(c => c.Data))
                .ForMember(d => d.User, opt => opt.MapFrom(c => context.Users.Where(x => x.Email == c.Actor).Select(y => new UserDTO
                {

                    Id = y.Id,
                    FirstName = y.FirstName,
                    LastName = y.LastName,
                     Adress = y.Adress,
                        City = y.City,
                    Email = y.Email

                })));





        }
    }
  

}
