using Microsoft.Extensions.DependencyInjection;
using PracticeWebApi.Business.Services;
using PracticeWebApi.Common;

namespace PracticeWebApi.Business.Config;

public class DependencyConfigurer : IDependencyConfigurer
{
    public void Configure(IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();
    }
}
