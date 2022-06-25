using System.Threading.Tasks;
using Octokit;
using UnitTestingDemo.Abstraction;

namespace UnitTestingDemo;

public class GithubApi : IGithubApi
{
    private const string UnitTestingDemo = "unit-testing-demo";

    public async Task<int> GetUserFollowers(string loginName)
    {
        var client = new GitHubClient(new ProductHeaderValue(UnitTestingDemo));
        var user = await client.User.Get(loginName);
        return user.Followers;
    }
}