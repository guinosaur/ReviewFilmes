using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReviewFilmes.Classes;
using ReviewFilmes.Dto;
using ReviewFilmes.Interfaces;
using ReviewFilmes.Repositories;

namespace ReviewFilmes.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class FilmeController : Controller
    {
        private readonly IFilmeRepository _filmeRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public FilmeController(IFilmeRepository filmeRepository, IMapper mapper, IReviewRepository reviewRepository)
        {
            _filmeRepository = filmeRepository;
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Filme))]
        [ProducesResponseType(400)]
        public IActionResult GetFilmes()
        {
            var filmes = _mapper.Map<List<FilmeDto>>(_filmeRepository.GetFilmes());

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(filmes);
        }

        [HttpGet("{filmeId}")]
        [ProducesResponseType(200, Type = typeof(Filme))]
        [ProducesResponseType(400)]
        public IActionResult GetFilme(int filmeId)
        {
            if (_filmeRepository.ExisteFilme(filmeId))
                return NotFound();
            
            var filme = _mapper.Map<FilmeDto>(_filmeRepository.GetFilme(filmeId));

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(filme);
        }

        [HttpGet("{filmeNome}")]
        [ProducesResponseType(200, Type = typeof(Filme))]
        [ProducesResponseType(400)]
        public IActionResult GetFilme(string filmeNome)
        {
            if (_filmeRepository.ExisteFilme(filmeNome))
                return NotFound();

            var filme = _mapper.Map<FilmeDto>(_filmeRepository.GetFilme(filmeNome));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(filme);
        }


        [HttpGet("{filmeId}/Nota")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetNotaFilme(int filmeId)
        {
            if (!_filmeRepository.ExisteFilme(filmeId))
                return NotFound();

            var nota = _filmeRepository.GetNotaFilme(filmeId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(nota);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateFilme([FromQuery]string nome, [FromQuery]string genero)
        {
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            if(_filmeRepository.CreateFilme(nome, genero))
            {
                return BadRequest(ModelState);
            }

            return Ok("Salvo com sucesso.");
        }

        [HttpDelete]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteFilme(int filmeId)
        {
            if (!_filmeRepository.ExisteFilme(filmeId))
                return NotFound();

            var filme = _filmeRepository.GetFilme(filmeId);

            var reviews = _reviewRepository.GetReviewsByFilme(filmeId);

            foreach (var review in reviews)
            {
                _reviewRepository.DeleteReview(review);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_filmeRepository.DeleteFilme(filme))
                ModelState.AddModelError("", "Algo deu errado.");

            return NoContent();
        }
    }
}
