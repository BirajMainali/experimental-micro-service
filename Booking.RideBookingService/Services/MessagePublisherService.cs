using MassTransit;

namespace Booking.BookingService.Services;

public class MessagePublisherService : IMessagePublisherService
{
    private readonly ILogger<MessagePublisherService> _logger;
    private readonly IPublishEndpoint _publishEndpoint;

    public MessagePublisherService(ILogger<MessagePublisherService> logger, IPublishEndpoint publishEndpoint)
    {
        _logger = logger;
        _publishEndpoint = publishEndpoint;
    }

    public async Task PublishMessageAsync<T>(T message) where T : class
    {
        _logger.LogInformation("🎉🎉🎉🎉🎉Publishing message: {0}", message);
        await _publishEndpoint.Publish(message);
    }
}