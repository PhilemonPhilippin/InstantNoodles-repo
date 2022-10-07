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
}
