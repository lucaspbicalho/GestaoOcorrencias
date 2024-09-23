using GestaoOcorrencias.Domain.Entities;
using GestaoOcorrencias.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoOcorrencias.Infrastructure.Repositories
{
    public class OcorrenciaRepository : IOcorrenciaRepository
    {
        private readonly IContext _context;
        public OcorrenciaRepository()
        {
            _context = new Context();
        }
        public void Atualizar(Ocorrencia ocorrencia, Guid Id)
        {
            _context.UpdateOcorrencia(ocorrencia, Id);
        }

        public void Excluir(Guid Id)
        {
            _context.DeleteOcorrencia(Id);
        }

        public List<Ocorrencia> Listar()
        {
            return _context.GetOcorrencias();
        }

        public Ocorrencia Pesquisar(Guid Id)
        {
            return _context.ReadOcorrencia(Id);
        }

        //public void Salvar(Cliente cliente)
        //{
        //    _context.CreateCliente(cliente);
        //}

        public void Abertura(Ocorrencia ocorrencia)
        {
            _context.Abertura(ocorrencia);
        }
    }
}
