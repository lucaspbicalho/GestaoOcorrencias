using GestaoOcorrencias.Api.Configuration;
using GestaoOcorrencias.Domain.Entities;
using GestaoOcorrencias.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoOcorrencias.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IContext _context;
        private readonly IAppConfig _appConfig;
        public ClienteRepository()
        {
            //_context = new EntityContext();
            _context = new Context();
        }
        public void Atualizar(Cliente cliente, double Id)
        {
            _context.UpdateCliente(cliente, Id);
        }

        public void Excluir(double clienteId)
        {
            _context.DeleteCliente(clienteId);
        }

        public List<Cliente> Listar()
        {
            return _context.GetClientes();
        }

        public Cliente Pesquisar(double clienteId)
        {
            return _context.ReadCliente(clienteId);
        }

        public void Salvar(Cliente cliente)
        {
            _context.CreateCliente(cliente);
        }

        public void Cadastrar(Cliente cliente)
        {
            //Cliente novo = new Cliente()
            //{
            //    Id = Guid.NewGuid(),
            //    ClienteId = 1,
            //    Email = "teste@teste.com.br",
            //    Endereco = new Endereco()
            //    {
            //        Bairro = "Av do contorno",
            //        CEP = 123,
            //        Id = Guid.NewGuid(),
            //        Logradouro = "centro",
            //        UF = "MG"
            //    },
            //    Name = nome,
            //    Telefone = "31912341234"
            //};
        _context.CreateCliente(cliente);
        }
    }
}
