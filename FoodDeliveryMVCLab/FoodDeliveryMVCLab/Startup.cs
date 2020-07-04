using AutoMapper;
using FoodDeliveryMVCLab.DAL.DbContext;
using FoodDeliveryMVCLab.DAL.Entities;
using FoodDeliveryMVCLab.DAL.EntityConfigurations;
using FoodDeliveryMVCLab.DAL.EntityConfigurations.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FoodDeliveryMVCLab
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
            string connectionString = Configuration.GetConnectionString("MainConnectionString");

            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlServer(connectionString);

            services.AddScoped<IEntityConfigurationsContainer>(sp => new EntityConfigurationsContainer());

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddSingleton<IApplicationDbContextFactory>(
                sp => new ApplicationDbContextFactory(
                    optionsBuilder.Options,
                    new EntityConfigurationsContainer()
                ));

            services.AddSingleton<IUnitOfWorkFactory, UnitOfWorkFactory>();
            //services.AddSingleton<IDishService, DishService>();
            //services.AddSingleton<IRestaurantService, RestaurantService>();
            //services.AddSingleton<IOrderService, OrderService>();

            //services.AddScoped<IShoppingCartService, ShoppingCartService>();

            services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddControllersWithViews();
            services.AddRazorPages();

            Mapper.Initialize(config => config.AddProfile(new MappingProfile()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
