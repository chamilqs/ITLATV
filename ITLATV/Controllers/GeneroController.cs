﻿using ITLATV.Core.Application.Interfaces.Services;
using ITLATV.Core.Application.ViewModels.Generos;
using Microsoft.AspNetCore.Mvc;

namespace ITLATV.Controllers
{
    public class GeneroController : Controller
    {
        private readonly IGeneroService _generoService;

        public GeneroController(IGeneroService generoService)
        {
            _generoService = generoService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _generoService.GetAllViewModel());
        }

        public IActionResult Create()
        {
            return View("SaveGenero", new SaveGeneroViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveGeneroViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveGenero", vm);
            }

            await _generoService.Add(vm);
            return RedirectToRoute(new { controller = "Genero", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View("SaveGenero", await _generoService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveGeneroViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveGenero", vm);
            }

            await _generoService.Update(vm);
            return RedirectToRoute(new { controller = "Genero", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _generoService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {

            await _generoService.Delete(id);
            return RedirectToRoute(new { controller = "Genero", action = "Index" });
        }
    }
}

