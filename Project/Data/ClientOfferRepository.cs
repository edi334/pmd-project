using Microsoft.EntityFrameworkCore;
using Project.Data.Interfaces;
using Project.Models;

namespace Project.Data;

public class ClientOfferRepository : IClientOfferRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ClientOfferRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ClientOffer> AddClientOffer(ClientOffer clientOffer)
    {
        if (clientOffer is null)
        {
            throw new NullReferenceException("Client Offer is null");
        }
        
        var resp =  await _dbContext.ClientOffers.AddAsync(clientOffer);
        await _dbContext.SaveChangesAsync();

        return resp.Entity;
    }

    public string GetOfferNames(Guid clientId)
    {
        var offers = _dbContext.ClientOffers
            .Include(c => c.Offer)
            .Where(c => c.ClientId == clientId)
            .Select(c => c.Offer.Location);

        var result = "";

        foreach (var offer in offers)
        {
            result += offer;
        }

        return result;
    }
}