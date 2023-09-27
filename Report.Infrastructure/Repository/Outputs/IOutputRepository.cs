using Report.Domain.Entities;
using Report.Infrastructure.Repositories;

namespace Report.Infrastructure.Repository.Outputs;

public interface IOutputRepository : IGenericRepository<Output, Guid>
{
}
