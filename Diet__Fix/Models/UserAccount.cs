using System;
using System.Collections.Generic;

namespace Diet__Fix.Models
{
    public partial class UserAccount
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string MealLog { get; set; }
        public string UserProgression { get; set; }

        public virtual CostAnalysis CostAnalysis { get; set; }
        public virtual DietType DietType { get; set; }
    }
}
