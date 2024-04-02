using ITLATV.Core.Application.Interfaces.Repositories;
using ITLATV.Core.Application.Interfaces.Services;
using ITLATV.Core.Application.ViewModels.Generos;
using ITLATV.Core.Domain.Entities;

namespace ITLATV.Core.Application.Services
{
    public class GeneroService : IGeneroService
    {
        private readonly IGeneroRepository _generoRepository;

        public GeneroService(IGeneroRepository categoryRepository)
        {
            _generoRepository = categoryRepository;
        }

        public async Task Update(SaveGeneroViewModel vm)
        {
            Genero genero = new();
            genero.Id = vm.Id;
            genero.Nombre = vm.Nombre;          

            await _generoRepository.UpdateAsync(genero);
        }

        public async Task Add(SaveGeneroViewModel vm)
        {
            Genero genero = new();
            genero.Nombre = vm.Nombre;

            await _generoRepository.AddAsync(genero);
        }

        public async Task Delete(int id)
        {
            var genero = await _generoRepository.GetByIdAsync(id);
            await _generoRepository.DeleteAsync(genero);
        }

        public async Task<SaveGeneroViewModel> GetByIdSaveViewModel(int id)
        {
            var genero = await _generoRepository.GetByIdAsync(id);

            SaveGeneroViewModel vm = new();
            vm.Id = genero.Id;
            vm.Nombre = genero.Nombre;

            return vm;
        }

        public async Task<List<GeneroViewModel>> GetAllViewModel()
        {
            var generoList = await _generoRepository.GetAllWithIncludeAsync(new List<string> { "Series"});

            return generoList.Select(genero => new GeneroViewModel
            {
                Nombre = genero.Nombre,
                Id= genero.Id,
                CantidadDeSeries = genero.Series.Count()
            }).ToList();
        }

    }
}
