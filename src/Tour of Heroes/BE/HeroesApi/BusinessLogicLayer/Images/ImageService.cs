using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using BusinessLogicLayer.Images;
using CloudinaryDotNet.Actions;
using DataAcessLayer.Models;
using DataAcessLayer.Repositories.Hero;
using DataAcessLayer.Repositories.Images;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace BusinessLogicLayer.Images
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IHeroRepository _heroRepository;

        public ImageService(IImageRepository imageRepository, IHeroRepository heroRepository)
        {
            _imageRepository = imageRepository;
            _heroRepository = heroRepository;

        }

        public async Task<bool> DeleteImageAsync(int id)
        {
            var image = await _imageRepository.GetByIdAsync(id);
            if (image == null)
            {
                return false;
            }

            await _imageRepository.Remove(image);
            return true;
        }

        public async Task<IEnumerable<Image>> GetAllImagesAsync()
        {
            return await _imageRepository.GetAllAsync();
        }

        public async Task<Image> GetImageByIdAsync(int id)
        {
            return await _imageRepository.GetByIdAsync(id); 
        }

        public async Task MakePictureMain(int id)
        {
            var image = await _imageRepository.GetByIdAsync(id);
            await _imageRepository.MakeMainAsync(image);
        }

        public async Task<Image> UploadImageAsync(string url, long heroId)
        {
            var hero = await _heroRepository.GetHeroByIdAsync(heroId);
            if (hero == null)
            {
                throw new ArgumentException("Hero not found.");
            }

            if (hero.Images is null)
            {
                hero.Images = new List<Image>();
            }

            var image = new Image
            {
                Path = url,
                HeroId = heroId
            };

            var newImage = await _imageRepository.AddAsync(image);
            await _heroRepository.AddPictureToHeroASync(hero, newImage);

            return image;
        }
    }
}
