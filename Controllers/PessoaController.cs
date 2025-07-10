using ConexaoSolidaria.Models;
using Microsoft.AspNetCore.Mvc;
using ConexaoSolidaria.Data;
using System.Globalization;
//var apiKey = 'eyJvcmciOiI1YjNjZTM1OTc4NTExMTAwMDFjZjYyNDgiLCJpZCI6ImRjZjJhZWY2MTI3ODRiZTA5ZWZjMmViNTc4MWU4ODZlIiwiaCI6Im11cm11cjY0In0='; // crie uma em https://openrouteservice.org/dev/#/signup

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
                //return RedirectToAction("Pessoas");
                return RedirectToAction("PessoaMapa", new
                {
                    necessidade = pessoa.Necessidade,
                    lat = pessoa.Latitude,
                    lng = pessoa.Longitude
                });
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
        [HttpGet]
        public IActionResult PessoaMapa(string necessidade, double lat, double lng)
        {
            var destino = ObterMaisProximo(necessidade, lat, lng);

            if (destino == null)
                return Content("Nenhum ponto de apoio encontrado.");

            ViewBag.Necessidade = necessidade;
            ViewBag.OrigemLat = lat.ToString(CultureInfo.InvariantCulture);
            ViewBag.OrigemLng = lng.ToString(CultureInfo.InvariantCulture);
            ViewBag.DestinoLat = destino.Latitude.ToString(CultureInfo.InvariantCulture);
            ViewBag.DestinoLng = destino.Longitude.ToString(CultureInfo.InvariantCulture);
            ViewBag.DestinoNome = destino.Nome;

            return View();
        }

        private PontoApoio ObterMaisProximo(string necessidade, double lat, double lng)
        {
            return _context.PontosApoio
                .Where(p => p.Tipo == necessidade)
                .OrderBy(p => Math.Pow(p.Latitude - lat, 2) + Math.Pow(p.Longitude - lng, 2))
                .FirstOrDefault();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}