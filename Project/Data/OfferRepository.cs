using Microsoft.EntityFrameworkCore;
using Project.Data.Interfaces;
using Project.Models;

namespace Project.Data;

public class OfferRepository : IOfferRepository
{
    private readonly ApplicationDbContext _dbContext;

    public OfferRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Offer>> GetOffers()
    {
        return await _dbContext.Offers.ToListAsync();
    }

    public async Task<Offer> AddOffer(Offer offer)
    {
        if (offer is null)
        {
            throw new NullReferenceException("Offer is null!");
        }

        await _dbContext.Offers.AddAsync(offer);
        await _dbContext.SaveChangesAsync();

        return offer;
    }

    public async Task<Offer> UpdateOffer(Offer offer)
    {
        var existingOffer = await _dbContext.Offers.FirstOrDefaultAsync(o => o.Id == offer.Id);

        if (existingOffer is null)
        {
            throw new NullReferenceException("Offer doesn't exist!");
        }

        existingOffer.Date = offer.Date;
        existingOffer.Location = offer.Location;
        existingOffer.Price = offer.Price;

        await _dbContext.SaveChangesAsync();

        return offer;
    }

    public async Task<Offer> GetById(Guid id)
    {
        var existingOffer = await _dbContext.Offers.FirstOrDefaultAsync(o => o.Id == id);

        if (existingOffer is null)
        {
            throw new NullReferenceException("Offer doesn't exist!");
        }

        return existingOffer;
    }
}