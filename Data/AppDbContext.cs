using Microsoft.EntityFrameworkCore;
using ConexaoSolidaria.Models; // ajuste conforme o namespace do seu Model

namespace ConexaoSolidaria.Data
{
    public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Usuario> Usuarios { get; set; }
}
}
