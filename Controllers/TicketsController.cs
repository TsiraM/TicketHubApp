using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TicketHubApp.Models;
using TicketHubApp.Services;

namespace TicketHubApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly QueueService _queueService;
        private readonly ILogger<TicketsController> _logger;

        public TicketsController(QueueService queueService, ILogger<TicketsController> logger)
        {
            _queueService = queueService;
            _logger = logger;
        }

        [HttpPost("purchase")]
        public async Task<IActionResult> PurchaseTicket([FromBody] TicketPurchase ticket)
        {
            // Validate model state
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Additional validation
            if (ticket.ConcertId <= 0)
            {
                return BadRequest("Concert ID must be greater than 0");
            }

            try
            {
                // Use the queue service to send the message
                await _queueService.SendMessageAsync(ticket);
                _logger.LogInformation($"Ticket purchase for concert {ticket.ConcertId} by {ticket.Name} added to queue");
                return Ok(new { message = "Ticket purchase request queued successfully." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing ticket purchase");
                return StatusCode(500, $"An error occurred while processing your request: {ex.Message}");
            }
        }
    }
}