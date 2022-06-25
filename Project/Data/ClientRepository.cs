using Microsoft.EntityFrameworkCore;
using Project.Data.Interfaces;
using Project.Models;

namespace Project.Data;

public class ClientRepository : IClientRepository
{
    private readonly ApplicationDbContext _dbContext;
    
    public ClientRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<List<Client>> GetClients()
    {
        return await _dbContext.Clients.ToListAsync();
    }

    public async Task<Client> AddClient(Client client)
    {
        if (client is null)
        {
            throw new NullReferenceException("Client is null");
        }

        await _dbContext.Clients.AddAsync(client);
        await _dbContext.SaveChangesAsync();

        return client;
    }
}