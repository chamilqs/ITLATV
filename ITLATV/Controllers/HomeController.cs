using ITLATV.Core.Application.Interfaces.Services;
using ITLATV.Core.Application.ViewModels.Series;
using Microsoft.AspNetCore.Mvc;

namespace ITLATV.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISerieService _serieService;
        private readonly IProductoraService _productoraService;
        private readonly IGeneroService _generoService;
        public HomeController(ISerieService serieService, IProductoraService productoraService, IGeneroService generoService)
        {
            _serieService = serieService;
            _productoraService = productoraService;
            _generoService = generoService;
        }

        public async Task<IActionResult> Index(FilterSerieViewModel vm)
        {
            ViewBag.Productoras = await _productoraService.GetAllViewModel();
            ViewBag.Generos = await _generoService.GetAllViewModel();
            return View(await _serieService.GetAllViewModel());
            
        }
        public async Task<IActionResult> Productora(FilterSerieViewModel vm)
        {
            ViewBag.Productoras = await _productoraService.GetAllViewModel();
            ViewBag.Generos = await _generoService.GetAllViewModel();
            return View("Index",await _serieService.GetAllViewModelWithFilters(vm));

        }
        public async Task<IActionResult> Genero(FilterSerieViewModel vm)
        {
            ViewBag.Productoras = await _productoraService.GetAllViewModel();
            ViewBag.Generos = await _generoService.GetAllViewModel();
            return View("Index",await _serieService.GetAllViewModelWithFiltersG(vm));

        }

        public async Task<IActionResult> Search(string nombreSerie)
        {
            ViewBag.Productoras = await _productoraService.GetAllViewModel();
            ViewBag.Generos = await _generoService.GetAllViewModel();

            return View("Index", await _serieService.GetByNombreAsync(nombreSerie));
        }

    }
}

