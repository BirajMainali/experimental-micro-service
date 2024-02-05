using CustomerService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerService.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class BookingController : ControllerBase
{
    private readonly DbContext _context;

    public BookingController(DbContext context)
    {
        _context = context;
    }


    [HttpGet]
    public async Task<IActionResult> GetRiderRequests()
    {
        var requests = await _context.Set<RiderRequest>().ToListAsync();
        return Ok(requests);
    }

    [HttpPost]
    public async Task<IActionResult> RequestBooking([FromForm] string customerName)
    {
        _context.Add(new RiderRequest()
        {
            Customer = customerName,
            RequestDateTime = DateTime.UtcNow,
            RequestedForDateTime = DateTime.UtcNow.AddHours(1)
        });
        await _context.SaveChangesAsync();
        return Ok("Your request has been submitted successfully. We will notify you once the rider is confirmed.");
    }
}