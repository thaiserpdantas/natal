using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;


namespace DesafioNatalino
{
    public class Processor
    {
        public void Test(RequestMessage message)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest", 
                VirtualHost = "/"
            };

            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.QueueDeclare("hello", false, false, false, null);
            

            channel.ExchangeDeclare("exchangeTest", "fanout", true);

            channel.QueueBind("hello", "exchangeTest", "rota1");

            var body = Encoding.UTF8.GetBytes(message.Message);
            channel.BasicPublish("exchangeTest", "rota1",  null,  body);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                //var body =
            };
        }
    }
}
