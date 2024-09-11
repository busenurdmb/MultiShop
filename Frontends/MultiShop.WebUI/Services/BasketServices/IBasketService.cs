using MultiShop.DtoLayer.BasketDtos;

namespace MultiShop.WebUI.Services.BasketServices
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasket(string? token = null);
        Task SaveBasket(BasketTotalDto basketTotalDto, string? token = null);
        Task DeleteBasket(string userId, string? token = null);
        Task AddBasketItem(BasketItemDto basketItemDto, string? token = null);
        Task<bool> RemoveBasketItem(string productId, string? token = null);
    }
}
