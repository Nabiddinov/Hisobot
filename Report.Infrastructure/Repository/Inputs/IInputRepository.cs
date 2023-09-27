using Report.Domain.Entities;
using Report.Infrastructure.Repositories;

namespace Report.Infrastructure.Repository.Inputs;

public interface IInputRepository : IGenericRepository<Input, Guid>
{
}
