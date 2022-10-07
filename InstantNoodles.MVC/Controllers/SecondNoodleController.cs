using AutoMapper;
using InstantNoodles.DAL.Data;
using Microsoft.AspNetCore.Mvc;
using NoodleDAL = InstantNoodles.DAL.Models.NoodleModel;
using InstantNoodles.MVC.Models;

namespace InstantNoodles.MVC.Controllers;
public class SecondNoodleController : Controller
{
    private INoodleRepository _service;
    private readonly IMapper _mapper;
    public SecondNoodleController(INoodleRepository service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        IEnumerable<NoodleDAL> noodlesDAL = await _service.GetNoodles();
        List<DifferentNoodleModel> noodles = new List<DifferentNoodleModel>();
        foreach (NoodleDAL noodleDAL in noodlesDAL)
        {
            DifferentNoodleModel noodle = _mapper.Map<DifferentNoodleModel>(noodleDAL);
            noodles.Add(noodle);
        }
        return View(noodles);
    }

    [HttpGet]
    public async Task<IActionResult> Details([FromRoute]int id)
    {
        var noodleDAL = await _service.GetNoodle(id);
        if (noodleDAL is null)
        {
            return NotFound();
        }

        DifferentNoodleModel noodle = _mapper.Map<DifferentNoodleModel>(noodleDAL);
        return View(noodle);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(DifferentNoodleFormModel differentNoodleForm)
    {
        if (ModelState.IsValid == false)
        {
            return View(differentNoodleForm);
        }

        NoodleDAL noodle = new NoodleDAL()
        {
            NoodleID = 0,
            Name = differentNoodleForm.Nom,
            Meat = differentNoodleForm.Viande,
            Vegetable = differentNoodleForm.Legume,
            Sauce = differentNoodleForm.Sauce
        };

        NoodleDAL createdNoodle = await _service.InsertNoodle(noodle);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        NoodleDAL noodleDAL = await _service.GetNoodle(id);
        if (noodleDAL is null)
        {
            return NotFound();
        }

        DifferentNoodleModel noodleModel = _mapper.Map<DifferentNoodleModel>(noodleDAL);
        return View(noodleModel);
    }
    [HttpPost]
    [ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _service.DeleteNoodle(id);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        NoodleDAL noodleDAL = await _service.GetNoodle(id);
        if (noodleDAL is null)
        {
            return NotFound();
        }

        DifferentNoodleFormModel noodleForm = new()
        {
            Nom = noodleDAL.Name,
            Viande = noodleDAL.Meat,
            Legume = noodleDAL.Vegetable,
            Sauce = noodleDAL.Sauce
        };

        return View(noodleForm);
    }
    [HttpPost]
    [ActionName("Edit")]
    public async Task<IActionResult> EditConfirmed(int id, DifferentNoodleFormModel noodleForm)
    {
        if (ModelState.IsValid == false)
        {
            return View(noodleForm);
        }

        NoodleDAL noodle = new NoodleDAL()
        {
            NoodleID = id,
            Name = noodleForm.Nom,
            Meat = noodleForm.Viande,
            Vegetable = noodleForm.Legume,
            Sauce = noodleForm.Sauce
        };

        await _service.UpdateNoodle(id, noodle);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> NoSauceMushroomNoodles()
    {
        IEnumerable<NoodleDAL> noodlesDAL = await _service.GetNoSauceWithMushroomNoodles();

        List<DifferentNoodleModel> noodles = new List<DifferentNoodleModel>();
        foreach (NoodleDAL noodleDAL in noodlesDAL)
        {
            DifferentNoodleModel noodle = _mapper.Map<DifferentNoodleModel>(noodleDAL);
            noodles.Add(noodle);
        }

        return View(noodles);
    }
}
