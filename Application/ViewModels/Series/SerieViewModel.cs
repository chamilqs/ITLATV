namespace ITLATV.Core.Application.ViewModels.Series
{
    public class SerieViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string EnlaceCaratula { get; set; }
        public int GeneroPrimarioId { get; set; }
        public string GeneroPrimario { get; set; }
        public int? GeneroSecundarioId { get; set; }
        public string? GeneroSecundario { get; set; }
        public int ProductoraId { get; set; }
        public string NombreProductora { get; set; }
    }
}
