using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultiShop.Images.Context;
using MultiShop.Images.Dtos;
using MultiShop.Images.Entities;

namespace MultiShop.Images.Services.ImageServices
{
    public class ImageService : IImageService
    {
        private readonly ImagesContext _context;
        private readonly ICloudStorageService _cloudStorageService;
        private readonly IMapper _mapper;

        public ImageService(ImagesContext context, ICloudStorageService cloudStorageService, IMapper mapper)
        {
            _context = context;
            _cloudStorageService = cloudStorageService;
            _mapper = mapper;
        }

        private async Task GenerateSignedUrl(ImageDrive image)
        {
            // Get Signed URL only when Saved File Name is available.
            if (!string.IsNullOrWhiteSpace(image.SavedFileName))
            {
                image.SignedUrl = await _cloudStorageService.GetSignedUrlAsync(image.SavedFileName);
            }
        }
        private string? GenerateFileNameToSave(string incomingFileName)
        {
            var fileName = Path.GetFileNameWithoutExtension(incomingFileName);
            var extension = Path.GetExtension(incomingFileName);
            return $"{fileName}-{DateTime.Now.ToUniversalTime().ToString("yyyyMMddHHmmss")}{extension}";
        }


        public async Task CreateImageAsync(CreateImageDto image)
        {
            if (image.Photo != null)
            {
                image.SavedFileName = GenerateFileNameToSave(image.Photo.FileName);
                image.SavedUrl = await _cloudStorageService.UploadFileAsync(image.Photo, image.SavedFileName);
            }

            _context.ImageDrives.Add(_mapper.Map<ImageDrive>(image));
            await _context.SaveChangesAsync();
        }

        public async Task DeleteImageAsync(int id)
        {

            var image = await _context.ImageDrives.FindAsync(id);
            if (image != null)
            {
                if (!string.IsNullOrWhiteSpace(image.SavedFileName))
                {
                    await _cloudStorageService.DeleteFileAsync(image.SavedFileName);
                    image.SavedFileName = String.Empty;
                    image.SavedUrl = String.Empty;
                }
                _context.ImageDrives.Remove(image);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<List<ResultImageDto>> GetAllImagesAsync()
        {
            var images = await _context.ImageDrives.ToListAsync();
            foreach (var item in images)
            {
                await GenerateSignedUrl(item);

            }
            return _mapper.Map<List<ResultImageDto>>(images);
        }

        public async Task<ResultImageDto> GetImageByIdAsync(int id)
        {


            var image = await _context.ImageDrives.FindAsync(id);
            if (image != null)
            {
                await GenerateSignedUrl(image);
            }

            return _mapper.Map<ResultImageDto>(image);
        }

        public bool ImageExists(int id)
        {
            return _context.ImageDrives.Any(e => e.Id == id);
        }

        public async Task UpdateImageAsync(UpdateImageDto image)
        {
            if (image.Photo != null)
            {
                //replace the file by deleting image.SavedFileName file and then uploading new image.Photo
                if (!string.IsNullOrEmpty(image.SavedFileName))
                {
                    await _cloudStorageService.DeleteFileAsync(image.SavedFileName);
                }
                image.SavedFileName = GenerateFileNameToSave(image.Photo.FileName);
                image.SavedUrl = await _cloudStorageService.UploadFileAsync(image.Photo, image.SavedFileName);
            }
            _context.Update(_mapper.Map<ImageDrive>(image));
            await _context.SaveChangesAsync();
        }
    }
}
