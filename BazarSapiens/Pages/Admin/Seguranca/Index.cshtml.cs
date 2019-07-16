using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BazarSapiens.Models;
using Microsoft.AspNetCore.Identity;

namespace BazarSapiens.Pages.Admin.Seguranca
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<Usuario> _userManager;

        public IndexModel(UserManager<Usuario> userManager)
        {
            _userManager = userManager;
        }

        public IList<UsuarioView> Usuarios { get; set; } = new List<UsuarioView>();

        public async Task OnGetAsync()
        {
            var users = await _userManager.Users.OrderBy(u => u.Nome).ToListAsync();
            foreach (var item in users)
            {
                Usuarios.Add(new UsuarioView()
                {
                    Cpf = item.UserName,
                    Nome = item.Nome,
                    Email = item.Email,
                    Telefone = item.PhoneNumber,
                    Admin = await _userManager.IsInRoleAsync(item, "Administradores")
                });
            }
        }
    }

    public class UsuarioView
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public bool Admin { get; set; }
    }
}
