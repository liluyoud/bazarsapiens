using BazarSapiens.Models;
using BazarSapiens.Pages;
using BazarSapiens.Services;
using BazarSapiens.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace BazarSapiens.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class SegurancaController: Controller
    {
        private readonly BazarContext _context;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly UserManager<Usuario> _userManager;
        private readonly ILogger<SegurancaController> _logger;
        private readonly IMessageServices _messageServices;


        public SegurancaController(BazarContext db, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, IMessageServices messageServices, ILogger<SegurancaController> logger)
        {
            _context = db;
            _userManager = userManager;
            _signInManager = signInManager;
            _messageServices = messageServices;
            _logger = logger;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromForm] RegisterModel model, string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            var user = new Usuario { UserName = model.registerCpf, Email = model.registerEmail, PhoneNumber = model.registerCelular, Nome = model.registerNome };
            var result = await _userManager.CreateAsync(user, model.registerPassword);

            if (result.Succeeded)
            {
                _logger.LogInformation("Novo usuãrio criado com senha.");

                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var callbackUrl = Url.Page(
                    "/Account/ConfirmEmail",
                    pageHandler: null,
                    values: new { userId = user.Id, code = code },
                    protocol: Request.Scheme);

                await _signInManager.SignInAsync(user, isPersistent: false);
                await _messageServices.SendModeloEmailAsync(model.registerEmail, "ConfirmarEmail", model.registerNome, HtmlEncoder.Default.Encode(callbackUrl));
                TempData["Swal"] = $"Seja bem vindo;Parabéns {model.registerNome} por ter se juntado a nossa causa;success";
                return LocalRedirect(returnUrl);
            }

            return RedirectToPage("/Index");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromForm] LoginModel model, string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            var rememberMe = model.loginRememberMe == null ? false : true;
            var result = await _signInManager.PasswordSignInAsync(model.loginCpf, model.loginPassword, rememberMe, lockoutOnFailure: true);
            if (result.Succeeded)
            {
                _logger.LogInformation("Usuário fez login.");
                TempData["Swal"] = $"Seja bem vindo;Venha contribuir com o Bazar da Solidariedade;success";

                return LocalRedirect(returnUrl);
            }

            // If we got this far, something failed, redisplay form
            return RedirectToPage("/Index");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("Usuário fez logout.");
            TempData["Swal"] = $"Obrigado;Esperamos sua próxima visita ao nosso Bazar;success";
            return RedirectToPage("/Index");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([FromForm] ForgotModel model)
        {
            var user = await _userManager.FindByNameAsync(model.forgotCpf);
            if (user == null || user.Email.Trim().ToLower() != model.forgotEmail.Trim().ToLower())
            {
                TempData["Swal"] = $"Erro;Cpf e email inexistente;error";
                return RedirectToPage("/Index");
            }

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            var callbackUrl = Url.Page(
                "/Account/ResetPassword",
                pageHandler: null,
                values: new { code },
                protocol: Request.Scheme);

            await _messageServices.SendModeloEmailAsync(model.forgotEmail,"EsqueceuSenha", user.Nome, HtmlEncoder.Default.Encode(callbackUrl));

            TempData["Swal"] = $"Sucesso;Foi enviado um email para você atualizar sua senha;success";
            return RedirectToPage("/Index");
        }
    }

    public class RegisterModel
    {
        public string registerNome { get; set; }
        public string registerEmail { get; set; }
        public string registerCpf { get; set; }
        public string registerCelular { get; set; }
        public string registerPassword { get; set; }
        public string registerConfirmation { get; set; }
    }

    public class LoginModel
    {
        public string loginCpf { get; set; }
        public string loginPassword { get; set; }
        public string loginRememberMe { get; set; }
    }

    public class ForgotModel
    {
        public string forgotCpf { get; set; }
        public string forgotEmail { get; set; }
    }
}
