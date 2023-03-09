using Microsoft.AspNetCore.Mvc;
using ReviewFilmes.Interfaces;
using ReviewFilmes.Models;

namespace ReviewFilmes.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ReviewController : Controller
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewController(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Review))]
        [ProducesResponseType(400)]
        public IActionResult GetReviews()
        {
            var reviews = _reviewRepository.GetReviews();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reviews);
        }

        [HttpGet("{filmeId}")]
        [ProducesResponseType(200, Type = typeof(Review))]
        [ProducesResponseType(400)]
        public IActionResult GetReviewsByFilme(int filmeId)
        {
            if(!_reviewRepository.ExisteReviewFilme(filmeId))
                return NotFound();

            var reviews = _reviewRepository.GetReviewsByFilme(filmeId).ToList();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reviews);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateReview([FromQuery]string titulo, [FromBody]string texto, [FromQuery] int filmeId, [FromQuery] int nota)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_reviewRepository.CreateReview(titulo, texto, filmeId, nota))
            {
                return BadRequest(ModelState);
            }

            return Ok("Salvo com sucesso.");
        }

        [HttpDelete]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteReview(int reviewId)
        {
            var review = _reviewRepository.GetReviews().Where(r => r.Id == reviewId).FirstOrDefault();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!_reviewRepository.DeleteReview(review))
                ModelState.AddModelError("", "Algo deu errado.");

            return NoContent();
        }
    }
}
