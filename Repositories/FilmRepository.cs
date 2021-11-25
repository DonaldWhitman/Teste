using LocadoraAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraAPI.Repositories
{
    public class FilmRepository : IFilmRepository
    {
        private readonly FilmContext _context;

        public FilmRepository(FilmContext context)
        {
            _context = context;
        }
        public async Task<Film> Create(Film film)
        {
            _context.Films.Add(film); 
            await _context.SaveChangesAsync();

            return film;
        }

        public async Task Delete(int id)
        {
            var filmToDelete = await _context.Films.FindAsync(id);
            _context.Films.Remove(filmToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Film>> Get()
        {
            return await _context.Films.ToListAsync();
        }

        public async Task<Film> Get(int id)
        {
            return await _context.Films.FindAsync(id);  
        }

        public async Task Update(Film film)
        {
            _context.Entry(film).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
