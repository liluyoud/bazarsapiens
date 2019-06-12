using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BazarSapiens.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Descricao { get; set; }

        public ICollection<Produto> Produtos { get; set; }
    }
}
