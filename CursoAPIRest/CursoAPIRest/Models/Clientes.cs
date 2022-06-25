using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CursoAPIRest.Models
{
    public class Clientes
    {
        [Key]
        public int CodigoCliente { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }

        public int CodigoCidade { get; set; }

        [ForeignKey("CodigoCidade")]
        public Cidades Cidade { get; set; }
    }
}