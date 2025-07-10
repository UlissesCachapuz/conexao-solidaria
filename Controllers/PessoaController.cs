using ConexaoSolidaria.Models;
using Microsoft.AspNetCore.Mvc;
using ConexaoSolidaria.Data;

namespace ConexaoSolidaria.Controllers
{
    [Route("[controller]")]
    public class PessoaController : Controller
    {
        private readonly AppDbContext _context;

        private readonly ILogger<PessoaController> _logger;

        public PessoaController(ILogger<PessoaController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("Pessoas")]
        public IActionResult Pessoas()
        {
            var pessoa = _context.Pessoas.ToList();
            return View(pessoa);
        }
        [HttpGet("CadastrarPessoa")]
        public IActionResult Pessoa()
        {
            return View();
        }

        [HttpPost("CadastrarPessoa")]
        public IActionResult Pessoa(Pessoa pessoa)
        {
            if (pessoa.Id > 0)
            {
                _context.Pessoas.Update(pessoa);
                _context.SaveChanges();
                return RedirectToAction("Pessoas");
            }
            else
            {
                _context.Pessoas.Add(pessoa);
                _context.SaveChanges();

                return RedirectToAction("Pessoas");
            }

        }

        [HttpGet("Excluir")]
        public IActionResult Excluir(int id)
        {
            var pessoa = _context.Pessoas.Find(id);

            if (pessoa == null)
            {
                return NotFound();
            }
            _context.Pessoas.Remove(pessoa);
            _context.SaveChanges();

            return RedirectToAction("Pessoas");
        }

        [HttpGet("Editar")]
        public IActionResult Pessoa(int id)
        {
            var pessoa = _context.Pessoas.Find(id);

            if (pessoa == null)
                return NotFound();

            return View(pessoa);
        }
        [HttpPost("Editar")]
        public IActionResult Editar(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                _context.Pessoas.Update(pessoa);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pessoa);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}