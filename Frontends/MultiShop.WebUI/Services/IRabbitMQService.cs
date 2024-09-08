using Multishop.SharedLibrary.RabbitMQEvents;
using MultiShop.DtoLayer.CommentDtos;

namespace MultiShop.WebUI.Services
{
    public interface IRabbitMQService
    {
        Task RabbitMessage(ProductNameChangedEvent productNameChangedEvent);
    }
}
