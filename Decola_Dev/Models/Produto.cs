using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Decola_Dev.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Range(1,1000, ErrorMessage = "O valor tem que esta entra 1 e 1000")]
        public int Quantidade { get; set; }

        public int CategoriaId { get; set; }

        public Categoria categoria { get; set; }

    }
    

}
