using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaLab.Models;
using SistemaLab.Models.ViewModels;
using SistemaLab.Data;


namespace SistemaLab.Controllers;

public class LoginController : Controller
{
    private readonly ILogger<LoginController> _logger;

    private readonly SistemaLabContext _context;
    public LoginController(SistemaLabContext Context, ILogger<LoginController> Logger)
    {
        _context = Context;
        _logger = Logger;
    }

    public async Task<IActionResult> Index()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(User userData)
    {
        //Procura na tabela "User" do DB onde o email e senha fornecido coincidam utilizando-se da expressão lambda
        var user = _context.User.FirstOrDefault(user => user.Email == userData.Email && user.Password == userData.Password);

        //Se o usuário for encontrado
        if (user != null)
        {
            //Define o ID da sessão do usuário logado
            HttpContext.Session.SetString("UserType", user.UserType.ToString());

            _logger.LogInformation(HttpContext.Session.GetString("UserType"));

            //Retorna para a página Index do controlador especificado
            return RedirectToAction("Index", "HomePage");
        }
       
        //Se não for encontrado redireciona para a página de cadastro
        return RedirectToAction("Index", "Register");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
