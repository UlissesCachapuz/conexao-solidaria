using ConexaoSolidaria.Models;
using Microsoft.AspNetCore.Mvc;
using ConexaoSolidaria.Data;
using System.Globalization;
//var apiKey = 'eyJvcmciOiI1YjNjZTM1OTc4NTExMTAwMDFjZjYyNDgiLCJpZCI6ImRjZjJhZWY2MTI3ODRiZTA5ZWZjMmViNTc4MWU4ODZlIiwiaCI6Im11cm11cjY0In0='; // crie uma em https://openrouteservice.org/dev/#/signup

namespace ConexaoSolidaria.Controllers
{
    [Route("[controller]")]
    public class PontoApoioController : Controller
    {
        private readonly AppDbContext _context;

        private readonly ILogger<PontoApoioController> _logger;

        public PontoApoioController(ILogger<PontoApoioController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("PontosApoio")]
        public IActionResult PontosApoio()
        {
            var pontoApoio = _context.PontosApoio.ToList();
            return View(pontoApoio);
        }
        [HttpGet("CadastrarPontoApoio")]
        public IActionResult PontoApoio()
        {
            return View();
        }

        [HttpPost("CadastrarPontoApoio")]
        public IActionResult PontoApoio(PontoApoio pontoApoio)
        {
            if (pontoApoio.Id > 0)
            {
                _context.PontosApoio.Update(pontoApoio);
                _context.SaveChanges();
                return RedirectToAction("PontosApoio");
            }
            else
            {
                _context.PontosApoio.Add(pontoApoio);
                _context.SaveChanges();
                return RedirectToAction("PontosApoio"); 
            }

        }

        [HttpGet("Excluir")]
        public IActionResult Excluir(int id)
        {
            var pontoApoio = _context.PontosApoio.Find(id);

            if (pontoApoio == null)
            {
                return NotFound();
            }
            _context.PontosApoio.Remove(pontoApoio);
            _context.SaveChanges();

            return RedirectToAction("pontosapoio");
        }

        [HttpGet("Editar")]
        public IActionResult PontoApoio(int id)
        {
            var pontoApoio = _context.PontosApoio.Find(id);

            if (pontoApoio == null)
                return NotFound();

            return View(pontoApoio);
        }
        [HttpPost("Editar")]
        public IActionResult Editar(PontoApoio pontoApoio)
        {
            if (ModelState.IsValid)
            {
                _context.PontosApoio.Update(pontoApoio);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pontoApoio);
        } 


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}