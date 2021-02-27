using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class SystemDefault
    {
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string OfficialPhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string WebsiteUrl { get; set; }
        public string PostalCode { get; set; }
        public int MaxSalaryDays { get; set; }
        public DateTime SalaryStartDate { get; set; }
        public DateTime SalaryEndDate { get; set; }
    }
}
