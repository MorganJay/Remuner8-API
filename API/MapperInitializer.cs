using API.Dtos;
using API.Models;
using API.Repositories;
using AutoMapper;

namespace API
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<IBonusRepository, BonusRepository>().ReverseMap();
            CreateMap<SystemDefault, SystemDefaultDto>().ReverseMap();
            CreateMap<IJobDescriptionRepository, JobDescriptionRepository>().ReverseMap();
            CreateMap<IUserAccountRepository, UserAccountsRepository>().ReverseMap();
            CreateMap<IEmployeeRepository, EmployeeRepository>().ReverseMap();
            CreateMap<IDepartmentRepository, DepartmentRepository>().ReverseMap();
            CreateMap<ITimeSheetRepository, TimeSheetRepository>().ReverseMap();
            CreateMap<IPayslipRepository, PayslipRepo>().ReverseMap();
            CreateMap<IPayrollItemsRepository, PayrollItemsRepository>().ReverseMap();
            CreateMap<IPayrollDeductionRepository, PayrollDeductionRepository>().ReverseMap();
            CreateMap<IPayrollOvertimeItemRepository, PayrollOvertimeItemRepository>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeCreateDto>().ReverseMap();
            CreateMap<EmploymentType, EmploymentTypeCreateDto>().ReverseMap();
            CreateMap<IStatisticsRepository, StatisticsRepository>().ReverseMap();
            CreateMap<IPayrollRateRepository, PayrollRateRepository>().ReverseMap();
            CreateMap<IRequestsRepository, RequestsRepository>().ReverseMap();
            CreateMap<IPayrollCategoryRepository, PayrollCategoryRepository>().ReverseMap();
            CreateMap<IPayrollDefaultRepository, PayrollDefaultRepository>().ReverseMap();
        }
    }
}