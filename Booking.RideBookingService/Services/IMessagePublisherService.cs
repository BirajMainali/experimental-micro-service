namespace Booking.BookingService.Services;

public interface IMessagePublisherService
{
    Task PublishMessageAsync<T>(T message) where T : class;
}