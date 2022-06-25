using Project.Models;

namespace Project.Data.Interfaces;

public interface IClientRepository
{
    public Task<List<Client>> GetClients();
    public Task<Client> AddClient(Client client);
}