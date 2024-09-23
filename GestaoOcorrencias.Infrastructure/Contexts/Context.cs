using GestaoOcorrencias.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoOcorrencias.Infrastructure.Contexts
{
    public class Context : IContext
    {
        private List<Cliente> _clientes;
        private List<Ocorrencia> _ocorrencias;

        public Context()
        {
            Cliente cliene01 = new Cliente()
            {
                Id = Guid.NewGuid(),
                ClienteId = 1,
                Email = "teste@teste.com.br",
                Cpf = "123456789",
                Endereco = new Endereco()
                {
                    Bairro = "Av do contorno",
                    CEP = 123,
                    Id = Guid.NewGuid(),
                    Logradouro = "centro",
                    UF = "MG"
                },
                Name = "teste",
                Telefone = "31912341234"
            };
            _clientes = new List<Cliente>()
            {
                cliene01
            };
          
            _ocorrencias = new List<Ocorrencia>()
            {
                new Ocorrencia()
                {
                   Id = Guid.NewGuid(),
                   DataAbertura = new DateTime(2024,8,21){ },
                   ResponsavelAbertura = cliene01,
                   DataOcorrencia = new DateTime(2024,8,22){ },
                   ResponsavelOcorrencia = cliene01,
                   Descricao = "Descrição",
                   Conclusao = "Conclusão"
                }
            };
        }
      
        public List<Cliente> GetClientes()
        {
            return _clientes
                 .OrderBy(p => p.ClienteId)
                 .ToList();
        }

        public void CreateCliente(Cliente cliente)
        {
            _clientes.Add(cliente);
        }
        public Cliente ReadCliente(double ClienteId)
        {
            return _clientes
                .FirstOrDefault(p => p.ClienteId == ClienteId);
        }

        public void UpdateCliente(Cliente cliente, double Id)
        {
            Cliente clienteUpdate = ReadCliente(Id);
            _clientes.Remove(clienteUpdate);
            cliente.Id = clienteUpdate.Id;
            _clientes.Add(cliente);

        }
        public void DeleteCliente(double ClienteId)
        {
            Cliente cliente = ReadCliente(ClienteId);
            if (cliente != null)
            {
                _clientes.Remove(cliente);
            }
        }

        //Ocorrencia
        public List<Ocorrencia> GetOcorrencias()
        {
            return _ocorrencias
                 .OrderBy(p => p.DataAbertura)
                 .ToList();
        }
        public void Abertura(Ocorrencia ocorrencia)
        {
            _ocorrencias.Add(ocorrencia);
        }
        public Ocorrencia ReadOcorrencia(Guid Id)
        {
            return _ocorrencias
                .FirstOrDefault(p => p.Id == Id);
        }
        public void UpdateOcorrencia(Ocorrencia ocorrencia, Guid Id)
        {
            Ocorrencia ocorrenciaUpdate = ReadOcorrencia(Id);
            _ocorrencias.Remove(ocorrenciaUpdate);
            ocorrencia.Id = ocorrenciaUpdate.Id;
            _ocorrencias.Add(ocorrencia);
        }
        public void DeleteOcorrencia(Guid Id)
        {
            Ocorrencia ocorrencia = ReadOcorrencia(Id);
            if (ocorrencia != null)
            {
                _ocorrencias.Remove(ocorrencia);
            }
        }
    }
}
