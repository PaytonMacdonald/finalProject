using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using finalProject.Repositories;
using finalProject.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MySqlConnector;

namespace finalProject.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureCors(services);
            ConfigureAuth(services);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "finalProject.Server", Version = "v1" });
            });

            services.AddScoped<IDbConnection>(x => CreateDbConnection());

            // NOTE services
            services.AddTransient<AccountService>();
            // services.AddTransient<ValuesService>();
            services.AddTransient<KeepsService>();
            services.AddTransient<VaultsService>();
            services.AddTransient<VaultKeepsService>();
            services.AddTransient<ProfilesService>();

            // NOTE repositories
            services.AddTransient<AccountsRepository>();
            // services.AddTransient<ValuesRepository>();
            services.AddTransient<KeepsRepository>();
            services.AddTransient<VaultsRepository>();
            services.AddTransient<VaultKeepsRepository>();
            services.AddTransient<ProfilesRepository>();


        }

        private void ConfigureCors(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsDevPolicy", builder =>
                {
                    builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .WithOrigins(new string[]{
                        "http://localhost:8080", "http://localhost:8081"
                    });
                });
            });
        }

        private void ConfigureAuth(IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = $"https://{Configuration["AUTH0_DOMAIN"]}/";
                options.Audience = Configuration["AUTH0_AUDIENCE"];
            });

        }

        private IDbConnection CreateDbConnection()
        {
            string connectionString = Configuration["CONNECTION_STRING"];
            return new MySqlConnection(connectionString);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "finalProject.Server v1"));
                app.UseCors("CorsDevPolicy");
            }

            app.UseHttpsRedirection();

            app.UseDefaultFiles();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}