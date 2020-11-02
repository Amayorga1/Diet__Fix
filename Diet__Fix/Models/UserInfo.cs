using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Diet__Fix.Models
{
    public class UserInfo 
    {
        public string Name { get; set; }
        public double BMI { get; set; }
        public string Diet { get; set; }
        public int Savings { get; set; }
        [Key]
        public string UserId { get; set; }
        [ForeignKey(name:"UserId")]
        public virtual IdentityUser User { get; set; }
    }
}
