using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _VendorDefaultComponentPartial : ViewComponent
    {
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
         
            return View();
        }
    }
}
