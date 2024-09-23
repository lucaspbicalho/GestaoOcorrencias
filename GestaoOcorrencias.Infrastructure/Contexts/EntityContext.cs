using GestaoOcorrencias.Domain.Entities;
using System;
using GestaoOcorrencias.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestaoOcorrencias.Infrastructure.Contexts
{
    public class EntityContext : DbContext, IContext
    {
  
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Ocorrencia> Ocorrencias { get; set; }

        public void Abertura(Ocorrencia ocorrencia)
        {
            throw new NotImplementedException();
        }

        public void CreateCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void DeleteCliente(double ClienteId)
        {
            throw new NotImplementedException();
        }

        public void DeleteOcorrencia(Guid Id)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> GetClientes()
        {
            return Clientes
                 .OrderBy(p => p.ClienteId)
                 .ToList();
        }

        public List<Ocorrencia> GetOcorrencias()
        {
            throw new NotImplementedException();
        }

        public Cliente ReadCliente(double ClienteId)
        {
            throw new NotImplementedException();
        }

        public Ocorrencia ReadOcorrencia(Guid Id)
        {
            throw new NotImplementedException();
        }

        public void UpdateCliente(Cliente cliente, double Id)
        {
            throw new NotImplementedException();
        }

        public void UpdateOcorrencia(Ocorrencia ocorrencia, Guid Id)
        {
            throw new NotImplementedException();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\lucas\\source\\repos\\GestaoOcorrencias\\GestaoOcorrencias.Infrastructure\\App_Data\\Database.mdf;Integrated Security=True");
        }

    }
}
