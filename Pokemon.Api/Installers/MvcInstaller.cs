using System;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Pokemon.Core.Filters;
using Pokemon.Infrastructure;

namespace Pokemon.Api.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddMvc(options =>
                options.Filters.Add<ValidationFilter>());
            
            var assembly = AppDomain.CurrentDomain.Load("Pokemon.Core");
            services.AddFluentValidation(mvcConfiguration=> mvcConfiguration.RegisterValidatorsFromAssembly(assembly));

            
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pokemon", Version = "v1" });
            });
        }
    }
}
