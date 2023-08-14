using Microsoft.AspNetCore.Identity;
using PurityPlus.Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurityPlus.Services.DTO
{
    public class ApplicationUserDTO 
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string RefreshToken { get; set; }
    }
}
