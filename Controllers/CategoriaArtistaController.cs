using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Artistas.Data;
using ArtistasApi.Models;

namespace Artistas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Categorias_ArtistasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public Categorias_ArtistasController(AppDbContext context)
        {
            _context = context;
        }

        // GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaArtista>>> Get()
        {
            return Ok(await _context.CategoriasArtista.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaArtista>> Get(int id)
        {
            var categoria = await _context.CategoriasArtista.FindAsync(id);
            if (categoria == null)
                return NotFound();
            return Ok(categoria);
        }

        // POST
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoriaArtista categoria)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.CategoriasArtista.Add(categoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = categoria.Id }, categoria);
        }

        // PUT 
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CategoriaArtista categoria)
        {
            if (id != categoria.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existe = await _context.CategoriasArtista.AnyAsync(c => c.Id == id);
            if (!existe)
                return NotFound();

            _context.Entry(categoria).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent(); 
        }

        // DELETE 
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var categoria = await _context.CategoriasArtista.FindAsync(id);
            if (categoria == null)
                return NotFound();

            _context.CategoriasArtista.Remove(categoria);
            await _context.SaveChangesAsync();

            return NoContent(); 
        }
    }
}

