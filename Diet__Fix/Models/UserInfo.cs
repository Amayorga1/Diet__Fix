using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diet__Fix.Models
{
    public class UserInfo : IdentityUser
    {
        public string Name { get; set; }
        public double BMI { get; set; }
        public string Diet { get; set; }
        public int Savings { get; set; }
    }
}
