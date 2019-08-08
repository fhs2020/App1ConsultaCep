using App1ConsultaCep.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace App1ConsultaCep.Services
{
    public class ViaCEPService
    {
        private static string EnderecoURL = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string novoEnderecoURL = string.Format(EnderecoURL, cep);

            WebClient wc = new WebClient();
            var conteudo = wc.DownloadString(novoEnderecoURL);

            Endereco endereco = JsonConvert.DeserializeObject<Endereco>(conteudo);

            if(endereco.Cep == null) return null;

            return endereco;
        }
    }
}
