using aspnetcoremvcapp.Models;

namespace aspnetcoremvcapp.Repository
{
    public interface IMoviesRepository
    {
        public Task<List<Movie>> GetMovies();

        public Task<Movie?> GetMovieById(int? id);

        public Task<Movie?> FindMovie(int? id);

        public Task AddMovie(Movie movie);

        public bool MovieExists(int id);

        public Task UpdateMovie(Movie movie);

        public Task DeleteMovie(Movie movie);
    }
}
