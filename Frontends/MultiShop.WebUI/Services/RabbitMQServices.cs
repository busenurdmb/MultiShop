using Multishop.SharedLibrary.RabbitMQEvents;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Services
{
    public class RabbitMQServices : IRabbitMQService
    {
        private readonly HttpClient _httpClient;

        public RabbitMQServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task RabbitMessage(ProductNameChangedEvent productNameChangedEvent)
        {

            var jsonContent = new StringContent(JsonConvert.SerializeObject(productNameChangedEvent), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("http://localhost:7079/api/Message/SendToQueue", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Başarılı");
            }
        }
    }
}
