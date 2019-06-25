using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BazarSapiens.Models
{
    public class Produto
    {
        public long Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Nome { get; set; }

        [Required]
        [StringLength(5000)]
        public string Descricao { get; set; }

        [Required]
        public decimal ValorInicial { get; set; }

        [Required]
        public decimal ValorLance { get; set; }

        public decimal ValorAtual { get; set; }

        public int QuantidadeLances { get; set; }

        public int Visualizacoes { get; set; }

        public int TotalFotos { get; set; }

        public string FotoPrincipal { get; set; }

        [Required]
        [StringLength(10)]
        public string Estado { get; set; }

        public Categoria Categoria { get; set; }

        public long? CategoriaId { get; set; }

        public Bazar Bazar { get; set; }

        public long? BazarId { get; set; }

    }
}
