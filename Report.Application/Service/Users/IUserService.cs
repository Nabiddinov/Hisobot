using Report.Application.DTO.Users;

namespace Report.Application.Service.Users;

public interface IUserService
{
    ValueTask<UserDto> CreateUserAsync(UserForCreationDto userForCreationDto);
    ValueTask<UserDto> RetrieveUserByIdAsync(Guid userId);
    IQueryable<UserDto> RetrieveUsers();
    ValueTask<UserDto> ModifyUserAsync(UserForModificationDto userForModificationDto);
    ValueTask<UserDto> RemoveUserAsync(Guid userId);
}
