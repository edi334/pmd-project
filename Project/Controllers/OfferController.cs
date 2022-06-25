using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data.Interfaces;
using Project.Models;

namespace Project.Controllers;

public class OfferController : Controller
{
    private readonly IOfferRepository _offerRepository;

    public OfferController(IOfferRepository offerRepository)
    {
        _offerRepository = offerRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var offers = await _offerRepository.GetOffers();
        return View(offers);
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Offer offer)
    {
        if (!ModelState.IsValid) return View();
        
        try
        {
            var addedOffer = await _offerRepository.AddOffer(offer);
        }
        catch (NullReferenceException e)
        {
            ModelState.AddModelError("", e.Message);
            return View();
        }

        return RedirectToAction(nameof(Index));
    }
    
    [HttpGet]
    public async Task<IActionResult> Edit(Guid id)
    {
        var offer = await _offerRepository.GetById(id);
        return View(offer);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Offer offer)
    {
        if (!ModelState.IsValid) return View();

        try
        {
            var editedOffer = await _offerRepository.UpdateOffer(offer);
        }
        catch (NullReferenceException e)
        {
            ModelState.AddModelError("", e.Message);
            return View();
        }
        
        return RedirectToAction(nameof(Index));
    }
}