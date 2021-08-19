using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Pokemon.Api.Installers
{
    public interface IInstaller
    {
        void InstallServices(IServiceCollection services,IConfiguration configuration);
    }
}
