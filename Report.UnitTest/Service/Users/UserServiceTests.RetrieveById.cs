using EasyJob.Infrastructure.Repositories.Users;
using Moq;
using Report.Application.DTO.Users;
using Report.Application.Service.Users;
using Report.Domain.Entities;
using Report.Domain.Enums;
using Report.Domain.Exceptions;
using Xunit;

namespace Report.UnitTest.Service.Users;

public partial class UserServiceTests
{
    [Fact]
    public async Task Should_ThrowNotFoundExceptionOnRetrieveById()
    {
        var randomUserId = Guid.NewGuid();
        User storageUser = null;

        userMockRepository.Setup(mock => mock.SelectByIdWithDetailsAsync(
                user => user.Id == randomUserId,
                new string[] { }));

        ValueTask<UserDto> userDtoTask = this.userService
            .RetrieveUserByIdAsync(randomUserId);

        await Assert.ThrowsAsync<NotFoundException>(userDtoTask.AsTask);
    }

    [Fact]
    public async Task RetrieveUserByIdAsync_ReturnsCorrectUser()
    {
        var userId = Guid.NewGuid();
        var storageUser = new User { Id = userId, FamilyName = "Aliev" };
        var userDto = new UserDto(userId, "Aliev",  "ali@gmail.com", UserRole.Admin);

        var userRepositoryMock = new Mock<IUserRepository>();

        userRepositoryMock
            .Setup(x => x.SelectByIdAsync(userId))
            .ReturnsAsync(storageUser);

        var userFactoryMock = new Mock<IUserFactory>();
        userFactoryMock
            .Setup(x => x.MapToUserDto(storageUser))
            .Returns(userDto);

        var userManagement = new UserService(userRepositoryMock.Object, userFactoryMock.Object);

        var result = await userManagement.RetrieveUserByIdAsync(userId);

        userRepositoryMock.Verify(x => x.SelectByIdAsync(userId), Times.Once);
        userFactoryMock.Verify(x => x.MapToUserDto(storageUser), Times.Once);
        Assert.NotNull(result);
        Assert.Equal(userId, result.id);
        Assert.Equal("Aliev", result.familyName);
    }

}
