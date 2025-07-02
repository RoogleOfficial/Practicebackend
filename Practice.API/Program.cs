
using Microsoft.EntityFrameworkCore;
using Practice.Application;
using Practice.Application.Interfaces;
using Practice.Application.Mappings;
using Practice.Infrastructure.Configurations.Context;
using Practice.Infrastructure.Repositories;
using Practice.Infrastructure.DataSeed;
using Microsoft.AspNetCore.Identity;
using Practice.Application.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Practice.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"));
            });


            builder.Services.AddScoped<IBrandRepository, BrandRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<JwtAuthentication>();


            //Service Registeration for Identity
            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
             .AddJwtBearer(options =>
             {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,
                     ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
                     ValidAudience = builder.Configuration["JwtSettings:Audience"],
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]))
                 };
             });



            builder.Services.AddAutoMapper(typeof(AutoMappingProfile).Assembly);

            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(AssemblyMarker).Assembly);
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontendApp", policy =>
                {
                    policy.WithOrigins("http://localhost:3000") // Next.js dev server
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials(); // if using cookies/auth
                });
            });



            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                 
                Task.Run(async () =>
                {
                    await AppDbSeeder.SeedAsync(db);
                }).GetAwaiter().GetResult();

                var services = scope.ServiceProvider;
                await IdentitySeeder.SeedRoleandAdminAsync(services);
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("AllowFrontendApp");
            app.MapControllers();

            app.Run();
        }
    }
}
