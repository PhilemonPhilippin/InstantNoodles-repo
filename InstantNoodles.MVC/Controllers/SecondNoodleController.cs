using InstantNoodles.DAL.Data;
using Microsoft.AspNetCore.Mvc;
using NoodleDAL = InstantNoodles.DAL.Models.NoodleModel;

namespace InstantNoodles.MVC.Controllers;
public class SecondNoodleController : Controller
{
    private INoodleRepository _service;
    public SecondNoodleController(INoodleRepository service)
    {
        _service = service;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        IEnumerable<NoodleDAL> noodles = await _service.GetNoodles();
        return View(noodles);
    }
}
