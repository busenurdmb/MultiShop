using Multishop.SharedLibrary.RabbitMQEvents;
using MultiShop.DtoLayer.CommentDtos;

namespace MultiShop.WebUI.Services.RabbitMQServices.RabbitMQServices
{
    public interface IRabbitMQServices
    {
        Task RabbitMessage(ProductNameChangedEvent productNameChangedEvent);
    }
}
