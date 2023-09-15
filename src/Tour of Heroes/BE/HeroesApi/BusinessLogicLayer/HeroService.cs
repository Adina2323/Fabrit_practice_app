using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer.Repositories.Hero;
using DataAcessLayer.Models;
using DataAcessLayer.Repositories;
using DataAcessLayer.Mappings.DTOs;
using AutoMapper;
using BusinessLogicLayer.Images;
using BusinessLogicLayer.Users;

namespace BusinessLogicLayer
{
    public class HeroService : IHeroService
    {
        private readonly IHeroRepository _heroRepository;
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public HeroService(IHeroRepository heroRepository, IMapper mapper, IImageService imageService, IUserService userService)
        {
            _heroRepository = heroRepository;
            _mapper = mapper;
            _imageService = imageService;
            _userService = userService;

        }

        public async Task<IEnumerable<FullInfoHeroDTO>> GetHeroItemsAsync()
        {
            return await _heroRepository.GetHeroesAsync();
        }

        public async Task<FullInfoHeroDTO?> GetHeroByIdAsync(long id)
        {
            var hero =  await _heroRepository.GetHeroByIdAsync(id);
            var powers = await _heroRepository.GetPowersForHero(id);
            var fullInfoHero = new FullInfoHeroDTO
            {
                Id = id,
                Name = hero.Name,
                Description = hero.Description,
                Health = hero.Health,
                BasicDamage = hero.BasicDamage,
                Armour = hero.Armour,
                Powers = _mapper.Map<IEnumerable<string>>(powers.Select(e => e.PowerTypeAsString))
            };
            return fullInfoHero;

        }
        public async Task<Power?> GetPowerByNameAsync(string name)
        {
            return await _heroRepository.GetPowerByNameAsync(name);
        }

        public async Task<HeroItem> AddHeroAsync(FullInfoHeroDTO heroDTO)
        {
            // Map the DTO to the entity and perform the add operation
            var heroItem = new HeroItem
            {
                Name = heroDTO.Name,
                Description = heroDTO.Description,
                Health = heroDTO.Health,
                BasicDamage = heroDTO.BasicDamage,
                Armour = heroDTO.Armour
            };

            var hero = await _heroRepository.AddHeroAsync(heroItem);

            await _imageService.UploadImageAsync(heroDTO.Picture, hero.Id);
            if (heroDTO.Powers!=null)
            {
                foreach(var power in heroDTO.Powers)
                    {
                    var p = await GetPowerByNameAsync(power);
                    await _heroRepository.AssignPowerToHeroAsync(hero.Id, p.Id);
                    }
            }
          
            if(heroDTO.Images!=null)
            {
                foreach (var image in heroDTO.Images)
                {
                    var newImage = await _imageService.UploadImageAsync(image, heroItem.Id);
                }

            }
           
            await _heroRepository.SaveAllChangesAsync();

            return heroItem;
        }



        public async Task UpdateHeroAsync(HeroItem heroItem)
        {
            await _heroRepository.UpdateHeroAsync(heroItem);
        }

        public async Task DeleteHeroAsync(long id)
        {
            var hero = await _heroRepository.GetHeroByIdAsync(id);

            if (hero != null)
            {
                await _heroRepository.DeleteHeroAsync(hero);
            }
        }

        public async Task<Power> AddPowerAsync(PowerDTO powerDTO)
        {
            var power = _mapper.Map<Power>(powerDTO);
            return await _heroRepository.AddPowerAsync(power);
        }

        public async Task DeletePowerAsync(long id)
        {
            var power = await GetPowerByIdAsync(id);
            await _heroRepository.DeletePowerAsync(power);
        }

        public async Task<IEnumerable<string>> GetPowersAsStringsAsync()
        {

           var powers = await _heroRepository.GetPowersAsync();
            var strings = new List<string>();
            foreach(var power in powers)
            {
                strings.Add(power.PowerTypeAsString);
            }
            return strings;
        }

        public async Task<Power?> GetPowerByIdAsync(long id)
        {
            return await _heroRepository.GetPowerByIdAsync(id);
        }

        public async Task UpdatePowerAsync(Power power)
        {
            await _heroRepository.UpdatePowerAsync(power);
        }

        public async Task AssignPowerToHeroAsync(long heroId, long powerId)
        {

            await _heroRepository.AssignPowerToHeroAsync(heroId, powerId);
        }

        public async Task<IEnumerable<Power>> GetPowersForHeroAsync(long heroId)
        {
            return await _heroRepository.GetPowersForHero(heroId);
        }

        public async Task AddPictureToHeroASync(HeroItem hero, Image image)
        {
            await _heroRepository.AddPictureToHeroASync(hero, image);
        }

        public async Task<HeroItem?> GetHeroItemByIdAsync(long id)
        {
            return await _heroRepository.GetHeroByIdAsync(id);
        }

        public async Task AssignHerotoUser(string email, long id)
        {
            var user = await _userService.GetUserByEmailAsync(email);
            var hero = await _heroRepository.GetHeroByIdAsync(id);

            await _heroRepository.AssignHeroToUserAsync(hero, user);
        }

        public async Task<string> GetPictureOfHero(long id)
        {

            var imgs =  await _heroRepository.GetImagesOfHeroByIdAsync(id);
            var image = imgs.FirstOrDefault();
            if (image == null)
            {
                return string.Empty;
            }
            return image.Path;
        }

      

    }

}
