using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CursoAPIRest.Data;
using CursoAPIRest.Models;
using Microsoft.AspNetCore.Authorization;

namespace CursoAPIRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CidadesController : ControllerBase
    {
        private readonly MeuBancoContext _context; // Injeção de Dependência

        public CidadesController(MeuBancoContext context)
        {
            _context = context;
        }

        // GET: api/Cidades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cidades>>> GetCidades()
        {
            return await _context.Cidades.ToListAsync();
        }

        // GET: api/Cidades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cidades>> GetCidades(int id)
        {
            var cidades = await _context.Cidades.FindAsync(id);

            if (cidades == null)
            {
                return NotFound();
            }

            return cidades;
        }

        [HttpGet]
        [Route("GetByName/{nome}")]
        public async Task<ActionResult<IEnumerable<Cidades>>> GetByNameCidades(string nome)
        {
            List<Cidades> cidades = await _context.Cidades.Where(c => c.Nome_cidade.Contains(nome)).ToListAsync();

            if (cidades == null || cidades.Count <= 0)
            {
                return NotFound($"Não existe a cidade {nome}");
            }

            return cidades;
        }

        // PUT: api/Cidades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCidades(int id, Cidades cidades)
        {
            if (id != cidades.Cod_cidade)
            {
                return BadRequest();
            }

            _context.Entry(cidades).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CidadesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Cidades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cidades>> PostCidades(Cidades cidades)
        {
            _context.Cidades.Add(cidades);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCidades", new { id = cidades.Cod_cidade }, cidades);
        }

        // DELETE: api/Cidades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCidades(int id)
        {
            var cidades = await _context.Cidades.FindAsync(id);
            if (cidades == null)
            {
                return NotFound();
            }

            _context.Cidades.Remove(cidades);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CidadesExists(int id)
        {
            return _context.Cidades.Any(e => e.Cod_cidade == id);
        }
    }
}
