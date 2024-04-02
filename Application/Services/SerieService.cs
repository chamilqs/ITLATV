using ITLATV.Core.Application.Interfaces.Repositories;
using ITLATV.Core.Application.Interfaces.Services;
using ITLATV.Core.Application.ViewModels.Series;
using ITLATV.Core.Domain.Entities;

namespace ITLATV.Core.Application.Services
{
    public class SerieService : ISerieService
    {
        private readonly ISerieRepository _serieRepository;

        public SerieService(ISerieRepository serieRepository)
        {
            _serieRepository = serieRepository;
        }

        public async Task Update(SaveSerieViewModel vm)
        {
            Serie serie = new();
            serie.Id = vm.Id;
            serie.Nombre = vm.Nombre;
            serie.EnlaceCaratula = vm.EnlaceCaratula;
            serie.EnlaceVideo = vm.EnlaceVideo;
            serie.GeneroPrimarioId = vm.GeneroPrimarioId;
            serie.GeneroSecundarioId = vm.GeneroSecundarioId;
            serie.ProductoraId = vm.ProductoraId;

            await _serieRepository.UpdateAsync(serie);
        }

        public async Task Add(SaveSerieViewModel vm)
        {
            Serie serie = new();
            serie.Nombre = vm.Nombre;
            serie.EnlaceCaratula = vm.EnlaceCaratula;
            serie.EnlaceVideo = vm.EnlaceVideo;
            serie.GeneroPrimarioId = vm.GeneroPrimarioId;
            serie.GeneroSecundarioId = vm.GeneroSecundarioId;
            serie.ProductoraId = vm.ProductoraId;

            await _serieRepository.AddAsync(serie);
        }

        public async Task Delete(int id)
        {
            var serie = await _serieRepository.GetByIdAsync(id);
            await _serieRepository.DeleteAsync(serie);
        }

        public async Task<SaveSerieViewModel> GetByIdSaveViewModel(int id)
        {
            var serie = await _serieRepository.GetByIdAsync(id);

            SaveSerieViewModel vm = new();
            vm.Id = serie.Id;
            vm.Nombre = serie.Nombre;
            vm.EnlaceCaratula = serie.EnlaceCaratula;
            vm.EnlaceVideo = serie.EnlaceVideo;
            vm.GeneroPrimarioId = serie.GeneroPrimarioId;
            vm.GeneroSecundarioId = serie.GeneroSecundarioId;
            vm.ProductoraId = serie.ProductoraId;

            return vm;
        }

        public async Task<List<SerieViewModel>> GetAllViewModel()
        {
            var serieList = await _serieRepository.GetAllWithIncludeAsync(new List<string> { "Genero", "Productora" });

            return serieList.Select(serie => new SerieViewModel
            {                               
                Id = serie.Id,
                Nombre = serie.Nombre,
                EnlaceCaratula = serie.EnlaceCaratula,
                GeneroPrimarioId = serie.Genero != null ? serie.Genero.Id : 0,
                GeneroPrimario = serie.Genero != null ? serie.Genero.Nombre : null,
                GeneroSecundarioId = serie.Genero != null ? serie.Genero.Id : 0,
                GeneroSecundario = serie.Genero != null ? serie.Genero.Nombre : null,
                ProductoraId = serie.Productora != null ? serie.Productora.Id : 0,
                NombreProductora = serie.Productora != null ? serie.Productora.Nombre : null

            }).ToList();
        }


        public async Task<List<SerieViewModel>> GetAllViewModelWithFilters(FilterSerieViewModel filters)
        {
            var serieList = await _serieRepository.GetAllWithIncludeAsync(new List<string> { "Productora", "Genero" });

            var listViewModels = serieList.Select(serie => new SerieViewModel
            {
                Id = serie.Id,
                Nombre = serie.Nombre,
                EnlaceCaratula = serie.EnlaceCaratula,
                GeneroPrimarioId = serie.Genero != null ? serie.Genero.Id : 0,
                GeneroPrimario = serie.Genero != null ? serie.Genero.Nombre : null,
                GeneroSecundarioId = serie.Genero != null ? serie.Genero.Id : 0,
                GeneroSecundario = serie.Genero != null ? serie.Genero.Nombre : null,
                NombreProductora = serie.Productora.Nombre,
                ProductoraId = serie.Productora.Id

            }).ToList();

            if (filters.ProductoraId != null)
            {
                listViewModels = listViewModels.Where(productora => productora.ProductoraId == filters.ProductoraId.Value).ToList();
            }

            return listViewModels;
        }

        public async Task<List<SerieViewModel>> GetAllViewModelWithFiltersG(FilterSerieViewModel filters)
        {
            var serieList = await _serieRepository.GetAllWithIncludeAsync(new List<string> { "Productora", "Genero" });

            var listViewModels = serieList.Select(serie => new SerieViewModel
            {
                Id = serie.Id,
                Nombre = serie.Nombre,
                EnlaceCaratula = serie.EnlaceCaratula,
                GeneroPrimarioId = serie.Genero != null ? serie.Genero.Id : 0,
                GeneroPrimario = serie.Genero != null ? serie.Genero.Nombre : null,
                GeneroSecundarioId = serie.Genero != null ? serie.Genero.Id : 0,
                GeneroSecundario = serie.Genero != null ? serie.Genero.Nombre : null,
                NombreProductora = serie.Productora.Nombre,
                ProductoraId = serie.Productora.Id

            }).ToList();

            if (filters.GeneroId != null)
            {
                listViewModels = listViewModels.Where(genero => genero.GeneroPrimarioId == filters.GeneroId.Value || genero.GeneroSecundarioId == filters.GeneroId.Value).ToList();
            }

            return listViewModels;
        }

        public async Task<List<SerieViewModel>> GetByNombreAsync(string nombreSerie)
        {
            var serieList = await _serieRepository.GetAllWithIncludeAsync(new List<string> { "Productora", "Genero" });

            var listViewModels = serieList.Select(serie => new SerieViewModel
            {
                Id = serie.Id,
                Nombre = serie.Nombre,
                EnlaceCaratula = serie.EnlaceCaratula,
                GeneroPrimarioId = serie.Genero != null ? serie.Genero.Id : 0,
                GeneroPrimario = serie.Genero != null ? serie.Genero.Nombre : null,
                GeneroSecundarioId = serie.Genero != null ? serie.Genero.Id : 0,
                GeneroSecundario = serie.Genero != null ? serie.Genero.Nombre : null,
                NombreProductora = serie.Productora.Nombre,
                ProductoraId = serie.Productora.Id

            }).ToList();

            if (nombreSerie != null)
            {
                listViewModels = listViewModels.Where(serie => serie.Nombre.ToLower().Contains(nombreSerie.ToLower())).ToList();
            }

            return listViewModels;
        }
    }
}
