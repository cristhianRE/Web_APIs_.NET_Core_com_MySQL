using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MinhaWebAPI.Models;
using MinhaWebAPI.Util;

namespace MinhaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        Autenticacao AutenticacaoServico;

        public ClienteController(IHttpContextAccessor context)
        {
            AutenticacaoServico = new Autenticacao(context);
        }

        // GET api/cliente
        [HttpGet]
        [Route("listagem")]
        public List<ClienteModel> Listagem()
        {
            return new ClienteModel().Listagem();
        }

        // GET api/cliente/5
        [HttpGet]
        [Route("cliente/{id}")]
        public ClienteModel RetornarCliente(int id)
        {
            return new ClienteModel().RetornarCliente(id);
        }

        // POST api/cliente
        [HttpPost]
        [Route("registrarcliente")]
        public ReturnAllServices RegistrarCliente([FromBody] ClienteModel dados)
        {
            ReturnAllServices retorno = new ReturnAllServices();

            try
            {
                dados.RegistrarCliente();
                retorno.Result = true;
                retorno.ErrorMessage = string.Empty;
            }
            catch (Exception e)
            {
                retorno.Result = false;
                retorno.ErrorMessage = "Erro ao tentar registrar um cliente: " + e.Message;
            }
            return retorno;
        }

        // PUT api/cliente/5
        [HttpPut]
        [Route("atualizar/{id}")]
        public ReturnAllServices Atualizar(int id, [FromBody] ClienteModel dados)
        {
            ReturnAllServices retorno = new ReturnAllServices();

            try
            {
                dados.Id = id;
                dados.AtualizarCliente();
                retorno.Result = true;
                retorno.ErrorMessage = string.Empty;
            }
            catch (Exception e)
            {
                retorno.Result = false;
                retorno.ErrorMessage = "Erro ao tentar registrar um cliente: " + e.Message;
            }
            return retorno;
        }

        // DELETE api/cliente/5
        [HttpDelete]
        [Route("excluir/{id}")]
        public ReturnAllServices Excluir(int id)
        {
            ReturnAllServices retorno = new ReturnAllServices();
            try
            {
                retorno.Result = true;
                retorno.ErrorMessage = "Cliente Excluido com sucesso!";
                AutenticacaoServico.Autenticar();
                new ClienteModel().Excluir(id);
            }
            catch (Exception e)
            {
                retorno.Result = false;
                retorno.ErrorMessage = e.Message;
            }
            return retorno; 
        }
    }
}
