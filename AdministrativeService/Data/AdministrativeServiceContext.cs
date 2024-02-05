using AdministrativeService.Models;
using Microsoft.EntityFrameworkCore;

namespace AdministrativeService.Data;

public class AdministrativeServiceContext : DbContext
{
    public AdministrativeServiceContext(DbContextOptions<AdministrativeServiceContext> options)
        : base(options)
    {
    }

    public DbSet<BookingHistory> BookingHistories { get; set; }
}