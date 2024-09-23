using GestaoOcorrencias.Domain.Entities;
using GestaoOcorrencias.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteDelete
{
    public class FakeContext
    {
        private readonly IContext _context;

        public FakeContext()
        {
            _context = new Context();
        }

        public void TestarListagem()
        {
            List<Cliente> clietnes = _context.GetClientes();
        }
        public void TestarInclusao()
        {
          throw new NotImplementedException();
        }
    }
}
