using MultiShop.DtoLayer.BasketDtos;
using System.Net.Http.Headers;

namespace MultiShop.WebUI.Services.BasketServices
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;
        public BasketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    
        public async Task AddBasketItem(BasketItemDto basketItemDto, string? token = null)
        {
            // Geçerli sepeti al

            var basket = await GetBasket(token);

            if (basket == null)
            {
                // Sepet mevcut değilse, yeni bir sepet oluştur
                basket = new BasketTotalDto();
            }

            // Sepette aynı üründen var mı kontrol et
            var existingItem = basket.BasketItems
                .FirstOrDefault(x => x.ProductId == basketItemDto.ProductId);

            if (existingItem == null)
            {
                // Ürün sepette yoksa, ekle
                basket.BasketItems.Add(basketItemDto);
            }
            else
            {
                // Ürün zaten sepetteyse, miktarını artır
                existingItem.Quantity += basketItemDto.Quantity;
            }

            // Güncellenmiş sepeti kaydet
            await SaveBasket(basket, token);
        }
        public Task DeleteBasket(string userId, string? token = null)
        {
            throw new NotImplementedException();
        }

        public async Task<BasketTotalDto> GetBasket(string? token = null)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "baskets");

            // Token varsa, Authorization başlığını ayarla
            if (!string.IsNullOrEmpty(token))
            {
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            var responseMessage = await _httpClient.SendAsync(requestMessage);

            if (responseMessage.IsSuccessStatusCode)
            {
                var values = await responseMessage.Content.ReadFromJsonAsync<BasketTotalDto>();
                return values;
            }
            else
            {
                // Hata yönetimi
                throw new Exception("Error fetching basket data.");
            }

            //var responseMessage = await _httpClient.GetAsync("baskets");
            //var values = await responseMessage.Content.ReadFromJsonAsync<BasketTotalDto>();
            //return values;
        }

        public async Task<bool> RemoveBasketItem(string productId, string? token = null)
        {
            var values = await GetBasket(token);
            var deletedItem = values.BasketItems.FirstOrDefault(x => x.ProductId == productId);

            var result=values.BasketItems.Remove(deletedItem);
            await SaveBasket(values,token);
            return true;
        }
        public async Task SaveBasket(BasketTotalDto basketTotalDto, string? token = null)
        {
            using var request = new HttpRequestMessage(HttpMethod.Post, "baskets")
            {
                Content = JsonContent.Create(basketTotalDto)
            };

            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            var response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode(); // Bu satır, yanıtın başarılı olup olmadığını kontrol eder ve hata durumunda istisna fırlatır.
        }
        //public async Task SaveBasket(BasketTotalDto basketTotalDto, string? token = null)
        //{
        //    await _httpClient.PostAsJsonAsync<BasketTotalDto>("baskets", basketTotalDto);
        //}
    }
}
