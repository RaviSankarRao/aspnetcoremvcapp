using aspnetcoremvcapp.Data;
using aspnetcoremvcapp.Models;
using Microsoft.EntityFrameworkCore;

namespace aspnetcoremvcapp.Repository
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly MvcMovieContext _context;

        public MoviesRepository(MvcMovieContext context)
        {
            _context = context;
        }

        public async Task<List<Movie>> GetMovies()
        {
            var movies = _context.Movie != null ? await _context.Movie.ToListAsync() : new List<Movie>();
            return movies;
        }
        public async Task<Movie?> GetMovieById(int? id)
        {
            if (id == null || _context.Movie == null)
                return null;

            var movie = await _context.Movie.FirstOrDefaultAsync(m => m.Id == id);
            return movie;
        }

        public async Task<Movie?> FindMovie(int? id)
        {
            if (id == null || _context.Movie == null)
                return null;

            var movie = await _context.Movie.FindAsync(id);
            return movie;
        }

        public async Task AddMovie(Movie movie)
        {
            _context.Add(movie);
            await _context.SaveChangesAsync();
        }

        public bool MovieExists(int id)
        {
            return (_context.Movie?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task UpdateMovie(Movie movie)
        {
            try
            {
                _context.Update(movie);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteMovie(Movie movie)
        {
            if (movie != null)
            {
                _context.Movie.Remove(movie);
            }

            await _context.SaveChangesAsync();
        }
    }
}
