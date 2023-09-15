using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer.Data;
using DataAcessLayer.Mappings.DTOs;
using DataAcessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAcessLayer.Repositories.Hero
{
    public class HeroRepository : IHeroRepository
    {
        private readonly DataContext _context;

        public HeroRepository(DataContext heroContext)
        {
            _context = heroContext;
        }

        public async Task<IEnumerable<FullInfoHeroDTO>> GetHeroesAsync()
        {
            var heroesWithPowerTypes = await _context
              .Heroes
              .Include(e => e.Powers)
              .Select(hero => new FullInfoHeroDTO
              {
                  Id = hero.Id,
                  Name = hero.Name,
                  Description = hero.Description,
                  Health = hero.Health,
                  BasicDamage = hero.BasicDamage,
                  Armour = hero.Armour,
                  Powers = hero.Powers.Select(power => power.Power.PowerTypeAsString).ToList()
              })
              .ToListAsync();

            return heroesWithPowerTypes;
        }

        public async Task<HeroItem?> GetHeroByIdAsync(long id)
        {
            return await _context
                .Heroes
                .Include(e => e.Powers)
                .ThenInclude(e => e.Power)
                .FirstOrDefaultAsync(e => e.Id ==id);
        }

        public async Task<HeroItem> AddHeroAsync(HeroItem heroItem)
        {
            _context.Heroes
                .Add(heroItem);
            await _context.SaveChangesAsync();
            return heroItem;
        }

        public async Task UpdateHeroAsync(HeroItem heroItem)
        {
            _context.Entry(heroItem).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
        public async Task DeleteHeroAsync(HeroItem hero)
        {
            _context.Heroes
                .Remove(hero);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool HeroItemExists(long id)
        {
            return (_context.Heroes?
                .Any(hero => hero.Id == id))
                .GetValueOrDefault();
        }

        public async Task<Power> AddPowerAsync(Power power)
        {
            _context.Powers.Add(power);
            await _context.SaveChangesAsync();
            return power;
        }

        public async Task DeletePowerAsync(Power power)
        {
            _context.Powers.Remove(power);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Power>> GetPowersAsync()
        {
            return await _context.Powers.ToListAsync();
        }

        public async Task<Power?> GetPowerByIdAsync(long id)
        {
            return await _context.FindAsync<Power>(id);
        }

        public async Task<Power?> GetPowerByNameAsync(string name)
        {
            return await _context
                .Powers
                .Where(e=>e.PowerTypeAsString == name)
                .FirstOrDefaultAsync();
        }

        public async Task UpdatePowerAsync(Power power)
        {
            _context.Entry(power).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }


        public async Task AssignPowerToHeroAsync(long heroId, long powerId)
        {
            var hero = await _context.Heroes.FindAsync(heroId);
            var power = await _context.Powers.FindAsync(powerId);

            if (hero != null && power != null)
            {
                var heroPower = new HeroItemPower
                {
                    Hero = hero,
                    Power = power
                };

                await _context.HeroPowers.AddAsync(heroPower);
                hero.Powers.Add(heroPower);
                power.HeroPowers.Add(heroPower);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Power>> GetPowersForHero(long heroId)
        {
            return await _context.HeroPowers
                .Where(hp => hp.HeroId == heroId)
                .Select(hp => hp.Power)
                .ToListAsync();
        }

        public async Task AddPictureToHeroASync(HeroItem hero, Image image)
        {
            
            try
            {
                image.Hero = hero;
                hero.Images.Add(image);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<HeroItemPower> CreateHeroItemPower(HeroItem hero, Power power)
        {
            var heroItemPower = new HeroItemPower
            {
                Hero = hero,
                HeroId = hero.Id,
                Power = power,
                PowerId = power.Id
            };
            await _context.HeroPowers.AddAsync(heroItemPower);
            await _context.SaveChangesAsync();
            return heroItemPower;
        }

        public async Task AssignHeroToUserAsync(HeroItem hero, User user)
        {
            user.HeroId = hero.Id;
            user.Hero = hero;
            
            var images = await  GetImagesOfHeroByIdAsync(hero.Id);

            if(images != null)
            {
                user.ProfilePictureId = images.FirstOrDefault()?.Id;
                user.ProfilePicture = images.FirstOrDefault();
            }
            
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task SaveAllChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Image>> GetImagesOfHeroByIdAsync(long Id)
        {
            return await _context
                .Images
                .Where(h => h.HeroId == Id)
                .ToListAsync();
        }
    }
}
