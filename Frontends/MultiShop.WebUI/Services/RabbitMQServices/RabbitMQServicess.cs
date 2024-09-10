using Multishop.SharedLibrary.RabbitMQEvents;
using MultiShop.WebUI.Services.RabbitMQServices.RabbitMQServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Services.RabbitMQServices
{
    public class RabbitMQServicess : IRabbitMQServices
    {
        private readonly HttpClient _httpClient;

        public RabbitMQServicess(HttpClient httpClient)
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
