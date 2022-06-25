using Microsoft.AspNetCore.Mvc;
using Project.Data.Interfaces;
using Project.Models;

namespace Project.Controllers;

public class ClientController : Controller
{
    private readonly IClientRepository _clientRepository;

    public ClientController(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var clients = await _clientRepository.GetClients();
        return View(clients);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Client client)
    {
        if (!ModelState.IsValid) return View();
        try
        {
            var addedClient = await _clientRepository.AddClient(client);
        }
        catch (NullReferenceException e)
        {
            ModelState.AddModelError("", e.Message);
        }

        return RedirectToAction(nameof(Index));
    }

}