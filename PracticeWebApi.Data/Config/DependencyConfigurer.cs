using Microsoft.Extensions.DependencyInjection;
using PracticeWebApi.Common;
using PracticeWebApi.Data.Repositories;

namespace PracticeWebApi.Data.Config;

public class DependencyConfigurer : IDependencyConfigurer
{
    public void Configure(IServiceCollection services)
    {
        services.AddScoped<IUserRepo, UserRepo>();
    }
}
