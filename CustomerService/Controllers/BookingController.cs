using CustomerService.Models;
using CustomerService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerService.Controllers;

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
    public async Task<IActionResult> GetRiderRequests()
    {
        var requests = await _context.Set<RiderRequest>().ToListAsync();
        return Ok(requests);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetRiderRequest(int id)
    {
        var request = await _context.Set<RiderRequest>().FindAsync(id);
        return Ok(request);
    }

    [HttpPost]
    public async Task<IActionResult> RequestBooking([FromForm] string customerName)
    {
        var riderRequest = new RiderRequest()
        {
            Customer = customerName,
            RequestDateTime = DateTime.UtcNow,
            RequestedForDateTime = DateTime.UtcNow.AddHours(1)
        };
        _context.Add(riderRequest);
        await _context.SaveChangesAsync();
        await _messagePublisherService.PublishMessageAsync(riderRequest);
        return CreatedAtAction("GetRiderRequest", new { id = riderRequest.Id });
    }
}