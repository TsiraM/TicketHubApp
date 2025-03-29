using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TicketHubApp.Models;
using TicketHubApp.Services;

namespace TicketHubApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [SwaggerTag("Operations for purchasing concert tickets")]
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
        [SwaggerOperation(
            Summary = "Purchase tickets for a concert",
            Description = "Submits a ticket purchase request and adds it to the processing queue",
            OperationId = "PurchaseTickets"
        )]
        [SwaggerResponse(StatusCodes.Status202Accepted, "Purchase request accepted and queued for processing")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid purchase request")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "An error occurred while processing the request")]
        public async Task<IActionResult> PurchaseTickets([FromBody] TicketPurchase purchase)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid ticket purchase request received");
                return BadRequest(ModelState);
            }

            try
            {
                await _queueService.AddMessageAsync(purchase);
                _logger.LogInformation($"Ticket purchase for {purchase.Name} accepted for concert {purchase.ConcertId}");
                return Accepted();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error processing ticket purchase: {ex.Message}");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}