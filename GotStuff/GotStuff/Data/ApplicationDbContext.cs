using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GotStuff.Dtos;

namespace GotStuff.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<GotStuff.Models.Item> Item { get; set; }

        public DbSet<GotStuff.Models.StockItem> StockItem { get; set; }
    } 
}