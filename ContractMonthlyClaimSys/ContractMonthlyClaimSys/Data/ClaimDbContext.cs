using Microsoft.EntityFrameworkCore;
using ContractMonthlyClaimSys.Models;

namespace ContractMonthlyClaimSys.Data
{
    // Database context for managing claims
    public class ClaimDbContext : DbContext
    {
        public ClaimDbContext(DbContextOptions<ClaimDbContext> options) : base(options) { }

        // DbSet for claims table
        public DbSet<ClaimModel> Claims { get; set; }
    }
}
