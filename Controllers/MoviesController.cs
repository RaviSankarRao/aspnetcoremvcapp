using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using aspnetcoremvcapp.Data;
using aspnetcoremvcapp.Models;
using aspnetcoremvcapp.Repository;

namespace aspnetcoremvcapp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesRepository _moviesRepository;

        public MoviesController(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _moviesRepository.GetMovies());
        }

        public async Task<IActionResult> Details(int? id)
        {
            var movie = await _moviesRepository.GetMovieById(id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(ModelBinders.MovieCreate)] Movie movie)
        {
            if (ModelState.IsValid)
            {
                await _moviesRepository.AddMovie(movie);
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var movie = await _moviesRepository.FindMovie(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind(ModelBinders.MovieUpdate)] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _moviesRepository.UpdateMovie(movie);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var movie = await _moviesRepository.GetMovieById(id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _moviesRepository.FindMovie(id);
            if (movie != null)
            {
                await _moviesRepository.DeleteMovie(movie);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
          return _moviesRepository.MovieExists(id);
        }
    }
}
