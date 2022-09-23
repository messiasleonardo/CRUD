using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json.Nodes;
using TestingNewFeatures.Models;
using TestingNewFeatures.ViewModels;

namespace TestingNewFeatures.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HomeViewModel _model;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _model = new HomeViewModel();
        }

        public IActionResult Index()
        {
            return View(_model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult AlterarSenha(HomeViewModel homeViewModel)
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public string ValidarSenha(string senha)
        {
            if (senha == "123") return "Correct Passoword!";
            
            return "Wrong Password!";
        }
    }
}