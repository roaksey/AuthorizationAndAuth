using IdentityManager.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityManager.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions optioins):base(optioins) 
        {
             
        }

       public DbSet<ApplicationUser> ApplicationUser { get; set; }
    } 
}
