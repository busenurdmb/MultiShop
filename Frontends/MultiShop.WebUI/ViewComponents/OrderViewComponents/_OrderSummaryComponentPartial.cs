using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.Interfaces;

namespace MultiShop.WebUI.ViewComponents.OrderViewComponents
{
    public class _OrderSummaryComponentPartial : ViewComponent
    {
        private readonly IBasketService _basketService;
        private readonly IIdentityService _identityService;
        public _OrderSummaryComponentPartial(IBasketService basketService, IIdentityService identityService)
        {
            _basketService = basketService;
            _identityService = identityService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {   
            var token = await _identityService.GetToken();

            var basketTotal = await _basketService.GetBasket(token);
            var basketItems = basketTotal.BasketItems;
            
            var values = await _basketService.GetBasket(token);
            ViewBag.total = values.TotalPrice; //toplam ürün fiyatı
            var totalPriceWithTax = values.TotalPrice + values.TotalPrice / 100 * 10; //kdvli fiyat
            var tax = values.TotalPrice / 100 * 10; //kdv
            ViewBag.totalPriceWithTax = totalPriceWithTax;
            var x = totalPriceWithTax + 12;
            ViewBag.endtotal = x;
            return View(basketItems);
        }
    }
}
