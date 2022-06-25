using System.Threading.Tasks;
using UnitTestingDemo.Models;

namespace UnitTestingDemo.Abstraction;

public interface IUserInfoService
{
    Task<UserInfo> GetUserInfo(string userName);
}