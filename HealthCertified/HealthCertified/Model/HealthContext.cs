using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HealthCertified.Model
{
    public class HealthContext:DbContext
    {
        public HealthContext(DbContextOptions<HealthContext> options) : base(options)
        {

        }
        public DbSet<CertifiedInfo> CertifiedInfo { get; set; }
        public DbSet<DeathCertified> DeathCertified { get; set; }
      //  public DbSet<DeceasedFormatDto> DeceasedFormatDto { get; set; }

    }
}
