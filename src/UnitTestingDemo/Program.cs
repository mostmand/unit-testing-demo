using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using UnitTestingDemo.Abstraction;

namespace UnitTestingDemo;

public static class Program
{
    [STAThread]
    public static async Task Main()
    {
        var serviceProvider = SetupApplication();
        
        var userInfoService = serviceProvider.GetRequiredService<IUserInfoService>();
        var userInfo = await userInfoService.GetUserInfo("mostmand");
        Console.WriteLine(userInfo);
    }

    private static ServiceProvider SetupApplication()
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddScoped<IGithubApi, GithubApi>();
        serviceCollection.AddScoped<IUserInfoService, UserInfoService>();

        var serviceProvider = serviceCollection.BuildServiceProvider();
        return serviceProvider;
    }
}