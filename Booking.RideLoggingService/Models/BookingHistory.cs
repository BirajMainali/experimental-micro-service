namespace Booking.RideLoggingService.Models;

public class BookingHistory
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime Date { get; set; }
    public string Customer { get; set; } = null!;
    public string? Rider { get; set; }
    public bool IsConfirmed { get; set; } = false;
    public DateTime? ConfirmedDate { get; set; }
    public bool IsCancelled { get; set; } = false;
    public DateTime? CancelDateTime { get; set; }
    public string? CancelReason { get; set; }
    public string? CancelledBy { get; set; }
}