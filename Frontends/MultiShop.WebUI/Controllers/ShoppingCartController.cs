using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.BasketDtos;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using MultiShop.WebUI.Services.Interfaces;


namespace MultiShop.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;
        private readonly IIdentityService _identityService;
        public ShoppingCartController(IProductService productService, IBasketService basketService, IIdentityService identityService)
        {
            _productService = productService;
            _basketService = basketService;
            _identityService = identityService;
        }
        public async Task<IActionResult> Index(string code, int discountRate, decimal totalNewPriceWithDiscount)
        {
            ViewBag.code = code;
            ViewBag.discountRate = discountRate;
            ViewBag.totalNewPriceWithDiscount = totalNewPriceWithDiscount;
            ViewBag.directory1 = "Ana Sayfa";
            ViewBag.directory2 = "Ürünler";
            ViewBag.directory3 = "Sepetim";
            var token = await _identityService.GetToken();
            var values = await _basketService.GetBasket(token);
            ViewBag.total = values.TotalPrice; //toplam ürün fiyatı
            var totalPriceWithTax = values.TotalPrice + values.TotalPrice / 100 * 10; //kdvli fiyat
            var tax = values.TotalPrice / 100 * 10; //kdv
            ViewBag.totalPriceWithTax = totalPriceWithTax;
            ViewBag.tax = tax;
            return View();
        }

        //[HttpPost]
        public async Task<IActionResult> AddBasketItem(string id)
        {
            var values = await _productService.GetByIdProductAsync(id);
            var items = new BasketItemDto
            {
                ProductId = values.ProductId,
                ProductName = values.ProductName,
                Price = values.ProductPrice,
                Quantity = 1,
                ProductImageUrl = values.ProductImageUrl
            };
            var token = await _identityService.GetToken();
            await _basketService.AddBasketItem(items,token);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveBasketItem(string id)
        {
            var token = await _identityService.GetToken();
            await _basketService.RemoveBasketItem(id,token);
            return RedirectToAction("Index");
        }
    }
}
