using GestaoOcorrencias.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteDelete
{
    public class ServicoTeste
    {
        private readonly IClienteRepository _clienteRepository;
        public ServicoTeste(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        //to do
    }
}
