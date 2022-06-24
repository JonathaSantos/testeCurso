using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CursoAPIRest.Models
{
    public class Cidades
    {
        [Key]
        public int Cod_cidade { get; set; }
        public string Nome_cidade { get; set; }
        public string Uf { get; set; }
    }
}