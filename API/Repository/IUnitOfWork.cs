using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<AssigneeTable> Assigneetable { get; }
        IGenericRepository<Bonus> Bonus { get; }
        IGenericRepository<SystemDefault> SystemDefault { get; }
        IGenericRepository<Department> Department { get; }
        IGenericRepository<EmployeeBiodata> EmployeeBiodata { get; }
        IGenericRepository<EmploymentType> EmployementType { get; }
        IGenericRepository<JobDescription> JobDescrition { get; }
        IGenericRepository<LeaveType> LeaveType { get; }
        IGenericRepository<PayrollAdditionItem> PayrollAdditionItem { get; }
        IGenericRepository<PayrollAdditionItemsAssignment> PayrollAdditionItemAssignment { get; }
        IGenericRepository<PayrollCategory> PayrollCategory { get; }
        IGenericRepository<PayrollDeductionItem> PayrollDeductionItem { get; }
        IGenericRepository<PayrollDeductionItemsAssignment> PayrollDeductionItemAssignment { get; }
        IGenericRepository<PayrollDefault> PayrollDefault { get; }
        IGenericRepository<PayrollOvertimeItem> PayrollOvertimeItem { get; }
        IGenericRepository<PayrollOvertimeItemsAssignment> PayrollOvertimeItemAssignment { get; }
        IGenericRepository<PayrollRate> PayrollRate { get; }
        IGenericRepository<PayrollTransaction> PayrollTransaction { get; }
        IGenericRepository<Payslip> Payslip { get; }
        IGenericRepository<PensionFundAdministration> PensionFundAdministration { get; }
        IGenericRepository<RefreshToken> RefreshToken { get; }
        IGenericRepository<Request> Request { get; }
        IGenericRepository<StatutoryDeduction> StatutoryDeduction { get; }
        IGenericRepository<Tax> Tax { get; }
        IGenericRepository<TimeSheet> TimeSheet { get; }

        Task Save();
    }
}