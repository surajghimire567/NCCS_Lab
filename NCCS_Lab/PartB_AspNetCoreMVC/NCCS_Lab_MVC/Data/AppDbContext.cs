using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NCCS_Lab_MVC.Models;

namespace NCCS_Lab_MVC.Data
{
    // Q17: DbContext for Book entity.
    // Inherits IdentityDbContext so Q19 (ASP.NET Core Identity) shares the same database.
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; } = null!;
    }
}
