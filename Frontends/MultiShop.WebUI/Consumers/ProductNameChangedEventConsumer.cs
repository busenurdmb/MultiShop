using MassTransit;
using Multishop.SharedLibrary.RabbitMQEvents;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.Interfaces;

namespace MultiShop.WebUI.Consumers
{
    public class ProductNameChangedEventConsumer : IConsumer<ProductNameChangedEvent>
    {
        private readonly IBasketService _basketService;
        private readonly IIdentityService _identityService;

        public ProductNameChangedEventConsumer(IBasketService basketService, IIdentityService identityService)
        {
            _basketService = basketService;
            _identityService = identityService;
        }

        public async Task Consume(ConsumeContext<ProductNameChangedEvent> context)
        {
            var message = context.Message;

            //// Mesajı işleyin
            //Console.WriteLine($"ProductId: {message.ProductId}");
            //Console.WriteLine($"UpdatedName: {message.UpdatedName}");
            //Console.WriteLine($"UpdatedPrice: {message.UpdatedPrice}");
        
            var token = await _identityService.GetToken();

            // Token'ı service katmanına geçerek basket verilerini al

            var basketItems = await _basketService.GetBasket(token);
          


            foreach (var x in basketItems.BasketItems)
            {
                if (x.ProductId == context.Message.ProductId)
                {
                    x.ProductId = context.Message.ProductId;
                    x.ProductName = context.Message.UpdatedName;
                    x.Price = context.Message.UpdatedPrice;

                }

            }
           
            await _basketService.SaveBasket(basketItems,token);

           
        }
    }
}

