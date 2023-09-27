using Report.Domain.Entities;
using Report.Infrastructure.Contexts;
using Report.Infrastructure.Repositories;

namespace Report.Infrastructure.Repository.Outputs;

public class OutputRepository : GenericRepository<Output, Guid>, IOutputRepository
{
    public OutputRepository(AppDbContext appDbContext)
        : base(appDbContext)
    {
    }
}