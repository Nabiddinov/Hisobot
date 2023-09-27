using Report.Domain.Entities;
using Report.Infrastructure.Contexts;
using Report.Infrastructure.Repositories;

namespace Report.Infrastructure.Repository.Inputs;

public class InputRepository : GenericRepository<Input, Guid>, IInputRepository
{
    public InputRepository(AppDbContext appDbContext)
        : base(appDbContext)
    {
    }
}
