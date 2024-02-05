namespace AdministrativeService.Models;

public class BookingHistory
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime RequestDateTime { get; set; }
    public string Customer { get; set; }
    public DateTime RequestedForDateTime { get; set; }
    public string? Rider { get; set; }
    public DateTime? ConfirmDateTime { get; set; }
    public bool IsConfirmed { get; set; } = false;
    public bool IsCancelled { get; set; } = false;
    public DateTime? CancelDateTime { get; set; }
    public string? CancelReason { get; set; }
    public string? CancelledBy { get; set; }
}