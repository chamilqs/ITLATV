namespace ITLATV.Core.Domain.Entities
{
    public class Serie
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string EnlaceCaratula { get; set; }
        public string EnlaceVideo { get; set; }
        public int GeneroPrimarioId { get; set; }
        public int? GeneroSecundarioId { get; set; }
        public Genero? Genero { get; set; }

        // Una serie tiene una productora, una productora puede tener varias series.
        public int ProductoraId { get; set; }
        public Productora Productora { get; set; }
    }
}
