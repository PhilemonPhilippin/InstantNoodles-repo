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
    public async Task<IActionResult> Index()
    {
        MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMap<NoodleDAL, NoodleMVC>());
        Mapper mapper = new Mapper(config);

        IEnumerable<NoodleDAL> noodlesDAL = await _service.GetNoodles();
        List<NoodleMVC> noodles = new List<NoodleMVC>();
        foreach (NoodleDAL noodleDAL in noodlesDAL)
        {
            NoodleMVC noodle = mapper.Map<NoodleMVC>(noodleDAL);
            noodles.Add(noodle);
        }
        return View(noodles);
    }
}
