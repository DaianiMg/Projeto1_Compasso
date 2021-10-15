using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Projeto1.Controllers.Models.Date.ClienteDtos
{
    public class CreateClienteDtos
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Data_Nascimento { get; set; }


        //[ForeignKey("Id")]
        public int CidadeId { get; set; }
        
        public string Cep { get; set; }

       
        public string Logradouro { get; set; }
        public string Bairro { get; set; }


    }

        


    
    

}

