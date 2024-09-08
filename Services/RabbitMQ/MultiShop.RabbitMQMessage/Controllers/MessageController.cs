
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Multishop.SharedLibrary.RabbitMQEvents;
using MultiShop.RabbitMQMessage.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace MultiShop.RabbitMQMessage.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IRabbitMQService _service;

        public MessageController(IRabbitMQService service)
        {
            _service = service;
        }
        [HttpPost("SendToQueue")]
        public IActionResult SendToQueue([FromBody] ProductNameChangedEvent productEvent)
        {
            // RabbitMQ'ya mesajı gönderiyoruz
            //_service.QueueDeclare("product-name-changed-event-basket-service");
            _service.BasicPublish("product-name-changed-event-basket-service", productEvent);

            return Ok("Mesaj RabbitMQ'ya gönderildi.");
        }
        [HttpPost]
        public IActionResult CreateMessage()
        {
            _service.QueueDeclare("Queue3");
            _service.BasicPublish("Queue3", "Bu bir deneme mesaj içeriğidir");
            return Ok("Mesaj Kuyruğa Alınmıştır.");
        }

        [HttpGet]
        public IActionResult ReadMessage()
        {

            var value = _service.Consume("Queue3");
            return Ok(value);
        }
        //[HttpPost]
        //public IActionResult CreateMessage()
        //{
        //    // RabbitMQ ile bağlantı oluşturmak için ConnectionFactory sınıfını kullanıyoruz
        //    var connectionFactory = new ConnectionFactory()
        //    {
        //        HostName = "localhost",  // RabbitMQ sunucusunun adresi
        //    };

        //    // RabbitMQ sunucusuna bir bağlantı oluşturuyoruz
        //    var connection = connectionFactory.CreateConnection();

        //    // Bağlantı üzerinden bir iletişim kanalı (channel) oluşturuyoruz
        //    var channel = connection.CreateModel();

        //    // "kuyruk1" adında bir kuyruk oluşturuyoruz
        //    // - durable: Kuyruk, sunucu yeniden başlatıldığında kaybolmaz. false olarak ayarlandığında kuyruk kaybolur.
        //    // - exclusive: Kuyruk sadece bu bağlantı için geçerli olup olmadığını belirtir. false olarak ayarlandığında diğer bağlantılar da kuyruk üzerinde işlem yapabilir.
        //    // - autoDelete: Kuyruk kullanılmadığında otomatik olarak silinir mi? false olarak ayarlandığında kuyruk otomatik olarak silinmez.
        //    // - arguments: Ekstra argümanlar belirtilmemiştir.
        //    channel.QueueDeclare("kuyruk1", false, false, false, arguments: null);

        //    // Gönderilecek mesaj içeriğini tanımlıyoruz
        //    var messageContent = "Merhaba bu bir RabbitMQ kuyruk mesajıdır";

        //    // Mesaj içeriğini UTF-8 bayt dizisine dönüştürüyoruz
        //    var byteMessageContent = Encoding.UTF8.GetBytes(messageContent);

        //    // Mesajı kuyruğa gönderiyoruz
        //    // - exchange: Boş ("") olarak ayarlandığında doğrudan kuyruk adresine mesaj gönderilir.
        //    // - routingKey: Mesajın gönderileceği kuyruk ismi. Burada "kuyruk1" olarak belirtilmiştir.
        //    // - basicProperties: Mesaj için ek özellikler. Burada null olarak bırakılmıştır.
        //    // - body: Gönderilen mesajın bayt dizisi
        //    channel.BasicPublish(exchange: "", routingKey: "kuyruk1", basicProperties: null, body: byteMessageContent);

        //    // HTTP yanıtı olarak işlem başarılı olduğunu belirten bir mesaj döndürür
        //    return Ok("Mesajınız kuyruğa Alınmıştır");


        //}
        //private static string _message;

        //[HttpGet]
        //public IActionResult ReadMessage()
        //{
        //    // RabbitMQ ile bağlantı oluşturmak için ConnectionFactory sınıfını kullanıyoruz
        //    var factory = new ConnectionFactory();
        //    factory.HostName = "localhost";  // RabbitMQ sunucusunun adresi


        //    // RabbitMQ sunucusuna bir bağlantı oluşturuyoruz
        //    var connection = factory.CreateConnection();

        //    // Bağlantı üzerinden bir iletişim kanalı (channel) oluşturuyoruz
        //    var channel = connection.CreateModel();

        //    var consumer = new EventingBasicConsumer(channel);

        //    consumer.Received += (model, x) =>
        //    {
        //        var bytMessage = x.Body.ToArray();
        //         _message = Encoding.UTF8.GetString(bytMessage);

        //    };

        //    channel.BasicConsume(queue:"kuyruk1",autoAck:false,consumer:consumer);
        //    if (string.IsNullOrEmpty(_message))
        //    {
        //        return NoContent();
        //    }
        //    else
        //    {
        //       return Ok(_message);
        //    }




        //}
    }
}
