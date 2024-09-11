using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.Interfaces;

namespace MultiShop.WebUI.ViewComponents.ShoppingCartViewComponents
{
    public class _ShoppingCartProductListComponentPartial : ViewComponent
    {
        private readonly IBasketService _basketService;
        private readonly IIdentityService _identityService;
        public _ShoppingCartProductListComponentPartial(IBasketService basketService, IIdentityService identityService)
        {
            _basketService = basketService;
            _identityService = identityService;
        }
        public async Task< IViewComponentResult> InvokeAsync()
        {
            var token = await _identityService.GetToken();
            var basketTotal = await _basketService.GetBasket(token);
            var basketItems = basketTotal.BasketItems;
            return View(basketItems);
        }
    }
}
