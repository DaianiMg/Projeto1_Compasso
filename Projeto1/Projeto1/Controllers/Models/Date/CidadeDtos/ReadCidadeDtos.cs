using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto1.Controllers.Models.Date.CidadeDtos
{
    public class ReadCidadeDtos
    {

        [Required(ErrorMessage = "Esse Id já existe, tenta outro")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo Estado É obrigatório")]
        //[Required(ErrorMessage = "O campo Estado é obrigatório")]
        public string Estado { get; set; }
    }
}
