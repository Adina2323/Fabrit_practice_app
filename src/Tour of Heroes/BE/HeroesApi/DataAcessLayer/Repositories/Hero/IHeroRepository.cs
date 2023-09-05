using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer.Models;

namespace DataAcessLayer.Repositories.Hero
{
    public interface IHeroRepository
    {
        Task<IEnumerable<HeroItem>> GetHeroesAsync();
        Task<HeroItem?> GetHeroByIdAsync(long id);
        Task<HeroItem> AddHeroAsync(HeroItem heroItem);
        Task UpdateHeroAsync(HeroItem heroItem);
        Task DeleteHeroAsync(HeroItem heroItem);

    }
}
