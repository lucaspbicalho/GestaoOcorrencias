using GestaoOcorrencias.Api.Configuration;
using GestaoOcorrencias.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoOcorrencias.Infrastructure.Contexts
{
    public class SqlServerContext : IContext
    {
        private readonly IAppConfig _appConfig;
        private static string _connectionString;
        private readonly ConnectionManager _connectionManager;

        public SqlServerContext(IAppConfig appConfig)
        {
            _appConfig = appConfig;
            _connectionString = _appConfig.ConnectionStrings.projGestaoOcorrencias;
            _connectionManager = new ConnectionManager(_connectionString);
        }

        public List<Cliente> GetClientes()
        {
            throw new NotImplementedException();
        }

        public void CreateCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Cliente ReadCliente(double ClienteId)
        {
            throw new NotImplementedException();
        }

        public void UpdateCliente(Cliente cliente, double Id)
        {
            throw new NotImplementedException();
        }

        public void DeleteCliente(double ClienteId)
        {
            throw new NotImplementedException();
        }

        public List<Ocorrencia> GetOcorrencias()
        {
            throw new NotImplementedException();
        }

        public void Abertura(Ocorrencia ocorrencia)
        {
            throw new NotImplementedException();
        }

        public Ocorrencia ReadOcorrencia(Guid Id)
        {
            throw new NotImplementedException();
        }

        public void UpdateOcorrencia(Ocorrencia ocorrencia, Guid Id)
        {
            throw new NotImplementedException();
        }

        public void DeleteOcorrencia(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
