namespace Buildings.Domain.Models;

public class Notification
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public string Message { get; set; }
    public Guid IdSensor { get; set; }
}