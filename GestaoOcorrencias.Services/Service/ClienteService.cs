using GestaoOcorrencias.Domain.Entities;
using GestaoOcorrencias.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoOcorrencias.Services.Service
{
    public class ClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public List<Cliente> Listar()
        {
            return _clienteRepository.Listar();
        }
        public Cliente Pesquisar(double ClienteId)
        {
            return _clienteRepository.Pesquisar(ClienteId);
        }
        public void Cadastrar(Cliente cliente)
        {
            _clienteRepository.Cadastrar(cliente);
        }
        public void Atualizar(Cliente cliente, double Id)
        {
            _clienteRepository.Atualizar(cliente, Id);
        }
        public void Excluir(double ClienteId)
        {
            _clienteRepository.Excluir(ClienteId);
        }
    }
}
