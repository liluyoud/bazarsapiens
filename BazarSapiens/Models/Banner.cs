using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BazarSapiens.Models
{
    public class Banner
    {
        public long Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Titulo { get; set; }

        [Required]
        [StringLength(255)]
        public string Subtitulo { get; set; }

        public string Conteúdo { get; set; }

        [StringLength(255)]
        public string Url { get; set; }
    }
}
