using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLATV.Core.Application.ViewModels.Productoras
{
    public class SaveProductoraViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe colocar el nombre de la productora.")]
        public string Nombre { get; set; }

    }
}
