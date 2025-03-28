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

        public TicketsController(QueueService queueService)
        {
            _queueService = queueService;
        }

        [HttpPost("purchase")]
        [SwaggerOperation(
            Summary = "Purchase tickets for a concert",
            Description = "Submits a ticket purchase request and adds it to the processing queue",
            OperationId = "PurchaseTickets"
        )]
        [SwaggerResponse(StatusCodes.Status202Accepted, "Purchase request accepted and queued for processing")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid purchase request")]
        public async Task<IActionResult> PurchaseTickets([FromBody] TicketPurchase purchase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _queueService.AddMessageAsync(purchase);

            return Accepted();
        }
    }
}
