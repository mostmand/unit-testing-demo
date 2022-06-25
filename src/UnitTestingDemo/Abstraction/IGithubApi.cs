using System.Threading.Tasks;

namespace UnitTestingDemo.Abstraction;

public interface IGithubApi
{
    Task<int> GetUserFollowers(string loginName);
}