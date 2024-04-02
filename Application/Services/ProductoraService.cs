using ITLATV.Core.Application.Interfaces.Repositories;
using ITLATV.Core.Application.Interfaces.Services;
using ITLATV.Core.Application.ViewModels.Generos;
using ITLATV.Core.Application.ViewModels.Productoras;
using ITLATV.Core.Domain.Entities;

namespace ITLATV.Core.Application.Services
{
    public class ProductoraService : IProductoraService
    {

        private readonly IProductoraRepository _productoraRepository;

        public ProductoraService(IProductoraRepository productoraRepository)
        {
            _productoraRepository = productoraRepository;
        }

        public async Task Update(SaveProductoraViewModel vm)
        {
            Productora productora = new();
            productora.Id = vm.Id;
            productora.Nombre = vm.Nombre;

            await _productoraRepository.UpdateAsync(productora);
        }

        public async Task Add(SaveProductoraViewModel vm)
        {
            Productora productora = new();
            productora.Nombre = vm.Nombre;

            await _productoraRepository.AddAsync(productora);
        }

        public async Task Delete(int id)
        {
            var productora = await _productoraRepository.GetByIdAsync(id);
            await _productoraRepository.DeleteAsync(productora);
        }

        public async Task<SaveProductoraViewModel> GetByIdSaveViewModel(int id)
        {
            var productora = await _productoraRepository.GetByIdAsync(id);

            SaveProductoraViewModel vm = new();
            vm.Id = productora.Id;
            vm.Nombre = productora.Nombre;

            return vm;
        }

        public async Task<List<ProductoraViewModel>> GetAllViewModel()
        {
            var productoraList = await _productoraRepository.GetAllWithIncludeAsync(new List<string> { "Series" });

            return productoraList.Select(productora => new ProductoraViewModel
            {
                Nombre = productora.Nombre,
                Id = productora.Id,
                CantidadDeSeries = productora.Series.Count()

            }).ToList();
        }

    }
}
