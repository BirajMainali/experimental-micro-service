using System.ComponentModel.DataAnnotations.Schema;

namespace RiderService.Models;

public class RideRequest
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime RequestDateTime { get; set; }
    public DateTime RequestedForDateTime { get; set; }
    public bool IsConfirmed { get; set; } = false;
    public DateTime? ConfirmDateTime { get; set; }
}