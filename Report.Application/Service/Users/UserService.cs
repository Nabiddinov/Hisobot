using EasyJob.Infrastructure.Repositories.Users;
using Report.Application.DTO.Users;

namespace Report.Application.Service.Users;

public partial class UserService : IUserService
{
    private readonly IUserRepository userRepository;
    private readonly IUserFactory userFactory;

    public UserService(
        IUserRepository userRepository,
        IUserFactory userFactory)
    {
        this.userRepository = userRepository;
        this.userFactory = userFactory;
    }

    public async ValueTask<UserDto> CreateUserAsync(
        UserForCreationDto userForCreationDto)
    {
        ValidateUserForCreationDto(userForCreationDto);

        var newUser = this.userFactory
            .MapToUser(userForCreationDto);

        var addedUser = await this.userRepository
            .InsertAsync(newUser);

        return this.userFactory.MapToUserDto(addedUser);
    }



    public async ValueTask<UserDto> RetrieveUserByIdAsync(Guid userId)
    {

        var storageUser = await this.userRepository
            .SelectByIdAsync(userId);

        ValidateStorageUser(storageUser, userId);

        return this.userFactory.MapToUserDto(storageUser);
    }

    public async ValueTask<UserDto> ModifyUserAsync(
        UserForModificationDto userForModificationDto)
    {
        ValidateUserForModificationDto(userForModificationDto);

        var storageUser = await this.userRepository
            .SelectByIdAsync(userForModificationDto.userId);

        ValidateStorageUser(storageUser, userForModificationDto.userId);

        this.userFactory.MapToUser(storageUser, userForModificationDto);

        var modifiedUser = await this.userRepository
            .UpdateAsync(storageUser);

        return this.userFactory.MapToUserDto(modifiedUser);
    }

    public async ValueTask<UserDto> RemoveUserAsync(Guid userId)
    {

        var storageUser = await this.userRepository
            .SelectByIdAsync(userId);

        ValidateStorageUser(storageUser, userId);

        var removedUser = await this.userRepository
            .DeleteAsync(storageUser);

        return this.userFactory.MapToUserDto(removedUser);
    }

    public IQueryable<UserDto> RetrieveUsers()
    {
        var users = this.userRepository.SelectAll();

        return users.Select(user =>
            this.userFactory.MapToUserDto(user));
    }
}
