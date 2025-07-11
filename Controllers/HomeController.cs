using Microsoft.AspNetCore.Mvc;
using ConexaoSolidaria.Data;
//var apiKey = 'eyJvcmciOiI1YjNjZTM1OTc4NTExMTAwMDFjZjYyNDgiLCJpZCI6ImRjZjJhZWY2MTI3ODRiZTA5ZWZjMmViNTc4MWU4ODZlIiwiaCI6Im11cm11cjY0In0='; // crie uma em https://openrouteservice.org/dev/#/signup

namespace ConexaoSolidaria.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Ajuda()
        {
            return View();
        }
        public IActionResult Erro()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}