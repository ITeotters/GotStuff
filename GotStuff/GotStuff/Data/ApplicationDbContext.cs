using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GotStuff.ViewModels;
using GotStuff.Models;

namespace GotStuff.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<GotStuff.Models.KnownProduct> KnownProduct { get; set; }

        public DbSet<GotStuff.Models.StockProduct> StockProduct { get; set; }

        public DbSet<GotStuff.Models.Pantry> Pantry { get; set; }
    } 
}