using GestaoOcorrencias.Api.Configuration;
using GestaoOcorrencias.Domain.Dtos;
using GestaoOcorrencias.Domain.Entities;
using GestaoOcorrencias.Infrastructure.Repositories;
using GestaoOcorrencias.Services.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace GestaoOcorrencias.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;
        private readonly IClienteRepository _clienteRepository;
        public ClienteController(ClienteService clienteService, IClienteRepository clienteRepository)
        {
            _clienteService = clienteService;
            _clienteRepository = clienteRepository;
        }
        
        //CREATE
        [HttpPost]
        [Route("Salvar")]
        public JsonResult Salvar(Cliente cliente)
        {
            try
            {
                //Cliente clienteDTO = converterEntidade();
                _clienteService.Cadastrar(cliente);
                return new JsonResult("Cliente efetuado com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //READ
        [HttpGet]
        public List<Cliente> Get()
        {
            try
            {
                List<Cliente> clientes = _clienteService.Listar();
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
        public Cliente Pesquisar(double Id)
        {
            try
            {
                Cliente cliente = _clienteService.Pesquisar(Id);
                return cliente;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //UPDATE
        [HttpPost]
        [Route("Atualizar")]
        public JsonResult Atualizar(Cliente cliente, double Id)
        {
            try
            {
                //Cliente clienteDTO = converterEntidade();
                _clienteService.Atualizar(cliente, Id);
                return new JsonResult("Cliente atualizado com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //DELETE
        [HttpDelete]
        [Route("Delete")]
        public JsonResult Delete(double Id)
        {
            try
            {
                //Cliente clienteDTO = converterEntidade();
                _clienteService.Excluir(Id);
                return new JsonResult("Cliente excluido com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
