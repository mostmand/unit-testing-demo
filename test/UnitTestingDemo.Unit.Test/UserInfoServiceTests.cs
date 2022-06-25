using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using UnitTestingDemo.Abstraction;
using UnitTestingDemo.Models;
using Xunit;

namespace UnitTestingDemo.Unit.Test;

public class UserInfoServiceTests
{
    private readonly IGithubApi _githubApi;
    private readonly IUserInfoService _sut;

    public UserInfoServiceTests()
    {
        _githubApi = Substitute.For<IGithubApi>();
        _sut = new UserInfoService(_githubApi);
    }

    [Fact]
    public async Task GetUserInfo_ShouldReturnUserInfoOfTheUser_WhenProvidedUsername()
    {
        // Arrange
        _githubApi.GetUserFollowers("mostmand").Returns(Task.FromResult(21));

        // Act
        var userInfo = await _sut.GetUserInfo("mostmand");

        // Assert
        userInfo.Should().Be(new UserInfo("mostmand", 21));
    }
}