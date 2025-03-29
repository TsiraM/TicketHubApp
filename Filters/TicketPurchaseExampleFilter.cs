using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using TicketHubApp.Models;

namespace TicketHubApp.Filters
{
    public class TicketPurchaseExampleFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(TicketPurchase))
            {
                schema.Example = new OpenApiObject
                {
                    ["concertId"] = new OpenApiInteger(101),
                    ["email"] = new OpenApiString("john.doe@example.com"),
                    ["name"] = new OpenApiString("John Doe"),
                    ["phone"] = new OpenApiString("(555) 123-4567"),
                    ["quantity"] = new OpenApiInteger(2),
                    ["creditCard"] = new OpenApiString("4111-1111-1111-1111"),
                    ["expiration"] = new OpenApiString("12/25"),
                    ["securityCode"] = new OpenApiString("123"),
                    ["address"] = new OpenApiString("123 Main St"),
                    ["city"] = new OpenApiString("Halifax"),
                    ["province"] = new OpenApiString("Nova Scotia"),
                    ["postalCode"] = new OpenApiString("B3H 4R2"),
                    ["country"] = new OpenApiString("Canada")
                };
            }
        }
    }
}