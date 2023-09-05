using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer.Data;
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

        public async Task<IEnumerable<HeroItem>> GetHeroesAsync()
        {
            return await _context.Heroes.ToListAsync();
        }

        public async Task<HeroItem?> GetHeroByIdAsync(long id)
        {
            return await _context.Heroes.FindAsync(id);
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
    }
}
