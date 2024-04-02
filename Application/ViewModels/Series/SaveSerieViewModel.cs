using ITLATV.Core.Application.ViewModels.Generos;
using ITLATV.Core.Application.ViewModels.Productoras;
using System.ComponentModel.DataAnnotations;
namespace ITLATV.Core.Application.ViewModels.Series
{
    public class SaveSerieViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe colocar el nombre de la serie.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe colocar el enlace de la caratula de la serie.")]
        public string EnlaceCaratula { get; set; }
        [Required(ErrorMessage = "Debe colocar el enlace de video de la serie.")]
        public string EnlaceVideo { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Debe colocar el género de la serie.")]
        public int GeneroPrimarioId { get; set; }
        public int? GeneroSecundarioId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Debe colocar la productora de la serie.")]
        public int ProductoraId { get; set; }

        public List<ProductoraViewModel>? Productoras { get; set; }
        public List<GeneroViewModel>? Generos { get; set; }
    }
}
