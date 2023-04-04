using System.Collections;
using System.Runtime.CompilerServices;
using Applications.Common.Interface;
using WebUi.Services;

namespace WebUi
{
    public static class ConfigureWebUi
    {
        public static IServiceCollection AddConfigureWebUi(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            services.AddScoped<ICurrentUserService, CurrentUserServices>();
           
            services.AddSwaggerGen(c =>
            {
                // c.SwaggerDoc();                
            });
            
            services.AddControllers();
            services.AddLogging();
            return services;
        }
    }
}
