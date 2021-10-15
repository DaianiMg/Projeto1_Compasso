using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto1.Controllers.Models
{
    //[Table("cidade")]
    public class Cidade
    {

        [Required(ErrorMessage = "Esse Id já existe, tenta outro")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo Estado É obrigatório")]
        //[Required(ErrorMessage = "O campo Estado é obrigatório")]
        public string Estado { get; set; }

        public virtual List<Cliente> Cliente { get; set; }

    }
}
    
