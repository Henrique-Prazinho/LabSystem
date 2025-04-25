using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SistemaLab.Models;
using SistemaLab.Models.ViewModels;

namespace SistemaLab.Controllers;

public class CustomersController : Controller
{
    public IActionResult Index()
    {
        List<Customer> customerList = new List<Customer>();
        customerList.Add(new Customer("Henrique", "prazinho000@gmail.com", 1));
        ViewData["User"] = customerList[0].Name;
        
        customerList.Add(new Customer("Riquito", "alfredinho9958@gmail.com", 2));

        return View(customerList);
    }
}