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
using DataAcessLayer.Mappings.DTOs;
using AutoMapper;
using BusinessLogicLayer.Images;

namespace HeroesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private readonly IHeroService _service;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;

        public HeroesController(IHeroService service, ITokenService tokenService, IMapper mapper, IImageService imageService)
        {
            _service = service;
            _tokenService = tokenService;
            _mapper = mapper;
            _imageService = imageService;
        }

        // GET: api/Heroes
        [HttpGet]
        public async Task<IActionResult> GetHeroesItems()
        {
            var hero = await _service.GetHeroItemsAsync();
            foreach (var heroITem in hero)
            {
                heroITem.Picture = await _service.GetPictureOfHero(heroITem.Id);
            }
            return Ok(hero);
        }

        [HttpGet("heropic")]
        public async Task<IActionResult> GetPictureOfHero(long id)
        {
            return Ok(await _service.GetPictureOfHero(id));
        }

        // GET: api/Heroes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHeroItem(long id)
        {
            var hero = await _service.GetHeroByIdAsync(id);

            if (hero == null)
            {
                return NotFound();
            }
            hero.Picture = await _service.GetPictureOfHero(id);
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
        //[Authorize(Policy = "RequireLoggedIn")]

        public async Task<IActionResult> PostHeroItem(FullInfoHeroDTO hero)
        {
            await _service.AddHeroAsync(hero);

            return CreatedAtAction(nameof(GetHeroItem), new { id = hero.Id }, hero);
        }

        // DELETE: api/Heroes/5
        [HttpDelete("{id}")]
        [Authorize(Policy = "RequireLoggedIn")]
        public async Task<IActionResult> DeleteHeroItem(long id)
        {
            await _service.DeleteHeroAsync(id);
            return Ok();
        }

        [HttpPost("addpower")]
        public async Task<IActionResult> AddPowerAsync([FromBody] PowerDTO power)
        {
            await _service.AddPowerAsync(power);
            return Ok("Power added successfully.");
        }

        [HttpPost("assign-power")]
        public async Task<IActionResult> AssignPowerToHeroAsync([FromBody] PowerAssignmentRequestDTO request)
        {
            await _service.AssignPowerToHeroAsync(request.HeroId, request.PowerId);
            return Ok("Power assigned to hero successfully.");
        }

        [HttpGet("{heroId}/powers")]
        public async Task<IActionResult> GetPowersForHeroAsync(long heroId)
        {
            var powers = await _service.GetPowersForHeroAsync(heroId);

            if (powers == null)
            {
                return NotFound();
            }
            var hero = await _service.GetHeroByIdAsync(heroId);

            var heroDTO = new HeroDTO
            {
                Id = heroId,
                Name = hero.Name, 
                Powers = _mapper.Map<IEnumerable<string>>(powers.Select(e => e.PowerTypeAsString))
            };

            return Ok(heroDTO);
        }

        [HttpPost("add-picture")]
        // [Authorize(Policy ="RequireLoggedIn")]
        public async Task<IActionResult> UploadPicture(long heroId, string url)
        {
            try
            {
                Image? image = await _imageService.UploadImageAsync(url, heroId);
                var hero = await _service.GetHeroItemByIdAsync(heroId);

                await _service.AddPictureToHeroASync(hero,image);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("image/{id}")]
        public async Task<IActionResult> GetImageById(int id)
        {
            var image = await _imageService.GetImageByIdAsync(id);
            if (image == null)
            {
                return NotFound();
            }
            return Ok(image);
        }

        [HttpGet("get-images")]
        public async Task<IActionResult> GetAllImages()
        {
            var images = await _imageService.GetAllImagesAsync();
            return Ok(images);
        }

        [HttpGet("get-powers-as-strings")]
        public async Task<IActionResult> GetPowersAsStrings()
        {
            return Ok(await _service.GetPowersAsStringsAsync());
        }


        private bool HeroItemExists(long id)
        {
            return _service.GetHeroByIdAsync(id).IsCompletedSuccessfully;
        }



    }
}


