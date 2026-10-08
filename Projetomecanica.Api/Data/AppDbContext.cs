using Microsoft.EntityFrameworkCore;
using Projetomecanica.Api.Models;

namespace Projetomecanica.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<User> Usuarios { get; set; }
        public DbSet<Veiculo> Veiculo { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
    }
}