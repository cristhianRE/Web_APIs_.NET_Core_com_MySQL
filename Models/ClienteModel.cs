using System;

using MinhaWebAPI.Util;

namespace MinhaWebAPI.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Data_Cadastro { get; set; }
        public string Cpf_Cnpj { get; set; }
        public string Data_Nascimento { get; set; }
        public string  Tipo { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }

        public void RegistrarCliente()
        {
            DAL objDAL = new DAL();

            string sql = " insert into cliente(nome, data_cadastro, cpf_cnpj, data_nascimento, tipo, telefone, email, cep, logradouro, numero, bairro, complemento, cidade, uf) " +
                        $" values('{Nome}', '{DateTime.Parse(Data_Cadastro).ToString("yyyy/MM/dd")}', '{Cpf_Cnpj}', " +
                        $" '{DateTime.Parse(Data_Nascimento).ToString("yyyy/MM/dd")}', '{Tipo}', '{Telefone}', '{Email}', " +
                        $" '{Cep}', '{Logradouro}', '{Numero}', '{Bairro}', '{Complemento}', '{Cidade}', '{UF}'); ";

            objDAL.ExecutarComandoSQL(sql);
        }
    }
}
