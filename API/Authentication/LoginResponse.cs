using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Authentication
{
    public class LoginResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string UserName { get; set; }
    }
}
