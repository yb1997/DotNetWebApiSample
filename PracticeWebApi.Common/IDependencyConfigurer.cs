using Microsoft.Extensions.DependencyInjection;

namespace PracticeWebApi.Common
{
    public interface IDependencyConfigurer
    {
        void Configure(IServiceCollection services);
    }
}