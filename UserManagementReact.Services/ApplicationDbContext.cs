using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserManagementReact.Entities;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<Gender> Genders { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
