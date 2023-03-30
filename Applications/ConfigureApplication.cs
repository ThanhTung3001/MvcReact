using System.Reflection;

using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Applications;

public static class ConfigurationServices
{
    // [Obsolete("Obsolete")]
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
        services.AddFluentValidation(options =>
        {
            // Validate child properties and root collection elements
            options.ImplicitlyValidateChildProperties = true;
            options.ImplicitlyValidateRootCollectionElements = true;

            // Automatic registration of validators in assembly
            options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        });

        return services;
    }
}