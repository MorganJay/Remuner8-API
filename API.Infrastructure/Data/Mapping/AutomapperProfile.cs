using API.Core.Dtos;
using API.Core.Entities;
using AutoMapper;

namespace API.Infrastructure.Data.Mapping
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
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
            CreateMap<EmploymentType, EmploymentTypeCreateDto>().ReverseMap();
            CreateMap<EmploymentType, EmploymentTypeReadDto>().ReverseMap();
            CreateMap<PayrollRate, PayrollRateCreateDto>().ReverseMap();
            CreateMap<PayrollRate, PayrollRateReadDto>().ReverseMap();
            CreateMap<PayrollCategory, PayrollCategoryReadDto>().ReverseMap();
            CreateMap<PayrollCategory, PayrollCategoryCreateDto>().ReverseMap();
            CreateMap<PayrollDefault, PayrollDefaultCreateDto>().ReverseMap();
            CreateMap<PayrollDefault, PayrollDefaultReadDto>().ReverseMap();

            //CreateMap<UserSignUpResource, AppIdentityUser>()
            //    .ForMember(u => u.UserName, opt => opt.MapFrom(ur => ur.Email));
        }
    }
}