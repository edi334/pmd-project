using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Offer> Offers { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<ClientOffer> ClientOffers { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}