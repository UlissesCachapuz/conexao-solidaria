using ConexaoSolidaria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConexaoSolidaria.Data;

namespace ConexaoSolidaria.Controllers
{
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        private readonly AppDbContext _context;

        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(ILogger<UsuarioController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet]
        public IActionResult CadastroMoradorRua()
        {
            var usuario = _context.Usuarios.FirstOrDefault(); // retorna o primeiro ou null
            return View(usuario);
            //return View();
        }


        // POST: Produto/Create
        [HttpPost]
        public IActionResult CadastroMoradorRua(Usuario usuario)
        {
            /*if (ModelState.IsValid)
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }*/

            var user = new Usuario
            {
                NomeCompleto = "João",
                NomeMae = "maria ",
                DataNascimento = "01/01/1990"
            };
            _context.Usuarios.Add(user);
            _context.SaveChanges();

            return Content("Usuário salvo com sucesso!");

            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}