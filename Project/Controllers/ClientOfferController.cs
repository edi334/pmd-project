using Microsoft.AspNetCore.Mvc;
using Project.Data.Interfaces;
using Project.Models;

namespace Project.Controllers;

public class ClientOfferController : Controller
{
    private readonly IClientOfferRepository _clientOfferRepository;
    private readonly IClientRepository _clientRepository;
    private readonly IOfferRepository _offerRepository;

    public ClientOfferController(IClientOfferRepository clientOfferRepository, IClientRepository clientRepository, IOfferRepository offerRepository)
    {
        _clientOfferRepository = clientOfferRepository;
        _clientRepository = clientRepository;
        _offerRepository = offerRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var clients = await _clientRepository.GetClients();
        var clientsWithOffers = clients.Select(c => new ClientWithOffers
        {
            Client = c,
            Offers = _clientOfferRepository.GetOfferNames(c.Id)
        });

        return View(clientsWithOffers);
    }
    
    [HttpGet]
    public async Task<ActionResult> Create()
    {
        var clients = await _clientRepository.GetClients();
        var offers = await _offerRepository.GetOffers();
        ViewBag.Clients = clients;
        ViewBag.Offers = offers;
            
        return View();
    }
    
    [HttpPost]
    public async Task<ActionResult> Create(ClientOffer clientOffer)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        try
        {
            var response = await _clientOfferRepository.AddClientOffer(clientOffer);
        }
        catch (NullReferenceException e)
        {
            ModelState.AddModelError("", e.Message);
            var clients = await _clientRepository.GetClients();
            var offers = await _offerRepository.GetOffers();
            ViewBag.Clients = clients;
            ViewBag.Offers = offers;
            
            return View();
        }
        
        return RedirectToAction(nameof(Index));
    }


}