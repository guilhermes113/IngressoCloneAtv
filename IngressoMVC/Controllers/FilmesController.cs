using IngressoMVC.Data;
using IngressoMVC.Models;
using IngressoMVC.Models.ViewModels.RequestDTO;
using IngressoMVC.Models.ViewModels.ResponseDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace IngressoMVC.Controllers
{
    public class FilmesController : Controller
    {
        private IngressoDbContext _context;

        public FilmesController(IngressoDbContext context)
        {
            _context = context;
        }

        public IActionResult Index() => View(_context.Filmes);

        public IActionResult Detalhes(int id) 
        {
            var resultado = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (resultado == null)
                return View("NotFound");

            GetFilmeDto filmeDto = new GetFilmeDto()
            {
                Id = resultado.Id,
                Titulo = resultado.Titulo,
                Descricao = resultado.Descricao,
                Preco = resultado.Preco,
                ImageURL = resultado.ImageURL,
                FotoURLCinema = _context.Cinemas.FirstOrDefault(x => x.Id == resultado.CinemaId).LogoURL
            };   

            return View(filmeDto);
        }

        public IActionResult Criar() => View();

        [HttpPost]
        IActionResult Criar(PostFilmeDTO filmeDto)
        {
            Filme filme = new Filme
                (
                    filmeDto.Titulo,
                    filmeDto.Descricao,
                    filmeDto.Preco,
                    filmeDto.ImageURL,
                    _context.Produtores
                        .FirstOrDefault(x => x.Id == filmeDto.ProdutorId).Id
                );

            _context.Add(filme);
            _context.SaveChanges();

            foreach (var cateId in filmeDto.CategoriasId)
            {
                var Novacate = new FilmeCategoria(cateId, filme.Id);
                _context.FilmesCategorias.Add(Novacate);
                _context.SaveChanges();
            }

            foreach (var atorId in filmeDto.AtoresId)
            {
                var novoAtor = new AtorFilme(atorId, filme.Id);
                _context.AtoresFilmes.Add(novoAtor);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Atualizar(int id)
        {
            var result = _context.Filmes.FirstOrDefault(x => x.Id == id);

            if (result == null)
                return View("NotFound");

            return View(result);
        }

        [HttpPost]
        public IActionResult Atualizar(int id, PostFilmeDTO filmeDto)
        {
            var result = _context.Filmes.FirstOrDefault(x => x.Id == id);

            if (!ModelState.IsValid)
                return View(result);

            result.AlterarDados(
                filmeDto.Titulo,
                filmeDto.Descricao,
                filmeDto.Preco,
                filmeDto.ImageURL);

            _context.Update(result);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Deletar(int id)
        {
            //buscar o filme no banco
            var result = _context.Filmes.FirstOrDefault(x => x.Id == id);

            if (result == null)
                return View("NotFound");
            //passar o filme na view
            return View(result);
        }

        [HttpPost, ActionName("Deletar")]
        public IActionResult ConfirmarDeletar(int id)
        {
            var result = _context.Filmes.FirstOrDefault(x => x.Id == id);

            _context.Remove(result);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
