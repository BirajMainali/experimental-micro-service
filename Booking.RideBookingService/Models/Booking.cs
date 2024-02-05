namespace Booking.BookingService.Models;

public class Booking
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime Date { get; set; }
    public string Customer { get; set; }
    public bool IsConfirmed { get; set; }
    public DateTime? ConfirmedDate { get; set; }
}