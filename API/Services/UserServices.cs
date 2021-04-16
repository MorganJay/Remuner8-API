using API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class UserServices
    {
        private UserManager<ApplicationUser> _userManager;
        private IConfiguration _configuration;
        private IMailService _mailService
    }
}
