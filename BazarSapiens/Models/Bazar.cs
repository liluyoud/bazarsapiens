using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BazarSapiens.Models
{
    public class Bazar
    {
        public long Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public DateTime Inicio { get; set; }

        public DateTime Fim { get; set; }

        public SituacaoBazar Situacao { get; set; }

        public int Visualizacoes { get; set; }

        public ICollection<Produto> Produtos { get; set; }
    }

    public enum SituacaoBazar
    {
        NaoIniciado,
        EmAndamento,
        Finalizado,
        Cancelado
    }
}
