using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class CompanyDto
    {
        public string companyName { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string OfficialPhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string WebsiteUrl { get; set; }

    }
}
