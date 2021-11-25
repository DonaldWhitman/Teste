using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraAPI.Models
{
    public class FilmContext : DbContext 
    {
        public FilmContext(DbContextOptions<FilmContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Film> Films { get; set; }
    }
}
