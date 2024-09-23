using GestaoOcorrencias.Domain.Entities;
using GestaoOcorrencias.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoOcorrencias.Services.Service
{
    public class OcorrenciaService
    {
        private readonly IOcorrenciaRepository _ocorrenciaRepository;

        public OcorrenciaService(IOcorrenciaRepository ocorrenciaRepository)
        {
            _ocorrenciaRepository = ocorrenciaRepository;
        }

        public List<Ocorrencia> Listar()
        {
            return _ocorrenciaRepository.Listar();
        }
        public Ocorrencia Pesquisar(Guid Id)
        {
            return _ocorrenciaRepository.Pesquisar(Id);
        }
        public void Abertura(Ocorrencia ocorrencia)
        {
            _ocorrenciaRepository.Abertura(ocorrencia);
        }
        public void Atualizar(Ocorrencia ocorrencia, Guid Id)
        {
            _ocorrenciaRepository.Atualizar(ocorrencia, Id);
        }
        public void Excluir(Guid Id)
        {
            _ocorrenciaRepository.Excluir(Id);
        }
    }
}
