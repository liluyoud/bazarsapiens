using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BazarSapiens.Helpers
{
    public class PaginaHelper
    {
        public static string PaginaAtual(ViewContext context, string pagina, string classe)
        {
            string paginaAtual = context.RouteData.Values["Page"].ToString();
            return (paginaAtual.ToLower().IndexOf(pagina) >= 0) ? classe : "";
        }
    }
}
