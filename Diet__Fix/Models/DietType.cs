using System;
using System.Collections.Generic;

namespace Diet__Fix.Models
{
    public partial class DietType
    {
        public int Id { get; set; }
        public string KetoDesc { get; set; }
        public string PaleoDesc { get; set; }
        public string PescDesc { get; set; }
        public string MediDesc { get; set; }

        public virtual UserAccount IdNavigation { get; set; }
    }
}
