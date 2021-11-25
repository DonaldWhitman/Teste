using LocadoraAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraAPI.Repositories
{
    public interface IFilmRepository
    {
        Task<IEnumerable<Film>> Get();
        Task<Film> Get(int id);
        Task<Film> Create(Film film);
        Task Update(Film film);
        Task Delete(int id);
    }
}
