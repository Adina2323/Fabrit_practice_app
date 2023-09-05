using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataAcessLayer.Mappings.DTOs;
using DataAcessLayer.Models;

namespace DataAcessLayer.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<User, UserUpdateDTO>().ReverseMap();
            CreateMap<User, LoginDTO>().ReverseMap();
            CreateMap<User, RegisterDTO>().ReverseMap();
        }
    }
}
