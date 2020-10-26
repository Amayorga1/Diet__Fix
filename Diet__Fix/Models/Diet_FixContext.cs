using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Diet__Fix.Models
{
    public partial class Diet_FixContext : IdentityDbContext
    {
        public Diet_FixContext()
        {
        }

        public Diet_FixContext(DbContextOptions<Diet_FixContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CostAnalysis> CostAnalysis { get; set; }
        public virtual DbSet<DietType> DietType { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
