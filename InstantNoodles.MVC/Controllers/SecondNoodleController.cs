using AutoMapper;
using InstantNoodles.DAL.Data;
using Microsoft.AspNetCore.Mvc;
using NoodleDAL = InstantNoodles.DAL.Models.NoodleModel;
using NoodleMVC = InstantNoodles.MVC.Models.NoodleModel;

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
        List<NoodleMVC> noodles = new List<NoodleMVC>();
        foreach (NoodleDAL noodleDAL in noodlesDAL)
        {
            NoodleMVC noodle = _mapper.Map<NoodleMVC>(noodleDAL);
            noodles.Add(noodle);
        }
        return View(noodles);
    }
}
