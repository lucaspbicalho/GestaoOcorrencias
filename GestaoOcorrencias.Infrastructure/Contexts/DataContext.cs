namespace GestaoOcorrencias.Api
{
    using GestaoOcorrencias.Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Ocorrencia> Ocorrencias { get; set; }
    }
}
