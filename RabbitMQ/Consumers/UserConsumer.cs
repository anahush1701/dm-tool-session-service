using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SessionService.Interfaces;
using SessionService.Models;
using System.Text.Json;

namespace SessionService.RabbitMQ.Consumers
{
    public class UserConsumer
    {
        public const string QueueName = "user_created_queue";

        private readonly IUserCreationHandler _userCreationHandler;

        public UserConsumer(IUserCreationHandler userCreationHandler)
        {
            _userCreationHandler = userCreationHandler ?? throw new ArgumentNullException(nameof(userCreationHandler));
        }

        public async Task StartListening()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using var connection = await factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(
                queue: QueueName,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );

            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.ReceivedAsync += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = System.Text.Encoding.UTF8.GetString(body);

                var userDto = JsonSerializer.Deserialize<UserReceivedDto>(message);

                Console.WriteLine($"Received user ID: {userDto.UserId} and Name: {userDto.UserName}");

                _userCreationHandler.CreatePlayerAndDm(userDto);
            };
        }
    }
}
