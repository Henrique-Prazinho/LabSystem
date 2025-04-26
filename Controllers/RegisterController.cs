using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaLab.Data;
using SistemaLab.Models;

namespace SistemaLab.Controllers
{
    public class RegisterController : Controller
    {
        private readonly SistemaLabContext _context;
        public RegisterController(SistemaLabContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Password")] Register customer)
        {
            //Se o modelo de formulário for correto e a senha maior que 8 caracteres
            if (customer.Password.Length >= 8 && ModelState.IsValid) 
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();

                //Redirecionar para a página de login
                return RedirectToAction("Index", "Login");
            }
            else if(customer.Password.Length < 8)
            {
                ModelState.AddModelError("Password", "A senha deve conter 8 caracteres ou mais");
            }
            return RedirectToAction("Index");
        }
    }
}

