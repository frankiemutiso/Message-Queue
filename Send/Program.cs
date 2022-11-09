using System;
using System.Text;
using RabbitMQ.Client;

namespace MessageQueues
{
    class Program
    {
        public static void Main()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(
                    queue: "basic_queue",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null
                    );


             
                Console.WriteLine("Enter the message to send: ");
                string message = "Hello";

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "", routingKey: "basic_queue", basicProperties: null, body: body);

                Console.WriteLine("Sent {0}", message);

            }
            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}