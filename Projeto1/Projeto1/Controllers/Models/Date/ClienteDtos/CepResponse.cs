using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Projeto1.Controllers.Models.Date.ClienteDtos
{
    public class CepResponse
    {
        //DO VIACEP

        //[JsonProperty("cep")]
        public string cep { get; set; }

        //[JsonProperty("logradouro")]
        public string logradouro { get; set; }

        //[JsonProperty("complemento")]
        public string complemento { get; set; }

        //[JsonProperty("bairro")]
        public string bairro { get; set; }

        //[JsonProperty("localidade")]
        public string localidade { get; set; }

        //[JsonProperty("uf")]
        public string uf { get; set; }

        
    }

}
