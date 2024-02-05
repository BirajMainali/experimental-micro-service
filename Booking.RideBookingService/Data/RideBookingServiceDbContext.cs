using Booking.BookingService.Models;
using Microsoft.EntityFrameworkCore;

namespace Booking.BookingService.Data;

public class RideBookingServiceDbContext : DbContext
{
    public RideBookingServiceDbContext(DbContextOptions<RideBookingServiceDbContext> options)
        : base(options)
    {
    }

    public DbSet<Models.Booking> Bookings { get; set; }
}