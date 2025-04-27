using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaLab.Models;

namespace SistemaLab.Controllers
{
    public class HomePageController : Controller
    {
        public IActionResult Index()
        {
            //Recupera o tipo de usuário que realizou login
            var userType = HttpContext.Session.GetString("UserType");

            //Cria uma instância do tipo de usuário para aplicar permissões/layout
            HomePage setHomePageByType = new HomePage(userType);

            //Retorna a view com a instância do modelo
            return View(setHomePageByType);            
        }
    }
}
