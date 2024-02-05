using MassTransit;
using Microsoft.EntityFrameworkCore;
using RideBooking.Events.Event;
using RiderService.Models;

namespace RiderService.Services;

public class BookingCreatedConsumerService : IConsumer<BookingCreatedEvent>
{
    private readonly ILogger<BookingCreatedConsumerService> _logger;
    private readonly DbContext _context;

    public BookingCreatedConsumerService(ILogger<BookingCreatedConsumerService> logger,
        DbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public Task Consume(ConsumeContext<BookingCreatedEvent> context)
    {
        _logger.LogInformation("🎉🎉🎉🎉🎉 Consuming message: {0}", context.Message);
        var bookingHistory = new RiderConfirmation()
        {
            Date = context.Message.Date,
            IsConfirmed = false
        };
        _context.Add(bookingHistory);
        return _context.SaveChangesAsync();
    }
}