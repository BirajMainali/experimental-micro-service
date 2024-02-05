using System.ComponentModel.DataAnnotations.Schema;

namespace RiderService.Models;

public class RiderConfirmation
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime Date { get; set; }
    public string Rider { get; set; } = null!;
    public bool IsConfirmed { get; set; } = false;
    public DateTime? ConfirmedDate { get; set; }
}