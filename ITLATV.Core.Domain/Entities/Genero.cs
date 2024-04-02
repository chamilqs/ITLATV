namespace ITLATV.Core.Domain.Entities
{
    public class Genero
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        // Un genero puede tener varias series que le utilicen.
        public ICollection<Serie>? Series { get; set; }
    }
}
