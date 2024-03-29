﻿using AutoMapper;
using InstantNoodles.DAL.Data;
using Microsoft.AspNetCore.Mvc;
using InstantNoodles.MVC.Models;
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
        NoodleDAL? noodleDAL = await _service.GetNoodle(id);
        if (noodleDAL is null)
            return NotFound();

        Mapper mapper = CreateMapper<NoodleDAL?, NoodleMVC>();
        NoodleMVC noodle = mapper.Map<NoodleMVC>(noodleDAL);
        return View(noodle);
    }
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }
    [HttpPost, ActionName("Create")]
    public async Task<IActionResult> Create(NoodleFormModel noodleForm)
    {
        if (!ModelState.IsValid)
            return View(noodleForm);

        NoodleDAL noodle = new NoodleDAL()
        {
            NoodleID = 0,
            Name = noodleForm.Name,
            Meat = noodleForm.Meat,
            Vegetable = noodleForm.Vegetable,
            Sauce = noodleForm.Sauce
        };
        await _service.InsertNoodle(noodle);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {

        NoodleDAL? noodleDAL = await _service.GetNoodle(id);
        if (noodleDAL is null)
            return NotFound();

        NoodleFormModel noodleForm = new NoodleFormModel()
        {
            Name = noodleDAL.Name,
            Meat = noodleDAL.Meat,
            Vegetable = noodleDAL.Vegetable,
            Sauce = noodleDAL.Sauce
        };
        return View(noodleForm);
    }
    [HttpPost, ActionName("Edit")]
    public async Task<IActionResult> Edit(int id, NoodleFormModel noodleForm)
    {
        if (!ModelState.IsValid)
            return View(noodleForm);

        NoodleDAL noodle = new NoodleDAL()
        {
            NoodleID = id,
            Name = noodleForm.Name,
            Meat = noodleForm.Meat,
            Vegetable = noodleForm.Vegetable,
            Sauce = noodleForm.Sauce
        };
        await _service.UpdateNoodle(noodle);
        return RedirectToAction(nameof(Index));
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
