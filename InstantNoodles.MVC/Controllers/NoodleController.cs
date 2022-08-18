using AutoMapper;
using InstantNoodles.DAL.Data;
using Microsoft.AspNetCore.Mvc;
using NoodleDAL = InstantNoodles.DAL.Models.NoodleModel;
using NoodleMVC = InstantNoodles.MVC.Models.NoodleModel;

namespace InstantNoodles.MVC.Controllers;
public class NoodleController : Controller
{
    private INoodleData _service;
    public NoodleController(INoodleData service)
    {
        _service = service;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        Mapper mapper = CreateMapper<NoodleDAL, NoodleMVC>();

        IEnumerable<NoodleDAL> noodlesDAL = await _service.GetNoodles();
        List<NoodleMVC> noodles = new List<NoodleMVC>();
        foreach (NoodleDAL noodleDAL in noodlesDAL)
        {
            NoodleMVC noodle = mapper.Map<NoodleMVC>(noodleDAL);
            noodles.Add(noodle);
        }
        return View(noodles);
    }
    [HttpGet]
    public async Task<IActionResult> Details([FromRoute]int id)
    {
        Mapper mapper = CreateMapper<NoodleDAL?, NoodleMVC>();
        NoodleDAL? noodleDAL = await _service.GetNoodle(id);
        if (noodleDAL is null)
            return NotFound();
        NoodleMVC noodle = mapper.Map<NoodleMVC>(noodleDAL);
        return View(noodle);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        Mapper mapper = CreateMapper<NoodleDAL?, NoodleMVC>();
        NoodleDAL? noodleDAL = await _service.GetNoodle(id);
        if (noodleDAL is null)
            return NotFound();
        NoodleMVC noodle = mapper.Map<NoodleMVC>(noodleDAL);
        return View(noodle);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        Console.WriteLine("My id is : " + id);
        await _service.DeleteNoodle(id);
        return RedirectToAction(nameof(Index));
    }

    private Mapper CreateMapper<TSource, UDestination>()
    {
        MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMap<TSource, UDestination>());
        Mapper mapper = new Mapper(config);
        return mapper;
    }
}
