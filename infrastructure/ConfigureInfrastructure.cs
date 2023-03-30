using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Applications.Common.Interface;
using Domain.Entities.Users;
using infrastructure.Enum;
using infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace infrastructure
{
    public static class ConfigureInfrastructure
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString"), // Thêm cấu hình cho database
                    (builder) => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)); //Xác định db context cần để migration
        
            });
            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());// Injection IAppDbContext and AppDbContext
            services.AddScoped<AppDbContextInitializer>();
            services
                .AddDefaultIdentity<ApplicationUser>()  //Add Config Identity User,Role and DbContext
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!))
                    };
                });
            services.AddTransient<IApplicationDbContext, ApplicationDbContext>();

            services.AddAuthorization(options => options.AddPolicy("CanPurge", policy => policy.RequireRole(Role.Administration.ToString())));

            return services;
        }
    }
}
