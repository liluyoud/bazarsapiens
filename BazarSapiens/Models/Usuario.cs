using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BazarSapiens.Models
{
    public class Usuario: IdentityUser
    {
        [Required]
        [StringLength(255)]
        public string Nome { get; set; }

        public string Cpf { get; set; }

        public string Endereco { get; set; }
    }
}
