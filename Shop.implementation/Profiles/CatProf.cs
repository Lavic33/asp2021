using AutoMapper;
using Shop.Application.DTO;
using Shop.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Implementation.Profiles
{
 
    public class CatProf : Profile
    {
        public CatProf()
        {

            CreateMap<Brend, CategoryDTO>().ForMember(d => d.Id, opt => opt.MapFrom(c => c.Id))
                                                .ForMember(d => d.CategoryName, opt => opt.MapFrom(c => c.CategoryName));
        }

    }
}
