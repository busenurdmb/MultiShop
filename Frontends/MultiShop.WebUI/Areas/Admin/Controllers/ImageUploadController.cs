using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.ImageDtos;
using MultiShop.WebUI.Services.ImageServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class ImageUploadController : Controller
    {
        private readonly IImageService _imageService;

        public ImageUploadController(IImageService imageService)
        {
            _imageService = imageService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _imageService.GetAllImagesAsync();
            return View(values);
        }

        public async Task<IActionResult> DeleteImage(int id)
        {
            await _imageService.DeleteImageAsync(id);
            return RedirectToAction("Index");
        }

        public IActionResult CreateImage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateImage(CreateImageDto image)
        {
            await _imageService.CreateImageAsync(image);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateImage(int id)
        {
            var value = await _imageService.GetImageByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateImage(UpdateImageDto image)
        {
            await _imageService.UpdateImageAsync(image);
            return RedirectToAction("Index");
        }
    }
}
