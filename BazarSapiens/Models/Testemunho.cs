using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BazarSapiens.Models
{
    public class Testemunho
    {
        public long Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Texto { get; set; }

        public string Autor { get; set; }

        public string Cargo { get; set; }

        public Bazar Bazar { get; set; }

        public long? BazarId { get; set; }

        public int Ordem { get; set; }

        [StringLength(20)]
        public string Foto { get; set; }
    }
}
