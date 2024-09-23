using GestaoOcorrencias.Api;
using GestaoOcorrencias.Api.Configuration;
using GestaoOcorrencias.Domain.Entities;
using GestaoOcorrencias.Infrastructure.Contexts;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoOcorrencias.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        public ClienteRepository(IConfiguration configuration, DataContext context)
        {
            _configuration = configuration;
            _context = context;
        }
        public void Atualizar(Cliente cliente, double Id)
        {
            Cliente clienteUpdate = _context.Clientes.FirstOrDefault(p => p.ClienteId == Id);
            _context.Clientes.Remove(clienteUpdate);
            cliente.Id = clienteUpdate.Id;
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public void Excluir(double clienteId)
        {
            Cliente cliente = _context.Clientes.FirstOrDefault(p => p.ClienteId == clienteId);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
            }
        }

        public List<Cliente> Listar()
        {
            return _context.Clientes
                 .OrderBy(p => p.ClienteId)
                 .ToList();
        }

        public Cliente Pesquisar(double clienteId)
        {
            return _context.Clientes.FirstOrDefault(p => p.ClienteId == clienteId);
        }

        public void Salvar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public void Cadastrar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }
    }
}
