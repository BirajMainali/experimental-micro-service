using Booking.BookingService.Models;
using Booking.BookingService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RideBooking.Events.Event;

namespace Booking.BookingService.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class BookingController : ControllerBase
{
    private readonly DbContext _context;
    private readonly IMessagePublisherService _messagePublisherService;

    public BookingController(DbContext context, IMessagePublisherService messagePublisherService)
    {
        _context = context;
        _messagePublisherService = messagePublisherService;
    }


    [HttpGet]
    public async Task<IActionResult> GetAllBookings()
    {
        var requests = await _context.Set<Models.Booking>().ToListAsync();
        return Ok(requests);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetBooking(Guid id)
    {
        var request = await _context.Set<Models.Booking>().FindAsync(id);
        return Ok(request);
    }

    [HttpPost]
    public async Task<IActionResult> Book([FromForm] string customerName)
    {
        var book = new Models.Booking()
        {
            Customer = customerName,
            Date = DateTime.UtcNow,
            IsConfirmed = false
        };
        _context.Add(book);
        await _context.SaveChangesAsync();
        await _messagePublisherService.PublishMessageAsync(new BookingCreatedEvent()
        {
            Customer = book.Customer,
            Date = book.Date
        });
        return CreatedAtAction("GetBooking", new { id = book.Id }, book);
    }
}