using Microsoft.EntityFrameworkCore;

namespace API.Models;

public class AppDataContext : DbContext
{
    public DbSet<Chamado> Chamados { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=LeonardoMoretti.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chamado>().HasData(
            new Chamado { ChamadoId = "6a8b3e4d-5e4e-4f7e-bdc9-9181e456ad0e", Descricao = "Formatar computador", CriadoEm = DateTime.Now.AddDays(7), Status = "Aberto" },
            new Chamado { ChamadoId = "2f1b7dc1-3b9a-4e1a-a389-7f5d2f1c8f3e", Descricao = "Trocar tinta da impressora", CriadoEm = DateTime.Now.AddDays(3), Status = "Aberto" },
            new Chamado { ChamadoId = "e5d4a7b9-1f9e-4c4a-ae3b-5b7c1a9d2e3f", Descricao = "Trocar teclado", CriadoEm = DateTime.Now.AddDays(14), Status = "Aberto" }
        );
    }
}
