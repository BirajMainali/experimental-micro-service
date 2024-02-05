namespace CustomerService.Models;

public class RiderRequest
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime RequestDateTime { get; set; }
    public DateTime RequestedForDateTime { get; set; }
    public string Customer { get; set; }
    public bool IsConfirmed { get; set; }
    public DateTime? ConfirmDateTime { get; set; }
}