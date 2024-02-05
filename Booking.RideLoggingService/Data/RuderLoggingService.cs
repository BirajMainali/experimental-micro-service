using Booking.RideLoggingSerivce.Models;
using Microsoft.EntityFrameworkCore;

namespace Booking.RideLoggingSerivce.Data;

public class RideLoggingServiceDbContext : DbContext
{
    public RideLoggingServiceDbContext(DbContextOptions<RideLoggingServiceDbContext> options)
        : base(options)
    {
    }

    public DbSet<BookingHistory> BookingHistories { get; set; }
}