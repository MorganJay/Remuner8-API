using API.Data_Models.Dtos;
using API.Dtos;
using API.Models;
using AutoMapper;
using Remuner8_Backend.EntityModels;
using Remuner8_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Profiles
{
    public class PasswordsProfile : Profile
    {
        public PasswordsProfile()
        {
            CreateMap<Password, PasswordReadDto>().ReverseMap();
            CreateMap<TimeSheet, TimeSheetModel>().ReverseMap();


        }
    }
}
