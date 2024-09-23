namespace GestaoOcorrencias.Api
{
    using GestaoOcorrencias.Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration["ApiSettings:projGestaoOcorrencias"]);
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Ocorrencia> Ocorrencias { get; set; }
    }
}
