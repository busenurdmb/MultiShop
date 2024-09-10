using Microsoft.AspNetCore.Mvc;
using MultiShop.RapidApI.Model;
using MultiShop.RapidAPI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MultiShop.RapidAPI.Controllers
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
        public async Task<IActionResult> Exchange()
        {
          
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://real-time-finance-data.p.rapidapi.com/currency-exchange-rate?from_symbol=USD&language=en&to_symbol=TRY"),
                Headers =
    {
        { "x-rapidapi-key", "165cdd06e5mshb82ebf450dce236p1c3102jsn978ea6bd7f6c" },
        { "x-rapidapi-host", "real-time-finance-data.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<ExchangeViewModel>(body);
                ViewBag.exchangeRate = values.data.exchange_rate;
                ViewBag.previousClose = values.data.previous_close;
               
            }

            var client2 = new HttpClient();
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://real-time-finance-data.p.rapidapi.com/currency-exchange-rate?from_symbol=EUR&language=en&to_symbol=TRY"),
                Headers =
    {
        { "x-rapidapi-key", "165cdd06e5mshb82ebf450dce236p1c3102jsn978ea6bd7f6c" },
        { "x-rapidapi-host", "real-time-finance-data.p.rapidapi.com" },
    },
            };
            using (var response2 = await client.SendAsync(request2))
            {
                response2.EnsureSuccessStatusCode();
                var body = await response2.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ExchangeViewModel>(body);
                ViewBag.exchangeRateEuro = values.data.exchange_rate;
                ViewBag.previousCloseEuro = values.data.previous_close;
                return View(values);
            }

        }
    }
}
