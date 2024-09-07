using MultiShop.DtoLayer.IdentityDtos.UserDtos;
using MultiShop.DtoLayer.ImageDtos;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MultiShop.WebUI.Services.ImageServices
{
    public class ImageService : IImageService
    {

        private readonly HttpClient _client;
        public ImageService(HttpClient httpClient)
        {
            _client = httpClient;
        }

        public async Task CreateImageAsync(CreateImageDto image)
        {

           
            var formContent = new MultipartFormDataContent();
            formContent.Add(new StringContent(image.Title), "Title");
            formContent.Add(new StreamContent(image.Photo.OpenReadStream()), "Photo", Path.GetFileName(image.Photo.FileName));
            //await _client.PostAsync("http://localhost:7077/api/ImageUploads", formContent);
            var responseMessage = await _client.PostAsync("http://localhost:7077/api/ImageUploads", formContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                Console.WriteLine(responseMessage.Content);
            }


        }

        public async Task DeleteImageAsync(int id)
        {
            await _client.DeleteAsync("imageUploads/" + id);
        }

        public async Task<List<ResultImageDto>> GetAllImagesAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultImageDto>>("imageUploads");
            ////return await _client.GetFromJsonAsync<List<ResultImageDto>>("http://localhost:7077/api/ImageUploads");
            //var responseMessage = await _client.GetAsync("http://localhost:7077/api/ImageUploads");
            //Console.WriteLine($"Received JSON: {responseMessage}"); // Gelen veriyi loglayın
            //var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //Console.WriteLine($"Received JSON: {jsonData}"); // Gelen veriyi loglayın
            //var values = JsonConvert.DeserializeObject<List<ResultImageDto>>(jsonData);
            //return values;
        }

        public async Task<UpdateImageDto> GetImageByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<UpdateImageDto>("imageUploads/" + id);
        }

        public async Task UpdateImageAsync(UpdateImageDto image)
        {
            await _client.PutAsJsonAsync("imageUploads", image);
        }
    }
}
