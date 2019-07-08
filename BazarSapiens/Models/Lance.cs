using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BazarSapiens.Models
{
    public class Lance
    {
        public long Id { get; set; }

        public Produto Produto { get; set; }

        public long? ProdutoId { get; set; }

        public decimal Valor { get; set; }

        public DateTime DataHora { get; set; }

        [StringLength(255)]
        public string Usuario { get; set; }
    }
}
