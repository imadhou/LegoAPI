using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using LegoApi.Data;
using Microsoft.EntityFrameworkCore;
using LegoApi.Repos;
using System;
using LegoApi.Repos.EmployeRepo;
using LegoApi.Repos.ServiceRepo;
using LegoApi.Repos.CongeRepo;
using LegoApi.Repos.EmployeCongeRepo;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using LegoApi.Extensions;
using LegoApi.Middleware;

namespace LegoApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<LegoApiContext>(options =>
                options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            services.AddScoped< IEmployeRepo, EmployeRepo>();
            services.AddScoped< IServiceRepo, ServiceRepo>();
            services.AddScoped< ICongeRepo, CongeRepo>();
            services.AddScoped< IEmployeCongeRepo, EmployeCongeRepo>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LegoApi", Version = "v1" });
            });
            services.AddCors(options => options.AddDefaultPolicy(builder =>
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            // app.ConfigureExceptionHandler(env);
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseCors();
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LegoApi v1"));
            }
            

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
