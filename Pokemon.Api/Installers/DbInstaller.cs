using System;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pokemon.Core.Pokemon.Helpers;
using Pokemon.Infrastructure;

namespace Pokemon.Api.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PokemonDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString"),
                b => b.MigrationsAssembly("Pokemon.Infrastructure")));
            
            var assembly = AppDomain.CurrentDomain.Load("Pokemon.Core");
            services.AddMediatR(assembly);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<UrlHelper>(provider =>
                {
                    var acessor = provider.GetRequiredService<IHttpContextAccessor>();
                    var request = acessor.HttpContext.Request;
                    var absolutUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent(), "/");
                    return new UrlHelper(absolutUri);
                }
            );


 
        }
   
    }
}
