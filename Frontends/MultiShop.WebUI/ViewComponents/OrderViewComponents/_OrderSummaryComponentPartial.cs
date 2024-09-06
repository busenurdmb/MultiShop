using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.BasketServices;

namespace MultiShop.WebUI.ViewComponents.OrderViewComponents
{
    public class _OrderSummaryComponentPartial : ViewComponent
    {
        private readonly IBasketService _basketService;
        public _OrderSummaryComponentPartial(IBasketService basketService)
        {
            _basketService = basketService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var basketTotal = await _basketService.GetBasket();
            var basketItems = basketTotal.BasketItems;

            var values = await _basketService.GetBasket();
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
