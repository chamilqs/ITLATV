using ITLATV.Core.Application.Interfaces.Services;
using ITLATV.Core.Application.ViewModels.Series;
using Microsoft.AspNetCore.Mvc;

namespace ITLATV.Controllers
{
    public class SerieController : Controller
    {

        private readonly ISerieService _serieService;
        private readonly IProductoraService _productoraService;
        private readonly IGeneroService _generoService;

        public SerieController(ISerieService serieService, IProductoraService productoraService, IGeneroService generoService)
        {
            _serieService = serieService;
            _productoraService = productoraService;
            _generoService = generoService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _serieService.GetAllViewModel());
        }

        public async Task<IActionResult> Create()
        {
            SaveSerieViewModel vm = new();
            vm.Productoras = await _productoraService.GetAllViewModel();
            vm.Generos = await _generoService.GetAllViewModel();
            return View("SaveSerie", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveSerieViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Productoras = await _productoraService.GetAllViewModel();
                vm.Generos = await _generoService.GetAllViewModel();
                return View("SaveSerie", vm);
            }

            await _serieService.Add(vm);
            return RedirectToRoute(new { controller = "Serie", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            SaveSerieViewModel vm = await _serieService.GetByIdSaveViewModel(id);
            vm.Productoras = await _productoraService.GetAllViewModel();
            vm.Generos = await _generoService.GetAllViewModel();
            return View("SaveSerie", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveSerieViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Productoras = await _productoraService.GetAllViewModel();
                vm.Generos = await _generoService.GetAllViewModel();

                return View("SaveSerie", vm);
            }

            await _serieService.Update(vm);
            return RedirectToRoute(new { controller = "Serie", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _serieService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {

            await _serieService.Delete(id);
            return RedirectToRoute(new { controller = "Serie", action = "Index" });
        }
        public async Task<IActionResult> Detail(int id)
        {
            return View(await _serieService.GetByIdSaveViewModel(id));
        }
    }
}
