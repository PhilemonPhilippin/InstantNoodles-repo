using InstantNoodles.DAL.Data;
using InstantNoodles.DAL.Models;
using Microsoft.AspNetCore.Mvc;

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
        IEnumerable<NoodleModel> noodles = await _service.GetNoodles();
        return View(noodles);
    }
}
