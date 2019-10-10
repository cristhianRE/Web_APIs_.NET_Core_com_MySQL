using Microsoft.AspNetCore.Http;
using System;

namespace MinhaWebAPI.Util
{
    public class Autenticacao
    {
        public static string TOKEN = "das98d7a9sd87a98d7a9s8d7";
        public static string FALHA_AUTENTICACAO = "Falha na Autenticação... O token informado é inválido! ";
        IHttpContextAccessor contextAccessor;

        public Autenticacao(IHttpContextAccessor context)
        {
            contextAccessor = context;
        }

        public void Autenticar()
        {
            try
            {
                string TokenRecebido = contextAccessor.HttpContext.Request.Headers["Token"].ToString();
                if (string.Equals(TOKEN, TokenRecebido) == false)
                {
                    throw new Exception(FALHA_AUTENTICACAO);
                }
            }
            catch (Exception)
            {
                throw new Exception(FALHA_AUTENTICACAO);
            }
        }
    }
}
