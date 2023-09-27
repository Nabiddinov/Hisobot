using Report.Domain.Entities;
using Report.Infrastructure.Contexts;
using Report.Infrastructure.Repositories;

namespace EasyJob.Infrastructure.Repositories.Users;

public sealed class UserRepository : GenericRepository<User, Guid>, IUserRepository
{
    public UserRepository(AppDbContext appDbContext)
        : base(appDbContext)
    {
    }
}