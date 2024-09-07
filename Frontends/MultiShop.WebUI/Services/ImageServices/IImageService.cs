using MultiShop.DtoLayer.ImageDtos;

namespace MultiShop.WebUI.Services.ImageServices
{
    public interface IImageService
    {
        Task CreateImageAsync(CreateImageDto image);
        Task UpdateImageAsync(UpdateImageDto image);

        Task<UpdateImageDto> GetImageByIdAsync(int id);
        Task<List<ResultImageDto>> GetAllImagesAsync();

        Task DeleteImageAsync(int id);
    }
}
