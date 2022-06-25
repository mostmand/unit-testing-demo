using System;
using System.Threading.Tasks;
using UnitTestingDemo.Abstraction;
using UnitTestingDemo.Models;

namespace UnitTestingDemo;

public class UserInfoService : IUserInfoService
{
    private readonly IGithubApi _githubApi;

    public UserInfoService(IGithubApi githubApi)
    {
        _githubApi = githubApi ?? throw new ArgumentNullException(nameof(githubApi));
    }

    public async Task<UserInfo> GetUserInfo(string userName)
    {
        var numberOfFollowers = await _githubApi.GetUserFollowers(userName);
        return new UserInfo(userName, numberOfFollowers);
    }
}