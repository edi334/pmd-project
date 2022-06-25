using Project.Models;

namespace Project.Data.Interfaces;

public interface IOfferRepository
{
    public Task<List<Offer>> GetOffers();
    public Task<Offer> AddOffer(Offer offer);
    public Task<Offer> UpdateOffer(Offer offer);
    public Task<Offer> GetById(Guid id);
}