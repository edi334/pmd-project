namespace Project.Models;

public class Offer
{
    public Guid Id { get; set; }
    public string Location { get; set; }
    public DateTime Date { get; set; }
    public float Price { get; set; }
}