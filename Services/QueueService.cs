using Azure.Storage.Queues;
using System.Text.Json;

namespace TicketHubApp.Services
{
    public class QueueService
    {
        private readonly QueueClient _queueClient;

        public QueueService(IConfiguration configuration)
        {
            // Update this line to use the correct configuration path
            var connectionString = configuration["AzureStorage:ConnectionString"];
            var queueName = "tickethub";

            _queueClient = new QueueClient(connectionString, queueName);
            _queueClient.CreateIfNotExists();
        }

        public async Task SendMessageAsync(object message)
        {
            var jsonMessage = JsonSerializer.Serialize(message);
            await _queueClient.SendMessageAsync(Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(jsonMessage)));
        }
    }
}