using Microsoft.OpenApi.Models;
using PurityPlus.Database.Entity;
using PurityPlus.Database.Repository;
using PurityPlus.Server.Contracts;
using PurityPlus.Server.Services;
using PurityPlus.Services.DTO;
using PurityPlus.Services.Interface;
using PurityPlus.Services.Services;
using PurityPlus.Services.Services.Interface;

namespace PurityPlus.Server.Extensions
{
    public static class ServiceExxtension
    {
        public static void AddAllApplicationServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "My API",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                 {
                     new OpenApiSecurityScheme
                     {
                       Reference = new OpenApiReference
                       {
                         Type = ReferenceType.SecurityScheme,
                         Id = "Bearer"
                       }
                      },
                      new string[] { }
                    }
                  });
                });

            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IAwsS3Service, AwsS3Service>();
            services.AddScoped<PaginationService<Product, ProductDTO>>();
            services.AddScoped<PaginationService<Brand, BrandDTO>>();
            services.AddScoped<PaginationService<Category, CategoryDTO>>();
            services.AddScoped<PaginationService<Order, OrderDTO>>();

        }
    }
}
