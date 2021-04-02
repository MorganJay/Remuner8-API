using API.Data_Models.Dtos;
using API.Dtos;
using API.Models;
using AutoMapper;
using Remuner8_Backend.Dtos;
using Remuner8_Backend.EntityModels;

namespace API
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Password, PasswordReadDto>().ReverseMap();
            CreateMap<PasswordCreateDto, Password>().ReverseMap();

            CreateMap<EmployeeBiodata, EmployeeBiodataReadDto>();
            CreateMap<EmployeeBiodataCreateDto, EmployeeBiodata>().ReverseMap();
            CreateMap<EmployeeBiodata, EmployeeBiodataCreateDto>();

            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<Department, DepartmentCreateDto>().ReverseMap();

            CreateMap<TimeSheet, TimeSheetDto>().ReverseMap();

            CreateMap<PayrollAdditionItemCreateDto, PayrollAdditionItem>().ReverseMap();
            CreateMap<PayrollAdditionItem, PayrollAdditionItemReadDto>().ReverseMap();
            CreateMap<PayrollDeductionItem, PayrollDeductionItemReadDto>();
            CreateMap<PayrollDeductionItem, PayrollDeductionItemCreateDto>().ReverseMap();
            CreateMap<PayrollOvertimeItem, PayrollOvertimeItemCreateDto>().ReverseMap();
            CreateMap<PayrollOvertimeItem, PayrollOvertimeItemReadDto>().ReverseMap();
            CreateMap<JobDescription, JobDescriptionDto>().ReverseMap();

            CreateMap<Bonus, BonusDto>().ReverseMap();

            CreateMap<LeaveTypeCreateDto, LeaveType>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeReadDto>().ReverseMap();
            CreateMap<Request, RequestReadDto>().ReverseMap();
            CreateMap<Request, RequestCreateDto>().ReverseMap();
            CreateMap<PayrollRate, PayrollRateCreateDto>().ReverseMap();
            CreateMap<PayrollRate, PayrollRateReadDto>().ReverseMap();
        }
    }
}