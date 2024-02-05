using Booking.RideLoggingService.Models;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using RideBooking.Events.Event;

namespace Booking.RideLoggingSerivce.Services;

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

    public async Task Consume(ConsumeContext<BookingCreatedEvent> context)
    {
        _logger.LogInformation("🎉🎉🎉🎉🎉 Consuming message: {0}", context.Message);
        var bookingHistory = new BookingHistory
        {
            Date = context.Message.Date,
            Customer = context.Message.Customer,
        };
        _context.Add(bookingHistory);
        await _context.SaveChangesAsync();
    }
}