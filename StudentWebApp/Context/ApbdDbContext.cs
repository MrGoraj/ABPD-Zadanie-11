using Microsoft.EntityFrameworkCore;
using StudentWebApp.Models;

namespace StudentWebApp.Context;

public class ApbdDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=APBD11;User ID=sa;Password=asd123POKo223;Encrypt=False");
    }
}