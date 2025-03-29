using Azure.Storage.Queues;
using System.Text.Json;
using TicketHubApp.Models;

namespace TicketHubApp.Services
{
    public class QueueService
    {
        private readonly QueueClient _queueClient;
        private readonly IConfiguration _configuration;
        private readonly ILogger<QueueService> _logger;

        public QueueService(IConfiguration configuration, ILogger<QueueService> logger)
        {
            _configuration = configuration;
            _logger = logger;

            string connectionString = _configuration["AzureStorage:ConnectionString"] ??
                throw new InvalidOperationException("Azure Storage connection string is not configured.");

            string queueName = "ticket-purchases";

            try
            {
                // Create a QueueClient
                _queueClient = new QueueClient(connectionString, queueName);

                // Create the queue if it doesn't already exist
                _queueClient.CreateIfNotExists();
                _logger.LogInformation($"Connected to Azure Storage Queue: {queueName}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to initialize Azure Storage Queue: {ex.Message}");
                throw;
            }
        }

        public async Task AddMessageAsync(TicketPurchase purchase)
        {
            if (purchase == null)
            {
                throw new ArgumentNullException(nameof(purchase));
            }

            try
            {
                // Serialize the ticket purchase to JSON
                string messageJson = JsonSerializer.Serialize(purchase);

                // Add the message to the queue
                await _queueClient.SendMessageAsync(Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(messageJson)));

                _logger.LogInformation($"Added ticket purchase for {purchase.Name} to queue for concert {purchase.ConcertId}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error adding ticket purchase to queue: {ex.Message}");
                throw;
            }
        }
    }
}