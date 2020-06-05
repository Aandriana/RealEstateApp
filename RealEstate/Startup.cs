using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RealEstate.BLL.Interfaces;
using RealEstate.BLL.Services;
using RealEstate.DAL.EF;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace RealEstate
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
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<RedbContext>(options =>
       options.UseSqlServer(connectionString));

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthenticateService, AuthenticateService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
