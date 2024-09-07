using MultiShop.Images.Dtos;

namespace MultiShop.Images.Services.ImageServices
{
    public interface IImageService
    {
        Task CreateImageAsync(CreateImageDto image);
        Task UpdateImageAsync(UpdateImageDto image);

        Task<ResultImageDto> GetImageByIdAsync(int id);
        Task<List<ResultImageDto>> GetAllImagesAsync();

        Task DeleteImageAsync(int id);

        bool ImageExists(int id);

    }
}
