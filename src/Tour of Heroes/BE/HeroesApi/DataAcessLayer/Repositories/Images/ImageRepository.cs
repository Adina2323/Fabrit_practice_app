using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer.Data;
using DataAcessLayer.Models;
using Microsoft.EntityFrameworkCore;


namespace DataAcessLayer.Repositories.Images
{
    public class ImageRepository : IImageRepository
    {
        private readonly DataContext _context;

        public ImageRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Image> AddAsync(Image image)
        {
            await _context.AddAsync(image);
            await _context.SaveChangesAsync();

            return image;
        }

        public async Task<IEnumerable<Image>> GetAllAsync()
        {
            return await _context.Images.ToListAsync();
        }

        public async Task<Image> GetByIdAsync(int id)
        {
            return await _context.Images.FindAsync(id);
        }

        public async Task MakeMainAsync(Image image)
        {
            image.IsMain = true;
            _context.Entry(image).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Remove(Image image)
        {
            _context.Images.Remove(image);
            await _context.SaveChangesAsync();
        }

    }
}
