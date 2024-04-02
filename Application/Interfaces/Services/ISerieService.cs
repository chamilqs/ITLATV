﻿using ITLATV.Core.Application.ViewModels.Series;

namespace ITLATV.Core.Application.Interfaces.Services
{
    public interface ISerieService : IGenericService<SaveSerieViewModel, SerieViewModel>
    {
        Task<List<SerieViewModel>> GetByNombreAsync(string nombreSerie);
        Task<List<SerieViewModel>> GetAllViewModelWithFilters(FilterSerieViewModel filters);
        Task<List<SerieViewModel>> GetAllViewModelWithFiltersG(FilterSerieViewModel filters);
    }
}
