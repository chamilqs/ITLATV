using ITLATV.Core.Application.Interfaces.Repositories;
using ITLATV.Core.Domain.Entities;
using ITLATV.Infrastructure.Persistence.Contexts;
using ITLATV.Infrastructure.Persistence.Repositories;

namespace ITLATV.Infrastucture.Persistence.Repositories
{
    public class SerieRepository : GenericRepository<Serie>, ISerieRepository
    {
        private readonly ApplicationContext _dbContext;

        public SerieRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
