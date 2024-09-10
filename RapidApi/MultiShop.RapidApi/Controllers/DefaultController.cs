using Microsoft.AspNetCore.Mvc;
using MultiShop.RapidApi.Model;
using Newtonsoft.Json;

namespace MultiShop.RapidApi.Controllers
{
    public class DefaultController : Controller
    {
        public async Task<IActionResult> WeatherDetail()
        {


          
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://the-weather-api.p.rapidapi.com/api/weather/Ankara"),
                Headers =
    {
        { "x-rapidapi-key", "165cdd06e5mshb82ebf450dce236p1c3102jsn978ea6bd7f6c" },
        { "x-rapidapi-host", "the-weather-api.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<WeatherViewModel>(body);
                ViewBag.cityTemp = values.data.temp;
                return View(values);
            }
          
        }
    }
}
