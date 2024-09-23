using GestaoOcorrencias.Api;
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
    public class OcorrenciaRepository : IOcorrenciaRepository
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        public OcorrenciaRepository(IConfiguration configuration, DataContext context)
        {
            _configuration = configuration;
            _context = context;
        }
        public void Atualizar(Ocorrencia ocorrencia, Guid Id)
        {
            Ocorrencia ocorrenciaUpdate = _context.Ocorrencias.FirstOrDefault(p => p.Id == Id);
            _context.Ocorrencias.Remove(ocorrenciaUpdate);
            ocorrencia.Id = ocorrenciaUpdate.Id;
            _context.Ocorrencias.Add(ocorrencia);
            _context.SaveChanges();
        }

        public void Excluir(Guid Id)
        {
            Ocorrencia ocorrencia = _context.Ocorrencias.FirstOrDefault(p => p.Id == Id);
            if (ocorrencia != null)
            {
                _context.Ocorrencias.Remove(ocorrencia);
                _context.SaveChanges();
            }
        }

        public List<Ocorrencia> Listar()
        {
            return _context.Ocorrencias
                 .OrderBy(p => p.DataAbertura)
                 .ToList();
        }

        public Ocorrencia Pesquisar(Guid Id)
        {
            return _context.Ocorrencias.FirstOrDefault(p => p.Id == Id);
        }

        public void Abertura(Ocorrencia ocorrencia)
        {
            _context.Ocorrencias.Add(ocorrencia);
            _context.SaveChanges();
        }
    }
}
