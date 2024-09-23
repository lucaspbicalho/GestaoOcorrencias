using GestaoOcorrencias.Domain.Entities;
using GestaoOcorrencias.Services.Service;
using Microsoft.AspNetCore.Mvc;

namespace GestaoOcorrencias.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OcorrenciaController : ControllerBase
    {
        private readonly OcorrenciaService _ocorrenciaService;
        public OcorrenciaController(OcorrenciaService ocorrenciaService)
        {
            _ocorrenciaService = ocorrenciaService;
        }

        //CREATE
        [HttpPost]
        [Route("Abertura")]
        public JsonResult Abertura(Ocorrencia ocorrencia)
        {
            try
            {
                ocorrencia.Status = OcorrenciaStatus.Aberto;
                ocorrencia.Id = Guid.NewGuid();                
                _ocorrenciaService.Abertura(ocorrencia);
                return new JsonResult("Ocorrencia aberta com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //CREATE
        [HttpPost]
        [Route("CriarOcorrencia")]
        public JsonResult CriarOcorrencia(Cliente cliente)
        {
            try
            {               
                //_ocorrenciaService.Cadastrar(cliente);
                return new JsonResult("Cliente efetuado com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //CREATE
        [HttpPost]
        [Route("Conclusao")]
        public JsonResult Conclusao(Cliente cliente)
        {
            try
            {
                //_ocorrenciaService.Cadastrar(cliente);
                return new JsonResult("Cliente efetuado com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //READ
        [HttpGet]
        public List<Ocorrencia> Get()
        {
            try
            {
                List<Ocorrencia> clientes = _ocorrenciaService.Listar();
                return clientes;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //READ
        [HttpGet]
        [Route("Pesquisar")]
        public Ocorrencia Pesquisar(Guid Id)
        {
            try
            {
                Ocorrencia ocorrencia = _ocorrenciaService.Pesquisar(Id);
                return ocorrencia;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //UPDATE
        [HttpPut]
        [Route("Atualizar")]
        public JsonResult Atualizar(Ocorrencia ocorrencia, Guid Id)
        {
            try
            {              
                _ocorrenciaService.Atualizar(ocorrencia, Id);
                return new JsonResult("Ocorrencia atualizado com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //UPDATE
        [HttpPost]
        [Route("Avancar")]
        public JsonResult Avancar(Ocorrencia ocorrencia, Guid Id)
        {
            try
            {
                ocorrencia.Status = OcorrenciaStatus.EmProgresso;
                _ocorrenciaService.Atualizar(ocorrencia, Id);
                return new JsonResult("Ocorrencia atualizado com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //UPDATE
        [HttpPost]
        [Route("Fechar")]
        public JsonResult Fechar(Ocorrencia ocorrencia, Guid Id)
        {
            try
            {
                ocorrencia.Status = OcorrenciaStatus.Fechada;
                _ocorrenciaService.Atualizar(ocorrencia, Id);
                return new JsonResult("Ocorrencia atualizado com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //DELETE
        [HttpDelete]
        [Route("Delete")]
        public JsonResult Delete(Guid Id)
        {
            try
            {
                _ocorrenciaService.Excluir(Id);
                return new JsonResult("Ocorrencia excluido com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
