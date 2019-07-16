using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BazarSapiens.Models;
using Microsoft.AspNetCore.Identity;

namespace BazarSapiens.Pages.Admin.Seguranca
{
    public class EditModel : PageModel
    {
        private readonly BazarContext _context;
        private readonly UserManager<Usuario> _userManager;

        public EditModel(BazarContext context, UserManager<Usuario> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public Usuario Usuario { get; set; }

        public bool Administrador { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Usuario = await _userManager.FindByNameAsync(id);

            if (Usuario == null)
            {
                return NotFound();
            }

            Administrador = await _userManager.IsInRoleAsync(Usuario, "Administradores");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var usuario = await _userManager.FindByNameAsync(Usuario.UserName);
            usuario.Email = Usuario.Email;
            usuario.PhoneNumber = Usuario.PhoneNumber;
            usuario.Nome = Usuario.Nome;

            await _userManager.UpdateAsync(usuario);

            return RedirectToPage("./Index");
        }

    }   
}
