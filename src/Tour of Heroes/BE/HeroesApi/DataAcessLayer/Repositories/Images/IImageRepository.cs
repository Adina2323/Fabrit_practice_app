using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer.Models;

namespace DataAcessLayer.Repositories.Images
{
    public interface IImageRepository
    {
        Task<Image> GetByIdAsync(int id);
        Task<IEnumerable<Image>> GetAllAsync();
        Task<Image> AddAsync(Image entity);
        Task Remove(Image entity);

        Task MakeMainAsync(Image image);
    }
}
