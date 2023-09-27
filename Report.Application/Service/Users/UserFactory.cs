using Test.Infrastructure.Authentication;
using Report.Application.DTO.Users;
using Report.Domain.Entities;
using Report.Domain.Enums;

namespace Report.Application.Service.Users;

public class UserFactory : IUserFactory
{
    private readonly IPasswordHasher passwordHasher;

    public UserFactory(IPasswordHasher passwordHasher)
    {
        this.passwordHasher = passwordHasher;
    }

    public User MapToUser(
        UserForCreationDto userForCreationDto)
    {
        string randomSalt = Guid.NewGuid().ToString();

        return new User
        {
            FamilyName = userForCreationDto.familyName,
            Email = userForCreationDto.email,


            Salt = randomSalt,

            PasswordHash = this.passwordHasher.Encrypt(
                password: userForCreationDto.password,
                salt: randomSalt),

            Role = UserRole.HeadFamily
        };
    }

    public void MapToUser(
        User storageUser,
        UserForModificationDto userForModificationDto)
    {
        storageUser.FamilyName = userForModificationDto.familyName ?? storageUser.FamilyName;
        storageUser.Role = userForModificationDto.userRole ?? storageUser.Role;
    }

    public UserDto MapToUserDto(User user)
    {
        return new UserDto(
            user.Id,
            user.FamilyName,
            user.Email,
            user.Role);
    }
}
