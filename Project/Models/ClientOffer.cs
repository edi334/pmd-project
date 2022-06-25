namespace Project.Models;

public class ClientOffer
{
    public Guid Id { get; set; }
    public Guid ClientId { get; set; }
    public Client Client { get; set; }
    public Guid OfferId { get; set; }
    public Offer Offer { get; set; }
}