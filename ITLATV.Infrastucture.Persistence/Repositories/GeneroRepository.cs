using ITLATV.Core.Application.Interfaces.Repositories;
using ITLATV.Core.Domain.Entities;
using ITLATV.Infrastructure.Persistence.Contexts;
using ITLATV.Infrastructure.Persistence.Repositories;

namespace ITLATV.Infrastucture.Persistence.Repositories
{
    public class GeneroRepository : GenericRepository<Genero>, IGeneroRepository
    {
        private readonly ApplicationContext _dbContext;
        public GeneroRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
