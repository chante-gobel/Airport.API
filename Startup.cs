using Microsoft.Extensions.Configuration;
using Airport.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using Airport.API.Adapters;
using Airport.API.Authentication;
using Airport.API.Authorization;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json;

namespace Airport.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddTransient<IAiportServiceAdapter, AiportServiceAdapter>();
            services.AddScoped<IAirportService, AirportService>();
            services.AddAutoMapper(typeof(Startup));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = ApiKeyAuthenticationOptions.DefaultScheme;
                options.DefaultChallengeScheme = ApiKeyAuthenticationOptions.DefaultScheme;
            }).AddApiKeySupport(options => { });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(Policies.OnlyThirdParties, policy => policy.Requirements.Add(new OnlyThirdPartiesRequirement()));
            });

            services.AddSingleton<IAuthorizationHandler, OnlyThirdPartiesAuthorizationHandler>();
            services.AddSingleton<IGetAllApiKeysQuery, InMemoryGetAllApiKeysQuery>();

            services.AddRouting();
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                });
        }

        // This method gets called by the runti me. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            else
            {
                app.UseExceptionHandler();
            }

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStatusCodePages();
            app.UseMvc();
            app.UseRouting();
        }
    }
}
