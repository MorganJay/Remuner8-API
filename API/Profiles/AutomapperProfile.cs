using API.Data_Models.Dtos;
using API.Models;
using AutoMapper;
using Remuner8_Backend.Dtos;
using Remuner8_Backend.EntityModels;
using Remuner8_Backend.Models;

namespace API.Profiles
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Password, PasswordReadDto>().ReverseMap();
            CreateMap<TimeSheet, TimeSheetDto>().ReverseMap();
            CreateMap<PasswordCreateDto, Password>().ReverseMap();
            CreateMap<PayrollAdditionItem, PayrollAdditionItemCreateDto>().ReverseMap();
        }
    }
}