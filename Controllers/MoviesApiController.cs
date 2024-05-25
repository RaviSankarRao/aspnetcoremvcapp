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
        public async Task<List<Movie>> GetMovies()
        {
            return await _moviesRepository.GetMovies();
        }

        [Route("{id}")]
        public async Task<Movie> GetMovieById([FromRoute]int? id)
        {
            return await _moviesRepository.GetMovieById(id);
        }
    }
}
