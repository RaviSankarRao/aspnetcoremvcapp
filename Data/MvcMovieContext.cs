using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using aspnetcoremvcapp.Models;

namespace aspnetcoremvcapp.Data
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext (DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }

        public DbSet<aspnetcoremvcapp.Models.Movie> Movie { get; set; } = default!;
    }
}
