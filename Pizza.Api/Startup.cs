using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pizza.Core;
using Pizza.Core.Services;
using Pizza.Data;
using Pizza.Services;

namespace Pizza.Api
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
            services.AddDbContext<PizzaDbContext>(options =>
                options.UseSqlServer(Configuration["ConnectionStrings:Default"], x =>
                x.MigrationsAssembly("Pizza.Data")));

            services.AddControllersWithViews();

            services.AddMemoryCache();
            services.AddSession();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IAdresseService, AdresseService>();
            services.AddTransient<IQuartierService, QuartierService>();
            services.AddTransient<ICdeCliService, CdeCliService>();
            services.AddTransient<IPizzaService, PizzaService>();

            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}