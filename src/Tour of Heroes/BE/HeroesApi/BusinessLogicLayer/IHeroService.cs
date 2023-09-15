using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer.Mappings.DTOs;
using DataAcessLayer.Models;

namespace BusinessLogicLayer
{
    public interface IHeroService
    {
        Task<IEnumerable<FullInfoHeroDTO>> GetHeroItemsAsync();
        Task<FullInfoHeroDTO?> GetHeroByIdAsync(long id);

        Task<HeroItem> GetHeroItemByIdAsync(long id);
        Task<HeroItem> AddHeroAsync(FullInfoHeroDTO heroDTO);
        Task UpdateHeroAsync(HeroItem heroItem);
        Task DeleteHeroAsync(long id);

        Task<Power?> GetPowerByNameAsync(string name);
        Task<Power?> GetPowerByIdAsync(long id);
        Task<Power> AddPowerAsync(PowerDTO power);
        Task UpdatePowerAsync(Power power);
        Task DeletePowerAsync(long id);
        Task AssignPowerToHeroAsync(long heroId, long powerId);
        Task<IEnumerable<Power>> GetPowersForHeroAsync(long heroId);

        Task AddPictureToHeroASync(HeroItem hero, Image image);

        Task AssignHerotoUser(string email, long id);

        Task<string> GetPictureOfHero(long id);

        Task<IEnumerable<string>> GetPowersAsStringsAsync();

    }
}
