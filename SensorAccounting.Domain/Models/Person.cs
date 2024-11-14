namespace Buildings.Domain.Models;

public class Person
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    public List<Building> Buildings { get; set; }
}