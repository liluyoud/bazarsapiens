using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BazarSapiens.Models
{
    public class Noticia
    {
        public long Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Titulo { get; set; }

        [Required]
        public string Corpo { get; set; }

        [Required]
        public DateTime DataPublicacao { get; set; }

        [Required]
        [StringLength(100)]
        public string Autor { get; set; }

        public string FotoPrincipal { get; set; }

        public string Tags { get; set; }

        public int TotalFotos { get; set; }

        public int Visualizacoes { get; set; }

        public Bazar Bazar { get; set; }

        public long? BazarId { get; set; }

    }
}
