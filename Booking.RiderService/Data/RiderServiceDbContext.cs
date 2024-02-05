using Microsoft.EntityFrameworkCore;
using RiderService.Models;

namespace RiderService.Data;

public class RiderServiceDbContext : DbContext
{
    public RiderServiceDbContext(DbContextOptions<RiderServiceDbContext> options)
        : base(options)
    {
    }

    public DbSet<RiderConfirmation> RideRequests { get; set; }
}