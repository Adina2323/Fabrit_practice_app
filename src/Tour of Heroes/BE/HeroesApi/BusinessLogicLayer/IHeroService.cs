using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer.Models;

namespace BusinessLogicLayer
{
    public interface IHeroService
    {
        Task<IEnumerable<HeroItem>> GetHeroItemsAsync();
        Task<HeroItem> GetHeroByIdAsync(long id);
        Task<HeroItem> AddHeroAsync(HeroItem heroItem);
        Task UpdateHeroAsync(HeroItem heroItem);
        Task DeleteHeroAsync(HeroItem heroItem);

    }
}
