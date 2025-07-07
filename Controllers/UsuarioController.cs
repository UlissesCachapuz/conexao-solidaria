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
            var usuario = _context.Usuarios.ToList();
            return View(usuario);
            //return View();
        }


        // POST: Produto/Create
        [HttpPost]
        public IActionResult CadastroMoradorRua(Usuario usuario)
        {

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return Content("Usuário salvo com sucesso!");

            //return View();
        }

        [HttpGet("CadastrarMoradorRua")]
        public IActionResult CadastrarMoradorRua()
        {
            return View();
        }


        [HttpGet("Excluir")]
        public IActionResult Excluir(int id)
        {
            var usuario = _context.Usuarios.Find(id);

            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpGet("Editar")]
        public IActionResult Editar(int id)
        {
            var usuario = _context.Usuarios.Find(id);

            if (usuario == null)
                return NotFound();

            return View(usuario);
        }
        [HttpPost("Editar")]
        public IActionResult Editar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Usuarios.Update(usuario);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}