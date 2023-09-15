using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudinaryDotNet.Actions;
using DataAcessLayer.Models;
using Microsoft.AspNetCore.Http;

namespace BusinessLogicLayer.Images
{
    public interface IImageService
    {
        Task<IEnumerable<Image>> GetAllImagesAsync();
        Task<Image> GetImageByIdAsync(int id);
        Task<Image> UploadImageAsync(string path, long heroId);
        Task<bool> DeleteImageAsync(int id);

        Task MakePictureMain(int id);

    }
}
