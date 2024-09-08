using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using Multishop.SharedLibrary.RabbitMQEvents;
using System.Text.Json;

namespace MultiShop.RabbitMQMessage.Services
{
    // RabbitMQ ile etkileşim kurmak için bir servis sınıfı
    public class RabbitMQService : IRabbitMQService
    {
        // Mesaj içeriğini saklamak için statik bir değişken
        private static string _message;

        // RabbitMQ sunucusuna bağlantı oluşturur
        public IConnection CreateConnection()
        {
            var connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost",  // RabbitMQ sunucusunun adresi
            };
            var connection = connectionFactory.CreateConnection();  // Bağlantıyı oluşturur
            return connection;
        }

        // Bağlantı üzerinden bir iletişim kanalı (channel) oluşturur
        public IModel CreateChannel()
        {
            var connection = CreateConnection();  // Bağlantıyı oluşturur
            var channel = connection.CreateModel();  // Kanalı oluşturur
            return channel;
        }

        // Belirtilen isimde bir kuyruk oluşturur
        public void QueueDeclare(string queueName)
        {
            var channel = CreateChannel();  // Kanalı oluşturur
            channel.QueueDeclare(queueName, false, false, false, null);  // Kuyruğu oluşturur
        }

        // Kuyruğa bir mesaj gönderir
        public void BasicPublish(string queueName, string messageContent)
        {
            var channel = CreateChannel();  // Kanalı oluşturur
            var byteMessage = Encoding.UTF8.GetBytes(messageContent);  // Mesajı bayt dizisine dönüştürür
            channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: byteMessage);  // Mesajı kuyruğa gönderir
        }
        public void BasicPublish(string queueName, ProductNameChangedEvent messageContent)
        {
            var channel = CreateChannel();  // Kanalı oluşturur
            var jsonMessage = JsonSerializer.Serialize(messageContent);  // Mesajı JSON formatına dönüştürür
            Console.WriteLine($"JSON Message: {jsonMessage}");  // JSON mesajını kontrol et
            var byteMessage = Encoding.UTF8.GetBytes(jsonMessage);  // JSON verisini bayt dizisine dönüştürür
            channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: byteMessage);  // Mesajı kuyruğa gönderir
        }
        // Bir tüketici (consumer) oluşturur
        public EventingBasicConsumer CreateConsumer()
        {
            var channel = CreateChannel();  // Kanalı oluşturur
            var consumer = new EventingBasicConsumer(channel);  // Tüketici oluşturur
            return consumer;
        }

        // Kuyruktan mesaj tüketir
        public string Consume(string queueName)
        {
            var consumer = CreateConsumer();  // Tüketici oluşturur

            // Mesaj alındığında tetiklenen olay
            consumer.Received += (model, body) =>
            {
                var byteMessage = body.Body.ToArray();  // Mesajı bayt dizisine dönüştürür
                _message = Encoding.UTF8.GetString(byteMessage);  // Bayt dizisini stringe dönüştürür
            };

            var channel = CreateChannel();  // Kanalı oluşturur
            channel.BasicConsume(queue: queueName, autoAck: false, consumer: consumer);  // Kuyruktan mesajları tüketir

            // Mesaj mevcutsa döndürür, aksi takdirde boş string döner
            if (string.IsNullOrEmpty(_message))
            {
                return "";
            }

            return _message;
        }
    }
}
