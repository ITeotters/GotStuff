using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GotStuff.ViewModels;

namespace GotStuff.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<GotStuff.Models.KnownProduct> KnownProducts { get; set; }

        public DbSet<GotStuff.Models.Stock> Stock { get; set; }

        public DbSet<GotStuff.ViewModels.KnownProductVm> KnownProductVm { get; set; }
    } 
}