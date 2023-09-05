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
using BusinessLogicLayer.Token;
using Microsoft.AspNetCore.Authorization;

namespace HeroesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private readonly IHeroService _service;
        private readonly ITokenService _tokenService;

        public HeroesController(IHeroService service, ITokenService tokenService )
        {
            _service = service;
            _tokenService = tokenService;
        }

        // GET: api/Heroes
        [HttpGet]
        public async Task<IActionResult> GetHeroesItems()
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
        public async Task<IActionResult> GetHeroItem(long id)
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
            return Ok(hero);
        }

        // PUT: api/Heroes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Policy = "RequireLoggedIn")]
        public async Task<IActionResult> PutHeroItem(
            long id,
            HeroItem hero)
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
        [Authorize(Policy = "RequireLoggedIn")]
        public async Task<IActionResult> PostHeroItem(HeroItem hero)
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
        [Authorize(Policy = "RequireLoggedIn")]
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
            return _service.GetHeroByIdAsync(id).IsCompletedSuccessfully;
        }
    }
}


