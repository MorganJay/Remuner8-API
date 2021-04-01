using API.Data_Models.Dtos;
using API.Dtos;
using API.Models;
using AutoMapper;

namespace API.Profiles
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<EmployeeBiodata, EmployeeBiodataReadDto>();
            CreateMap<EmployeeBiodataCreateDto, EmployeeBiodata>().ReverseMap();
            CreateMap<EmployeeBiodata, EmployeeBiodataCreateDto>();

            CreateMap<TimeSheet, TimeSheetDto>().ReverseMap();

            CreateMap<PayrollAdditionItemCreateDto, PayrollAdditionItem>().ReverseMap();
            CreateMap<PayrollAdditionItem, PayrollAdditionItemReadDto>().ReverseMap();
            CreateMap<PayrollDeductionItem, PayrollDeductionItemReadDto>();
            CreateMap<PayrollDeductionItem, PayrollDeductionItemCreateDto>().ReverseMap();
            CreateMap<PayrollOvertimeItem, PayrollOvertimeItemCreateDto>().ReverseMap();
            CreateMap<PayrollOvertimeItem, PayrollOvertimeItemReadDto>().ReverseMap();

            CreateMap<LeaveTypeCreateDto, LeaveType>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeReadDto>().ReverseMap();
        }
    }
}