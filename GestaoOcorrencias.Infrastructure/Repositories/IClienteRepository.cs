using GestaoOcorrencias.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoOcorrencias.Infrastructure.Repositories
{
    public interface IClienteRepository
    {
        public void Salvar(Cliente cliente);
        public void Cadastrar(Cliente cliente);        
        public void Atualizar(Cliente cliente, double Id);
        public void Excluir(double clienteId);
        public Cliente Pesquisar(double clienteId);
        public List<Cliente> Listar();

    }
}
