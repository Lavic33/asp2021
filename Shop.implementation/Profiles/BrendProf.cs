using AutoMapper;
using Shop.Application.DTO;
using Shop.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Implementation.Profiles
{

    public class BrendProf : Profile
    {
        public BrendProf()
        {

            CreateMap<Brend, BrendDTO>().ForMember(d => d.Id, opt => opt.MapFrom(c => c.Id))
                                                .ForMember(d => d.BrendName, opt => opt.MapFrom(c => c.BrendName));
        }

    }
}
