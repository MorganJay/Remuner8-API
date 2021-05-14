using API.Models;
using System;
using System.Threading.Tasks;

namespace API.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Remuner8Context _context;

        private IGenericRepository<AssigneeTable> _assigneetable;
        private IGenericRepository<Bonus> _bonus;
        private IGenericRepository<SystemDefault> _systemDefaults;
        private IGenericRepository<Department> _department;
        private IGenericRepository<EmployeeBiodata> _employeeBiodata;
        private IGenericRepository<JobDescription> _jobDescription;
        private IGenericRepository<LeaveType> _leaveType;
        private IGenericRepository<PayrollAdditionItem> _payrollAdditionItem;
        private IGenericRepository<PayrollAdditionItemsAssignment> _payrollAdditionItemsAssignment;
        private IGenericRepository<PayrollCategory> _payrollCategory;
        private IGenericRepository<PayrollDeductionItem> _payrollDeductionItem;
        private IGenericRepository<PayrollDeductionItemsAssignment> _payrollDeductionItemsAssignment;
        private IGenericRepository<PayrollDefault> _payrollDefault;
        private IGenericRepository<PayrollOvertimeItem> _payrollOvertimeItem;
        private IGenericRepository<PayrollOvertimeItemsAssignment> _payrollOvertimeItemAssignment;
        private IGenericRepository<PayrollRate> _payrollRate;
        private IGenericRepository<PayrollTransaction> _payrollTransaction;
        private IGenericRepository<Payslip> _payslip;
        private IGenericRepository<PensionFundAdministration> _pensionFundAdministration;
        private IGenericRepository<RefreshToken> _refreshToken;
        private IGenericRepository<Request> _request;
        private IGenericRepository<StatutoryDeduction> _statutoryDeduction;
        private IGenericRepository<Tax> _tax;
        private IGenericRepository<TimeSheet> _timeSheet;
        private IGenericRepository<EmploymentType> _employmentType;

        public UnitOfWork(Remuner8Context context)
        {
            _context = context;
        }

        public IGenericRepository<AssigneeTable> Assigneetable => _assigneetable ??= new GenericRepository<AssigneeTable>(_context);

        public IGenericRepository<Bonus> Bonus => _bonus ??= new GenericRepository<Bonus>(_context);

        public IGenericRepository<SystemDefault> SystemDefault => _systemDefaults ??= new GenericRepository<SystemDefault>(_context);

        public IGenericRepository<Department> Department => _department ??= new GenericRepository<Department>(_context);

        public IGenericRepository<EmployeeBiodata> EmployeeBiodata => _employeeBiodata ??= new GenericRepository<EmployeeBiodata>(_context);

        public IGenericRepository<JobDescription> JobDescrition => _jobDescription ??= new GenericRepository<JobDescription>(_context);

        public IGenericRepository<LeaveType> LeaveType => _leaveType ??= new GenericRepository<LeaveType>(_context);

        public IGenericRepository<PayrollAdditionItem> PayrollAdditionItem => _payrollAdditionItem ??= new GenericRepository<PayrollAdditionItem>(_context);

        public IGenericRepository<PayrollAdditionItemsAssignment> PayrollAdditionItemAssignment => _payrollAdditionItemsAssignment ??= new GenericRepository<PayrollAdditionItemsAssignment>(_context);

        public IGenericRepository<PayrollCategory> PayrollCategory => _payrollCategory ??= new GenericRepository<PayrollCategory>(_context);

        public IGenericRepository<PayrollDeductionItem> PayrollDeductionItem => _payrollDeductionItem ??= new GenericRepository<PayrollDeductionItem>(_context);

        public IGenericRepository<PayrollDeductionItemsAssignment> PayrollDeductionItemAssignment => _payrollDeductionItemsAssignment ??= new GenericRepository<PayrollDeductionItemsAssignment>(_context);

        public IGenericRepository<PayrollDefault> PayrollDefault => _payrollDefault ??= new GenericRepository<PayrollDefault>(_context);

        public IGenericRepository<PayrollOvertimeItem> PayrollOvertimeItem => _payrollOvertimeItem ??= new GenericRepository<PayrollOvertimeItem>(_context);

        public IGenericRepository<PayrollOvertimeItemsAssignment> PayrollOvertimeItemAssignment => _payrollOvertimeItemAssignment ??= new GenericRepository<PayrollOvertimeItemsAssignment>(_context);

        public IGenericRepository<PayrollRate> PayrollRate => _payrollRate ??= new GenericRepository<PayrollRate>(_context);

        public IGenericRepository<PayrollTransaction> PayrollTransaction => _payrollTransaction ??= new GenericRepository<PayrollTransaction>(_context);

        public IGenericRepository<Payslip> Payslip => _payslip ??= new GenericRepository<Payslip>(_context);

        public IGenericRepository<PensionFundAdministration> PensionFundAdministration => _pensionFundAdministration ??= new GenericRepository<PensionFundAdministration>(_context);

        public IGenericRepository<RefreshToken> RefreshToken => _refreshToken ??= new GenericRepository<RefreshToken>(_context);

        public IGenericRepository<Request> Request => _request ??= new GenericRepository<Request>(_context);

        public IGenericRepository<StatutoryDeduction> StatutoryDeduction => _statutoryDeduction ??= new GenericRepository<StatutoryDeduction>(_context);

        public IGenericRepository<Tax> Tax => _tax ??= new GenericRepository<Tax>(_context);

        public IGenericRepository<TimeSheet> TimeSheet => _timeSheet ??= new GenericRepository<TimeSheet>(_context);

        public IGenericRepository<EmploymentType> EmployementType => _employmentType ??= new GenericRepository<EmploymentType>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}