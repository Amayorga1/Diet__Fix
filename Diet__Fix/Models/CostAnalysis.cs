using System;
using System.Collections.Generic;

namespace Diet__Fix.Models
{
    public partial class CostAnalysis
    {
        public int Id { get; set; }
        public string CostOptions { get; set; }
        public int? PastCost { get; set; }
        public int? CurrentCost { get; set; }
        public int? CostComparison { get; set; }
    }
}
