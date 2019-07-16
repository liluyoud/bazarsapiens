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
    public class RolesModel : PageModel
    {
        private readonly BazarSapiens.Models.BazarContext _context;
        private readonly RoleManager<IdentityRole> _roles;

        public RolesModel(BazarSapiens.Models.BazarContext context, RoleManager<IdentityRole> roles)
        {
            _context = context;
            _roles = roles;
        }

        public IList<IdentityRole> Roles { get;set; }

        public async Task OnGetAsync()
        {
            var role = await _roles.FindByNameAsync("Administradores");
            if (role == null)
            {
                role = new IdentityRole();
                role.Name = "Administradores";
                await _roles.CreateAsync(role);
            }

            Roles = await _roles.Roles.ToListAsync();
        }


    }

  
}
