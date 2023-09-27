using Report.Application.DTO.Users;
using Report.Domain.Entities;

namespace Report.Application.Service.Users;


public interface IUserFactory
{
    UserDto MapToUserDto(User user);
    User MapToUser(UserForCreationDto userForCreationDto);
    void MapToUser(User storageUser, UserForModificationDto userForCreationDto);
}
