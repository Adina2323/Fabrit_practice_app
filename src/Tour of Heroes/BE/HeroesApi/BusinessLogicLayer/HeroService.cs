using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer.Repositories.Hero;
using DataAcessLayer.Models;
using DataAcessLayer.Repositories;

namespace BusinessLogicLayer
{
    public class HeroService : IHeroService
    {
        private readonly IHeroRepository _heroRepository;
        public HeroService(IHeroRepository heroRepository)
        {
            _heroRepository = heroRepository;
        }

        public async Task<IEnumerable<HeroItem>> GetHeroItemsAsync()
        {
            return await _heroRepository.GetHeroesAsync();
        }

        public async Task<HeroItem?> GetHeroByIdAsync(long id)
        {
            return await _heroRepository.GetHeroByIdAsync(id);
        }

        public async Task<HeroItem> AddHeroAsync(HeroItem heroItem)
        {
            return await _heroRepository.AddHeroAsync(heroItem);
        }

        public async Task UpdateHeroAsync(HeroItem heroItem)
        {
            await _heroRepository.UpdateHeroAsync(heroItem);
        }

        public async Task DeleteHeroAsync(HeroItem hero)
        {
            await _heroRepository.DeleteHeroAsync(hero);
        }


    }

}
