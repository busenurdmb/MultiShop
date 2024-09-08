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
        public async Task AddBasketItem(BasketItemDto basketItemDto)
        {
            // Geçerli sepeti (Basket) elde etmek için GetBasket() metodunu çağırıyor.
            var values = await GetBasket();

            // Sepet boş değilse (null değilse) aşağıdaki işlemleri yapıyor.
            if (values != null)
            {
                // Sepette aynı üründen var mı diye kontrol ediyor (ProductId'ye göre).
                var existingItem = values.BasketItems.FirstOrDefault(x => x.ProductId == basketItemDto.ProductId);

                if (existingItem == null)
                {
                    // Eğer ürün sepette yoksa, yeni ürün olarak sepete ekliyor.
                    values.BasketItems.Add(basketItemDto);
                }
                else
                {
                    // Eğer ürün zaten sepette varsa, mevcut ürünün Quantity değerini artırıyor.
                    existingItem.Quantity += basketItemDto.Quantity;
                }
            }
            else
            {
                // Sepet yoksa, yeni bir sepet oluşturup ürünü ekliyor.
                values = new BasketTotalDto();
                values.BasketItems.Add(basketItemDto);
            }

            // Son olarak, sepeti (values) kaydetmek için SaveBasket() metodunu çağırıyor.
            await SaveBasket(values);
        }

        public Task DeleteBasket(string userId)
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

        public async Task<bool> RemoveBasketItem(string productId)
        {
            var values = await GetBasket();
            var deletedItem = values.BasketItems.FirstOrDefault(x => x.ProductId == productId);
            var result=values.BasketItems.Remove(deletedItem);
            await SaveBasket(values);
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
