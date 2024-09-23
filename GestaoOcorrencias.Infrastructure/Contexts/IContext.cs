using GestaoOcorrencias.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoOcorrencias.Infrastructure.Contexts
{
    public interface IContext
    {
        public List<Cliente> GetClientes();
        public void CreateCliente(Cliente cliente);
        public Cliente ReadCliente(double ClienteId);
        public void UpdateCliente(Cliente cliente, double Id);
        public void DeleteCliente(double ClienteId);


        public List<Ocorrencia> GetOcorrencias();
        public void Abertura(Ocorrencia ocorrencia);
        public Ocorrencia ReadOcorrencia(Guid Id);
        public void UpdateOcorrencia(Ocorrencia ocorrencia, Guid Id);
        public void DeleteOcorrencia(Guid Id);
    }
}
