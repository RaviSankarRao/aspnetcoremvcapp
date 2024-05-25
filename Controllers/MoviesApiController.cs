using aspnetcoremvcapp.Models;
using aspnetcoremvcapp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcoremvcapp.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesApiController : ControllerBase
    {
        private readonly IMoviesRepository _moviesRepository;

        public MoviesApiController(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }

        [Route("")]
        public async Task<IActionResult> GetMovies()
        {
            var movies = await _moviesRepository.GetMovies();
            return Ok(movies);
        }

        [Route("{id}")]
        public async Task<IActionResult> GetMovieById([FromRoute]int? id)
        {
            var movie = await _moviesRepository.GetMovieById(id);

            if (movie == null)
            {
                return NotFound();
            }
            else
                return Ok(movie);
        }
    }
}
