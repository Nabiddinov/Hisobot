using Report.Domain.Entities;
using Report.Infrastructure.Repositories;

namespace EasyJob.Infrastructure.Repositories.Users;

public interface IUserRepository : IGenericRepository<User, Guid>
{
}