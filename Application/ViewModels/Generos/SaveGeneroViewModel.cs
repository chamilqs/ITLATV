using System.ComponentModel.DataAnnotations;

namespace ITLATV.Core.Application.ViewModels.Generos
{
    public class SaveGeneroViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe colocar el nombre del género.")]
        public string Nombre { get; set; }
    }
}
