using MediatR;
using Microsoft.Extensions.Logging;


namespace MyApp.Application.Events
    {
    public class SendEmailEventHandler(ILogger logger) : INotificationHandler<ProductCreatedEvent>
        {
        public async Task Handle(ProductCreatedEvent notification, CancellationToken cancellationToken)
            {
            logger.LogInformation("Product created: Send email started");

            await Task.Delay(2000, cancellationToken);

            logger.LogInformation("Product created: Send email done");
            }
        }
    }
