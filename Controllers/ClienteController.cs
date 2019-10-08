using System;
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
        public ActionResult<IEnumerable<string>> Get()
        {
            DAL objDAL = new DAL();

           // string sql = "insert into cliente(nome, data_cadastro, cpf_cnpj, data_nascimento, tipo, telefone, email, cep, logradouro, numero, bairro, complemento, cidade, uf) " +
           //             " values('Felipe', '2018/05/22', '078989898', '1987/05/22','F', '324234234', 'felipe@hotmail.com', '3333333', 'Rua Teste', '123', 'Teste', '', 'Belo Horizonte', 'MG')";

            //objDAL.ExecutarComandoSQL(sql);

            return new string[] { "value1", "value2" };
        }

        // GET api/cliente/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            DAL objDAL = new DAL();

            string sql = $"select * from cliente where id = {id}";
            DataTable dt = objDAL.RetornarDataTable(sql);

            return dt.Rows[0]["Nome"].ToString();
        }

        // POST api/cliente
        [HttpPost]
        [Route("registrarcliente")]
        public ReturnAllServices RegistrarCliente([FromBody] ClienteModel dados )
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
