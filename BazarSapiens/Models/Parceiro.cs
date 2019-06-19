using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BazarSapiens.Models
{
    public class Parceiro
    {
        public long Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public Bazar Bazar { get; set; }

        public long BazarId { get; set; }

        public int Visualizacoes { get; set; }
    }
}
