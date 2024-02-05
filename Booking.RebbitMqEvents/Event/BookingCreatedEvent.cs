namespace RideBooking.Events.Event;

public class BookingCreatedEvent
{
    public DateTime Date { get; set; }
    public string Customer { get; set; }
}