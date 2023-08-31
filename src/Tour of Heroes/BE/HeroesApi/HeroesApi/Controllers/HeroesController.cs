using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAcessLayer.Data;
using DataAcessLayer.Models;
using HeroesApi;
using BusinessLogicLayer;

namespace HeroesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private readonly IHeroService _service;

        public HeroesController(IHeroService service)
        {
            _service = service;
        }

        // GET: api/Heroes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HeroItem>>> GetHeroesItems()
        {
            if (await _service.GetHeroItemsAsync() == null)
            {
                return NotFound();
            }
            var hero = await _service.GetHeroItemsAsync();

            return Ok(hero);
        }

        // GET: api/Heroes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HeroItem>> GetHeroItem(long id)
        {
            if (await _service.GetHeroItemsAsync() == null)
            {
                return NotFound();
            }
            var hero = await _service.GetHeroByIdAsync(id);

            if (hero == null)
            {
                return NotFound();
            }

            return hero;
        }

        // PUT: api/Heroes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHeroItem(long id, HeroItem hero)
        {
            if (id != hero.Id)
            {
                return BadRequest();
            }

            try
            {
                await _service.UpdateHeroAsync(hero);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeroItemExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // POST: api/Heroes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HeroItem>> PostHeroItem(HeroItem hero)
        {
            if (await _service.GetHeroItemsAsync() == null)
            {
                return Problem("Entity set 'DataContext.Heroes'  is null.");
            }
            await _service.AddHeroAsync(hero);

            return CreatedAtAction(nameof(GetHeroItem), new { id = hero.Id }, hero);
        }

        // DELETE: api/Heroes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHeroItem(long id)
        {
            if (await _service.GetHeroItemsAsync() == null)
            {
                return NotFound();
            }
            var hero = await _service.GetHeroByIdAsync(id);
            if (hero == null)
            {
                return NotFound();
            }

            await _service.DeleteHeroAsync(hero);

            return NoContent();
        }

        private bool HeroItemExists(long id)
        {
            return (_service.GetHeroByIdAsync(id).IsCompletedSuccessfully ? true : false);

        }
    }
}


