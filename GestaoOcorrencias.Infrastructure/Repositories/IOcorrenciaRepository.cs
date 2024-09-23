using GestaoOcorrencias.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoOcorrencias.Infrastructure.Repositories
{
    public interface IOcorrenciaRepository
    {
        //public void Salvar(Cliente cliente);
        public void Abertura(Ocorrencia ocorrencia);        
        public void Atualizar(Ocorrencia ocorrencia, Guid Id);
        public void Excluir(Guid Id);
        public Ocorrencia Pesquisar(Guid Id);
        public List<Ocorrencia> Listar();

    }
}
