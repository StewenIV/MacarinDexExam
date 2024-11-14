namespace Buildings.Domain.Models;

public class Building
{
    public Guid Id { get; set; }
    public string? NameBuilding { get; set; }
    public string Address { get; set; }
    public int Floor { get; set; }
    public Guid IdPerson { get; set; }
    public Person Person { get; set; }
    public List<Sensor> Sensors { get; set; }
}