using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using Multishop.SharedLibrary.RabbitMQEvents;

namespace MultiShop.RabbitMQMessage.Services
{
    public interface IRabbitMQService
    {
        // RabbitMQ sunucusuna bir bağlantı oluşturur
        IConnection CreateConnection();

        // Bağlantı üzerinden bir iletişim kanalı (channel) oluşturur
        IModel CreateChannel();

        // Belirtilen isimde bir kuyruk oluşturur
        void QueueDeclare(string queueName);

        // Kuyruğa bir mesaj gönderir
        void BasicPublish(string queueName, string messageContent);
        public void BasicPublish(string queueName, ProductNameChangedEvent messageContent);

        // Bir tüketici (consumer) oluşturur
        EventingBasicConsumer CreateConsumer();

        // Kuyruktan mesaj tüketir
        string Consume(string queueName);
    }
}
