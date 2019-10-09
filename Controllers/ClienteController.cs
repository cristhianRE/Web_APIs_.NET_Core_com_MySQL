﻿using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using MinhaWebAPI.Models;
using MinhaWebAPI.Util;

namespace MinhaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
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
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/cliente/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
