using Project.Models;

namespace Project.Data.Interfaces;

public interface IClientOfferRepository
{
    Task<ClientOffer> AddClientOffer(ClientOffer clientOffer);
    string GetOfferNames(Guid clientId);
}