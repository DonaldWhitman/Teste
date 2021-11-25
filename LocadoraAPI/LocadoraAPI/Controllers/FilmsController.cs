using LocadoraAPI.Models;
using LocadoraAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly IFilmRepository _filmRepository;

        public FilmsController(IFilmRepository filmRepository)
        {
            _filmRepository = filmRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Film>> GetFilms()
        {
            return await _filmRepository.Get();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Film>> GetFilms(int id)
        {
            return await _filmRepository.Get(id);
        }
        [HttpPost]
        public async Task<ActionResult<Film>> PostFilms([FromBody] Film film)
        {
            var newFilm = await _filmRepository.Create(film);
            return CreatedAtAction(nameof(GetFilms), new { id = newFilm.Id }, newFilm);
        }

        [HttpPut]
        public async Task<ActionResult> PutFilms(int id, [FromBody] Film film)
        {
            if(id != film.Id)
            {
                return BadRequest();
            }

            await _filmRepository.Update(film);

            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete (int id)
        {
            var filmToDelete = await _filmRepository.Get(id);
            if (filmToDelete == null)
                return NotFound();

            await _filmRepository.Delete(filmToDelete.Id);
            return NoContent();
        }
    }
}
