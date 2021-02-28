using API.Models;
using AutoMapper;
using Remuner8_Backend.Dtos;
using Remuner8_Backend.EntityModels;
using Remuner8_Backend.Models;

namespace API.Profiles
{
    public class PasswordsProfile : Profile
    {
        public PasswordsProfile()
        {
            CreateMap<Password, PasswordReadDto>();
            CreateMap<PasswordCreateDto, Password>();
        }
    }
}