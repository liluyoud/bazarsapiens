using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BazarSapiens.Models
{
    public class Colaborador
    {
        public long Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public int Ordem { get; set; }

        [StringLength(20)]
        public string Foto { get; set; }

        [StringLength(100)]
        public string Facebook { get; set; }

        [StringLength(100)]
        public string Twitter { get; set; }

        [StringLength(100)]
        public string Instagram { get; set; }

        public Bazar Bazar { get; set; }

        public long? BazarId { get; set; }
    }
}
