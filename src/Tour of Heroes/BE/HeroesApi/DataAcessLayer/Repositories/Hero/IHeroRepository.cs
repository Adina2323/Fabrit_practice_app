using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer.Mappings.DTOs;
using DataAcessLayer.Models;

namespace DataAcessLayer.Repositories.Hero
{
    public interface IHeroRepository
    {
        Task<IEnumerable<FullInfoHeroDTO>> GetHeroesAsync();
        Task<HeroItem?> GetHeroByIdAsync(long id);
        Task<HeroItem> AddHeroAsync(HeroItem heroItem);
        Task UpdateHeroAsync(HeroItem heroItem);
        Task DeleteHeroAsync(HeroItem heroItem);
        Task<IEnumerable<Power>> GetPowersAsync();

        Task<Power?> GetPowerByNameAsync(string name);

        Task<Power?> GetPowerByIdAsync(long id);
        Task<Power> AddPowerAsync(Power power);
        Task UpdatePowerAsync(Power power);
        Task DeletePowerAsync(Power power);
        Task AssignPowerToHeroAsync(long heroId, long powerId);

        Task<IEnumerable<Power>> GetPowersForHero(long heroId);

        Task AddPictureToHeroASync(HeroItem hero, Image image);

        Task<HeroItemPower> CreateHeroItemPower(HeroItem hero, Power power);

        Task AssignHeroToUserAsync(HeroItem hero, User user);
        Task SaveAllChangesAsync();

        Task<IEnumerable<Image>> GetImagesOfHeroByIdAsync(long Id);

    }
}
