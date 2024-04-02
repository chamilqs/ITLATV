namespace ITLATV.Core.Domain.Entities
{
    public class Productora
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        // Una productora puede tener varias series producidas
        public ICollection<Serie>? Series { get; set; }
    }
}
